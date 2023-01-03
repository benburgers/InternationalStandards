/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Exceptions;

namespace BenBurgers.InternationalStandards.Iso;

/// <summary>
/// An Alpha code with a fixed length. Alpha-2 has two, Alpha-3 has three.
/// </summary>
public class Alpha : IComparable
{
    /// <summary>
    /// Initializes a new instance of <see cref="Alpha" />.
    /// </summary>
    /// <param name="value">
    /// The Alpha-2 value.
    /// </param>
    /// <param name="requiredLength">
    /// The required length. For Alpha-2 two, for Alpha-3 three.
    /// </param>
    /// <exception cref="AlphaLengthException">
    /// An <see cref="AlphaLengthException" /> is thrown if the <paramref name="value" /> does not have the required length.
    /// </exception>
    public Alpha(string value, int requiredLength)
    {
        if (value.Length != requiredLength)
            throw new AlphaLengthException(requiredLength, value);
        this.Value = value;
    }

    /// <summary>
    /// Gets the required length. For Alpha-2 two, for Alpha-3 three.
    /// </summary>
    public int RequiredLength { get; }

    /// <summary>
    /// Gets the Alpha value.
    /// </summary>
    public string Value { get; }

    /// <inheritdoc />
    public int CompareTo(object? obj) =>
        obj switch
        {
            null => -1,
            string s => this.Value.CompareTo(s),
            Alpha a => this.Value.CompareTo(a.Value),
            _ => -1
        };

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            Alpha alpha => this.Value.Equals(alpha.Value),
            _ => false
        };
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }

    /// <summary>
    /// Returns the Alpha value.
    /// </summary>
    /// <returns>
    /// The Alpha value.
    /// </returns>
    public override string ToString()
    {
        return this.Value;
    }
}