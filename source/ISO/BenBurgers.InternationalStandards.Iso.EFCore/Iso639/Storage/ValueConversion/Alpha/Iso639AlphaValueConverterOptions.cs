/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Iso639.Storage.ValueConversion.Alpha;

/// <summary>
/// Configuration options for an ISO 639 Alpha Value Converter.
/// </summary>
/// <param name="Part">
/// The ISO 639 Part to convert to.
/// </param>
/// <param name="AllowDeprecated">
/// A <see cref="bool" /> value that indicates whether deprecated ISO 639 codes are allowed.
/// </param>
public record Iso639AlphaValueConverterOptions(
    Iso639Part Part = Iso639Part.Part3,
    bool AllowDeprecated = false);
