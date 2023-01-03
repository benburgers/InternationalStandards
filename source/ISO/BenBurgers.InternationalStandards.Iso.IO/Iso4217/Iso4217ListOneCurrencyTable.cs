/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Iso4217;

/// <summary>
/// A table of ISO 4217 List One currencies.
/// </summary>
/// <param name="Entries">
/// The ISO 4217 List One currency entries.
/// </param>
public record Iso4217ListOneCurrencyTable(
    Iso4217ListOneCurrencyEntry[] Entries);