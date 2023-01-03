/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Json.Iso639.Alpha;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso639;

/// <summary>
/// Configuration options for ISO 639 JSON converters.
/// </summary>
/// <param name="AlphaMode">
/// The Alpha code mode for an ISO 639 code.
/// </param>
/// <param name="CaseInsensitive">
/// A <see cref="bool" /> value that indicates whether Alpha codes may be allowed to be upper case letters.
/// </param>
/// <param name="AllowDeprecated">
/// A <see cref="bool" /> value that indicates whether deprecated ISO 639 codes are allowed.
/// </param>
public record Iso639JsonConverterOptions(
    Iso639AlphaMode AlphaMode = Iso639AlphaMode.Part1,
    bool CaseInsensitive = false,
    bool AllowDeprecated = false)
{
    /// <summary>
    /// The default options.
    /// </summary>
    public static readonly Iso639JsonConverterOptions Default = new();
}