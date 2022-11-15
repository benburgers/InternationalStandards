/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Xml;

namespace BenBurgers.InternationalStandards.Iso.IO.Iso4217;

/// <summary>
/// Reads ISO 4217 List One files.
/// </summary>
public sealed partial class Iso4217ListOneXmlReader : IDisposable
{
    private readonly StreamReader streamReader;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217ListOneXmlReader" />.
    /// </summary>
    /// <param name="stream">
    /// The stream from which to read the ISO 4217 List One.
    /// </param>
    public Iso4217ListOneXmlReader(Stream stream)
    {
        this.streamReader = new StreamReader(stream);
    }

    /// <summary>
    /// Reads an ISO 4217 List One data set from the stream.
    /// </summary>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// An ISO 4217 List One data set.
    /// </returns>
    public async Task<Iso4217ListOneDataSet> ReadAsync(
        CancellationToken cancellationToken = default)
    {
        const string CcyNtry = nameof(CcyNtry);
        return await Task.Run(() =>
        {
            var xmlReader = XmlReader.Create(this.streamReader);
            xmlReader.ReadToFollowing("ISO_4217");
            var published = DateOnly.Parse(xmlReader.GetAttribute("Pblshd")!);

            xmlReader.ReadToDescendant("CcyTbl");
            var entries = new List<Iso4217ListOneCurrencyEntry>();
            xmlReader.ReadToDescendant(CcyNtry);
            entries.Add(ReadEntry(xmlReader.ReadSubtree()));
            xmlReader.ReadEndElement();
            while (xmlReader.ReadToNextSibling(CcyNtry))
            {
                entries.Add(ReadEntry(xmlReader.ReadSubtree()));
                xmlReader.ReadEndElement();
            }

            return new Iso4217ListOneDataSet(published, new Iso4217ListOneCurrencyTable(entries.ToArray()));
        }, cancellationToken);
    }

    private static Iso4217ListOneCurrencyEntry ReadEntry(XmlReader xmlReader)
    {
        string countryName;
        string currencyName;
        Alpha3? currencyCode = null;
        int? currencyNumber = null;
        int? currencyMinorUnits = null;

        xmlReader.ReadToDescendant("CtryNm");
        countryName = xmlReader.ReadElementContentAsString();
        xmlReader.ReadToNextSibling("CcyNm");
        currencyName = xmlReader.ReadElementContentAsString();
        if (xmlReader.ReadToNextSibling("Ccy"))
            currencyCode = new Alpha3(xmlReader.ReadElementContentAsString());
        if (xmlReader.ReadToNextSibling("CcyNbr"))
            currencyNumber = xmlReader.ReadElementContentAsInt();
        if (xmlReader.ReadToNextSibling("CcyMnrUnts"))
        {
            var currencyMinorUnitsString = xmlReader.ReadElementContentAsString();
            if (currencyMinorUnitsString == "N.A.")
                currencyMinorUnits = null;
            else
                currencyMinorUnits = int.Parse(currencyMinorUnitsString);
        }

        return new Iso4217ListOneCurrencyEntry(countryName, currencyName, currencyCode, currencyNumber, currencyMinorUnits);
    }
}
