/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration.Iso639;

public class Iso639Options
{
    /// <summary>
    /// Gets or sets the file name of the ISO 639-3 Code Table provided by SIL International, the authority of ISO 639-3 codes.
    /// </summary>
    public string Part3CodeTableFileName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the file name of the ISO 639-3 Name Index provided by SIL International, the authority of ISO 639-3 codes.
    /// </summary>
    public string Part3NameIndexFileName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the effective date of the ISO 639-3 codes.
    /// </summary>
    public DateTimeOffset Part3Effective { get; set; }

    /// <summary>
    /// Gets or sets the path to the project folder of the BenBurgers.InternationalStandards.Iso project.
    /// </summary>
    public string ProjectFolder { get; set; } = default!;
}
