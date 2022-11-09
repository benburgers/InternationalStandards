/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Attributes;

/// <summary>
/// Base class for ISO 639 attributes.
/// </summary>
internal abstract class Iso639AttributeBase : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639AttributeBase" />.
    /// </summary>
    /// <param name="deprecated">
    /// A <see cref="bool" /> value that indicates whether the ISO 639 code is deprecated.
    /// </param>
    protected Iso639AttributeBase(bool deprecated)
    {
        this.Deprecated = deprecated;
    }

    /// <summary>
    /// Gets a <see cref="bool" /> value that indicates whether the ISO 639 code is deprecated.
    /// </summary>
    internal bool Deprecated { get; }
}
