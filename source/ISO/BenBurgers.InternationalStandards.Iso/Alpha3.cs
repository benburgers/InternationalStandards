/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

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
    public Alpha3(string value)
        : base(value, 3)
    {
    }
}
