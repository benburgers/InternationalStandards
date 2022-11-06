/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration.Iso639;

namespace BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration;

public class CodeGeneratorOptions
{
    /// <summary>
    /// Options for generating ISO 639 code.
    /// </summary>
    public Iso639Options? Iso639 { get; set; }
}
