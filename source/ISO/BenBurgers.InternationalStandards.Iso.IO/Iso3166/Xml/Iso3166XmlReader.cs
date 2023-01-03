/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Xml;
using BenBurgers.InternationalStandards.Iso.Exceptions;
using BenBurgers.InternationalStandards.Iso.IO.Exceptions;
using BenBurgers.InternationalStandards.Iso.IO.Iso3166.Xml;
using BenBurgers.InternationalStandards.Iso.Iso3166;
using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.IO.Iso3166;

/// <summary>
/// Reads ISO 3166 codes from XML files as provided by the ISO 3166 Maintenance Agency.
/// </summary>
public sealed partial class Iso3166XmlReader
{
    private readonly StreamReader streamReader;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166XmlReader" />.
    /// </summary>
    /// <param name="stream">
    /// The stream from which to read the ISO 3166 codes.
    /// </param>
    public Iso3166XmlReader(Stream stream)
    {
        this.streamReader = new StreamReader(stream);
    }

    private static IEnumerable<Iso3166XmlCountry> ReadCountries(XmlReader xmlReader)
    {
        while (xmlReader.ReadToFollowing("country"))
        {
            var xml = xmlReader.LookupNamespace("xml")!;
            var xmlCountryReader = xmlReader.ReadSubtree();
            Alpha2? alpha2 = null;
            Alpha3? alpha3 = null;
            short? numeric = null;
            bool? independent = null;
            Iso3166Status? status = null;
            var fullName = new Iso3166XmlMultilingualName();
            var shortName = new Iso3166XmlMultilingualName();
            var shortNameUpperCase = new Iso3166XmlMultilingualName();
            var languages = new Iso3166XmlLanguages();

            Alpha2? id;
            int? version;
            try
            {
                id = new Alpha2(xmlReader.GetAttribute("id")!);
                if (!int.TryParse(xmlReader.GetAttribute("version")!, out var versionFromAttribute))
                    throw new InvalidXmlAttributeException("country", "version");
                version = versionFromAttribute;

                var depth = xmlCountryReader.Depth;
                while (xmlCountryReader.Read())
                {
                    if (xmlCountryReader.NodeType == XmlNodeType.EndElement)
                        continue;
                    switch (xmlCountryReader.Name)
                    {
                        case "alpha-2-code":
                            alpha2 = new Alpha2(xmlCountryReader.ReadElementContentAsString());
                            break;
                        case "alpha-3-code":
                            alpha3 = new Alpha3(xmlCountryReader.ReadElementContentAsString());
                            break;
                        case "numeric-code":
                            numeric = (short)xmlCountryReader.ReadElementContentAsInt();
                            break;
                        case "independent":
                            independent = xmlCountryReader.ReadElementContentAsString() == "YES";
                            break;
                        case "status":
                            status = ReadStatus(xmlCountryReader);
                            break;
                        case "full-name":
                            ReadMultilingualName(fullName, xmlCountryReader, xml);
                            break;
                        case "short-name":
                            ReadMultilingualName(shortName, xmlCountryReader, xml);
                            break;
                        case "short-name-upper-case":
                            ReadMultilingualName(shortNameUpperCase, xmlCountryReader, xml);
                            break;
                        case "language":
                            ReadLanguage(languages, xmlCountryReader.ReadSubtree());
                            break;
                    }
                    if (xmlCountryReader.Depth == depth && xmlCountryReader.NodeType == XmlNodeType.EndElement)
                        break;
                }

            }
            catch (Exception ex) when (ex is not IsoIOException)
            {
                throw new InvalidXmlElementException("country", ex);
            }
            yield return new Iso3166XmlCountry(
                id,
                version.Value,
                alpha2!,
                alpha3!,
                numeric!.Value,
                independent!.Value,
                status!.Value,
                fullName,
                shortName,
                shortNameUpperCase,
                languages);
        }
    }

    private static void ReadLanguage(
        ISet<Iso3166XmlLanguage> languages,
        XmlReader xmlReader)
    {
        if (!xmlReader.ReadToDescendant("language-alpha-3-code"))
            throw new InvalidXmlElementException("language");
        var iso639Code = xmlReader.ReadElementContentAsString().ToIso639();
        if (!xmlReader.ReadToNextSibling("language-is-administrative"))
            throw new InvalidXmlElementException("language");
        var isAdministrative = xmlReader.ReadElementContentAsString() == "YES";
        languages.Add(new Iso3166XmlLanguage(iso639Code, isAdministrative));
    }

    private static void ReadMultilingualName(
        Iso3166XmlMultilingualName multilingualName,
        XmlReader xmlReader,
        string xmlNamespace)
    {
        var iso639Code = xmlReader.GetAttribute("lang", xmlNamespace)!.ToIso639();
        var value = xmlReader.ReadElementContentAsString();
        multilingualName.Add(iso639Code, value);
    }

    private static Iso3166Status ReadStatus(XmlReader xmlReader)
    {
        return xmlReader.ReadElementContentAsString() switch
        {
            "exceptionally-reserved" => Iso3166Status.ExceptionallyReserved,
            "formerly-used" => Iso3166Status.FormerlyUsed,
            "indeterminately-reserved" => Iso3166Status.IndeterminatelyReserved,
            "officially-assigned" => Iso3166Status.OfficiallyAssigned,
            "transitionally-reserved" => Iso3166Status.TransitionallyReserved,
            "unassigned" => Iso3166Status.Unassigned,
            _ => throw new InvalidXmlElementException("status")
        };
    }

    /// <summary>
    /// Reads an ISO 3166 codes data set from an XML file as provided by the ISO 3166 Maintenance Agency.
    /// </summary>
    /// <returns>
    /// An ISO 3166 codes data set.
    /// </returns>
    /// <exception cref="InvalidXmlElementException">
    /// An <see cref="InvalidXmlElementException" /> is thrown if the XML was not in the expected format.
    /// </exception>
    /// <exception cref="InvalidXmlAttributeException">
    /// An <see cref="InvalidXmlAttributeException" /> is thrown if an XML attribute is invalid or not found.
    /// </exception>
    /// <exception cref="AlphaLengthException">
    /// An <see cref="AlphaLengthException" /> is thrown if an Alpha code does not have the required length.
    /// </exception>
    public Iso3166XmlDataSet Read()
    {
        using var xmlReader = XmlReader.Create(this.streamReader);
        if (!xmlReader.ReadToFollowing("country-codes"))
            throw new InvalidXmlElementException("country-codes");
        if (!DateTimeOffset.TryParse(xmlReader.GetAttribute("generated")!, out var generated))
            throw new InvalidXmlAttributeException("country-codes", "generated");
        var countries = ReadCountries(xmlReader.ReadSubtree()).ToHashSet();
        return new Iso3166XmlDataSet(generated, countries);
    }

    /// <summary>
    /// Reads an ISO 3166 codes data set from an XML file as provided by the ISO 3166 Maintenance Agency.
    /// </summary>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// An ISO 3166 codes data set.
    /// </returns>
    public async Task<Iso3166XmlDataSet> ReadAsync(CancellationToken cancellationToken = default) =>
        await Task.Run(this.Read, cancellationToken);
}
