/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Iso4217;

/// <summary>
/// An ISO 4217 List One data set.
/// </summary>
/// <param name="Published">
/// The date at which the data set was published.
/// </param>
/// <param name="Table">
/// A table of ISO 4217 List One currency entries.
/// </param>
public record Iso4217ListOneDataSet(
    DateOnly Published,
    Iso4217ListOneCurrencyTable Table);
