/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Attributes;

/// <summary>
/// An attribute for an ISO 639-3 Alpha-3 code with type.
/// </summary>
internal sealed class Iso639Part3Attribute : Iso639AttributeBase
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639Part3Attribute" />.
    /// </summary>
    /// <param name="iso639Part3">
    /// The ISO 639-3 Alpha-3 code.
    /// </param>
    /// <param name="deprecated">
    /// A <see cref="bool" /> value that indicates whether the ISO 639-3 Alpha-3 code is deprecated.
    /// </param>
    internal Iso639Part3Attribute(string iso639Part3, bool deprecated = false)
        : base(deprecated)
    {
        this.Iso639Part3 = new Alpha3(iso639Part3);
    }

    /// <summary>
    /// Gets the ISO 639-3 Alpha-3 code.
    /// </summary>
    internal Alpha3 Iso639Part3 { get; }
}
