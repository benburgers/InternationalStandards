/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Attributes;

/// <summary>
/// An attribute for an ISO 639-1 Alpha-2 code.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
internal sealed class Iso639Part1Attribute : Iso639AttributeBase
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639Part1Attribute" />.
    /// </summary>
    /// <param name="iso639Part1">
    /// The ISO 639-1 Alpha-2 code.
    /// </param>
    /// <param name="deprecated">
    /// A <see cref="bool" /> value that indicates whether the ISO 639-1 Alpha-2 code is deprecated.
    /// </param>
    internal Iso639Part1Attribute(
        string iso639Part1,
        bool deprecated = false)
        : base(deprecated)
    {
        this.Iso639Part1 = new Alpha2(iso639Part1);
    }

    /// <summary>
    /// Gets the ISO 639-1 Alpha-2 code.
    /// </summary>
    internal Alpha2 Iso639Part1 { get; }
}
