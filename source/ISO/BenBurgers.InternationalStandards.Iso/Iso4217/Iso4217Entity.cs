/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217;

/// <summary>
/// An ISO 4217 entity that trades a currency.
/// </summary>
/// <param name="Name">
/// The name of the entity.
/// </param>
public sealed record Iso4217Entity(string Name)
{
    /// <inheritdoc />
    public override string ToString()
    {
        return this.Name;
    }
}