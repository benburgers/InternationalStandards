/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Iso3166.Storage.ValueConversion.Alpha;

/// <summary>
/// Options for an <see cref="Iso3166AlphaValueConverter" />.
/// </summary>
/// <param name="AlphaMode">
/// Defines which Alpha code to convert. Defaults to <see cref="Iso3166AlphaMode.Alpha2" />.
/// </param>
public record Iso3166AlphaValueConverterOptions(Iso3166AlphaMode AlphaMode = Iso3166AlphaMode.Alpha2);
