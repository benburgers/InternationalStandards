/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Attributes;

/// <summary>
/// An attribute for an ISO 639-2 Alpha-3 code.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
internal sealed class Iso639Part2Attribute : Iso639AttributeBase
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639Part2Attribute" />.
    /// </summary>
    /// <param name="iso639Part2T">
    /// The ISO 639-2 Alpha-3 code (terminological).
    /// </param>
    /// <param name="iso639Part2B">
    /// The ISO 639-2 Alpha-3 code (bibliographic).
    /// </param>
    /// <param name="deprecated">
    /// A <see cref="bool" /> value that indicates whether the ISO 639-2 Alpha-3 code is deprecated.
    /// </param>
    internal Iso639Part2Attribute(
        string iso639Part2T,
        string iso639Part2B,
        bool deprecated = false)
        : base(deprecated)
    {
        this.Iso639Part2T = new Alpha3(iso639Part2T);
        this.Iso639Part2B = new Alpha3(iso639Part2B);
    }

    /// <summary>
    /// Gets the ISO 639-2 Alpha-3 code (terminological).
    /// </summary>
    internal Alpha3 Iso639Part2T { get; }

    /// <summary>
    /// Gets the ISO 639-2 Alpha-3 code (bibliographic).
    /// </summary>
    internal Alpha3 Iso639Part2B { get; }
}
