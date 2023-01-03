/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso3166;

/// <summary>
/// Configuration options for ISO 3166 JSON converters.
/// </summary>
/// <param name="AlphaMode">
/// The Alpha code mode for an ISO 3166 code.
/// </param>
/// <param name="CaseInsensitive">
/// A <see cref="bool" /> value that indicates whether Alpha codes may be allowed to be lower case letters.
/// </param>
/// <param name="NumericAsString">
/// A <see cref="bool" /> value that indicates whether Numeric codes must be written as a <see cref="string" /> with leading zeros.
/// </param>
public record Iso3166JsonConverterOptions(
    Iso3166AlphaMode AlphaMode = Iso3166AlphaMode.Alpha2,
    bool CaseInsensitive = false,
    bool NumericAsString = false)
{
    /// <summary>
    /// The default options.
    /// </summary>
    public static readonly Iso3166JsonConverterOptions Default = new();
}