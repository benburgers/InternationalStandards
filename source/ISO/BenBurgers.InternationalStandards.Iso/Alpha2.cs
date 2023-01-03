/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Exceptions;

namespace BenBurgers.InternationalStandards.Iso;

/// <summary>
/// An Alpha-2 value.
/// </summary>
public sealed class Alpha2 : Alpha
{
    /// <summary>
    /// Initializes a new instance of <see cref="Alpha2" />.
    /// </summary>
    /// <param name="value">
    /// The Alpha-2 value.
    /// </param>
    /// <exception cref="AlphaLengthException">
    /// An <see cref="AlphaLengthException" /> is thrown if the <paramref name="value" /> does not have the required length (2).
    /// </exception>
    public Alpha2(string value)
        : base(value, 2)
    {
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            Alpha2 alpha2 => this.Value.Equals(alpha2.Value),
            _ => false
        };
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }
}
