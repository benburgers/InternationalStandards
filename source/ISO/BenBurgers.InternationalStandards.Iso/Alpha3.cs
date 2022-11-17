/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Exceptions;

namespace BenBurgers.InternationalStandards.Iso;

/// <summary>
/// An Alpha-3 value.
/// </summary>
public sealed class Alpha3 : Alpha
{
    /// <summary>
    /// Initializes a new instance of <see cref="Alpha3" />.
    /// </summary>
    /// <param name="value">
    /// The Alpha-3 value.
    /// </param>
    /// <exception cref="AlphaLengthException">
    /// An <see cref="AlphaLengthException" /> is thrown if the <paramref name="value" /> does not have the required length (3).
    /// </exception>
    public Alpha3(string value)
        : base(value, 3)
    {
    }
}
