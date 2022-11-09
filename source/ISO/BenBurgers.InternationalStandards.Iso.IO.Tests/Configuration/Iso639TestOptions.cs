/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Tests.Configuration;

public class Iso639TestOptions
{
    /// <summary>
    /// Gets or sets the ISO 639-3 Code Table filename (including the path).
    /// </summary>
    public string Part3CodeTableFileName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the ISO 639-3 Name Index filename (including the path).
    /// </summary>
    public string Part3NameIndexFileName { get; set; } = default!;
}
