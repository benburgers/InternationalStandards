/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Globalization;

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Exceptions;

/// <summary>
/// An exception that is thrown if the name for an ISO 3166 code is missing.
/// </summary>
public sealed class Iso3166NameMissingException : Iso3166Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166NameMissingException" />.
    /// </summary>
    /// <param name="iso3166Code">
    /// The ISO 3166 code.
    /// </param>
    /// <param name="nameVariant">
    /// The requested <see cref="NameVariant" /> of the name.
    /// </param>
    /// <param name="cultureInfo">
    /// The culture for which the name is requested.
    /// </param>
    internal Iso3166NameMissingException(
        Iso3166Code iso3166Code,
        Iso3166NameVariant nameVariant,
        CultureInfo? cultureInfo)
        : base(GetExceptionMessage(iso3166Code, nameVariant, cultureInfo))
    {
        this.Iso3166Code = Iso3166Code;
        this.NameVariant = nameVariant;
        this.CultureInfo = cultureInfo;
    }

    /// <summary>
    /// Gets the ISO 3166 code.
    /// </summary>
    public Iso3166Code Iso3166Code { get; }

    /// <summary>
    /// Gets the name variant (e.g.: Short or Long).
    /// </summary>
    public Iso3166NameVariant NameVariant { get; }

    /// <summary>
    /// Gets the culture for which the name is requested.
    /// </summary>
    public CultureInfo? CultureInfo { get; }

    private static string GetExceptionMessage(
        Iso3166Code iso3166Code,
        Iso3166NameVariant nameVariant,
        CultureInfo? cultureInfo)
    {
        var messageTemplate = nameVariant switch
        {
            Iso3166NameVariant.Short => ExceptionMessages.Iso3166NameMissingShort,
            Iso3166NameVariant.Long => ExceptionMessages.Iso3166NameMissingLong,
            _ => string.Empty
        };
        return string.Format(messageTemplate, iso3166Code, cultureInfo);
    }
}
