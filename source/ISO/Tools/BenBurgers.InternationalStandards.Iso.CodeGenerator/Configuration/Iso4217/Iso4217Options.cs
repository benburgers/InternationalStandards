/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration.Iso4217;

/// <summary>
/// Options for generating ISO 4217 currency codes.
/// </summary>
public class Iso4217Options
{
    /// <summary>
    /// Gets or sets the file name (including path) to the main list of ISO 4217 currency codes (XML file) 
    /// as provided by SIX Financial Information AG, the Maintenance Agency of ISO 4217 currency codes.
    /// </summary>
    public string ListOneFileName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the path to the BenBurgers.InternationalStandards.Iso project.
    /// </summary>
    public string ProjectFolder { get;set; } = default!;
}
