/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration;

/// <summary>
/// Base class for generator options for ISO standards.
/// </summary>
public abstract class IsoOptionsBase
{
    /// <summary>
    /// Gets or sets the path to the project folder of the BenBurgers.InternationalStandards.Iso project.
    /// </summary>
    public string ProjectFolder { get; init; } = default!;
}
