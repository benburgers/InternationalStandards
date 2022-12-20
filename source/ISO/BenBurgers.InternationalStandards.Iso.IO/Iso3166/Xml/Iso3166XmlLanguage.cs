/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.IO.Iso3166.Xml;

/// <summary>
/// A representation of an ISO 3166 language.
/// </summary>
/// <param name="Iso639Code">The ISO 639 code that represents the language.</param>
/// <param name="IsAdministrative">A value that indicates whether the language is administrative.</param>
public sealed record Iso3166XmlLanguage(
    Iso639Code Iso639Code,
    bool IsAdministrative);