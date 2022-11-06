/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

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
    public Alpha2(string value)
        : base(value, 2)
    {
    }
}
