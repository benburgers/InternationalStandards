/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration.Iso639;

public sealed class Iso639Options : IsoOptionsBase
{
    /// <summary>
    /// Gets or sets the file name of the ISO 639-3 Code Table provided by SIL International, the authority of ISO 639-3 codes.
    /// </summary>
    public string Part3CodeTableFileName { get; init; } = default!;

    /// <summary>
    /// Gets or sets the file name of the ISO 639-3 Name Index provided by SIL International, the authority of ISO 639-3 codes.
    /// </summary>
    public string Part3NameIndexFileName { get; init; } = default!;

    /// <summary>
    /// Gets or sets the effective date of the ISO 639-3 codes.
    /// </summary>
    public DateTimeOffset Part3Effective { get; init; }
}
