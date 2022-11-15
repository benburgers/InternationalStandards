/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Json.Iso4217;

/// <summary>
/// Configuration options for ISO 4217 JSON Converters.
/// </summary>
/// <param name="CaseInsensitive">
/// A <see cref="bool" /> value that indicates whether Alpha codes may be allowed to be lower case letters.
/// </param>
public record Iso4217JsonConverterOptions(bool CaseInsensitive = false);
