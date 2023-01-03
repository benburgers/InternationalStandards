/*
 * © 2022-2023 Ben Burgers and contributors.
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
    /// <summary>
    /// Gets or initializes the ISO 4217 models that are associated with this entity.
    /// </summary>
    public IReadOnlyList<Iso4217Model> Models { get; init; } = new List<Iso4217Model>();

    /// <inheritdoc />
    public override string ToString() => this.Name;
}