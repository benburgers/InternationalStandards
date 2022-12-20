/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Iso3166.Xml;

/// <summary>
/// A data set of ISO 3166 country codes.
/// </summary>
/// <param name="Generated">The date and time at which the file was generated.</param>
/// <param name="Countries">A set of countries, their codes and other information.</param>
public sealed record Iso3166XmlDataSet(
    DateTimeOffset Generated,
    IReadOnlySet<Iso3166XmlCountry> Countries);