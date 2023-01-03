/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso;

public sealed partial class GlobalizedString
{
    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            GlobalizedString other => this.Equals(other),
            _ => false
        };
    }

    private bool Equals(GlobalizedString other) =>
        this.Count.Equals(other.Count)
        && this.All(kvp => other.ContainsKey(kvp.Key) && other[kvp.Key] == kvp.Value)
        && other.All(kvp => this.ContainsKey(kvp.Key) && this[kvp.Key] == kvp.Value);

    /// <inheritdoc />
    public override int GetHashCode() =>
        this
            .Select(kvp => HashCode.Combine(kvp.Key, kvp.Value))
            .Aggregate(0, (h1, h2) => HashCode.Combine(h1, h2));
}
