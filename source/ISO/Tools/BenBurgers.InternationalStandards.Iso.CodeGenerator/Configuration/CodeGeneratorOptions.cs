/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration.Iso3166;
using BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration.Iso4217;
using BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration.Iso639;

namespace BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration;

public class CodeGeneratorOptions
{
    /// <summary>
    /// Options for generating ISO 639 language codes.
    /// </summary>
    public Iso639Options? Iso639 { get; set; }

    /// <summary>
    /// Options for generating ISO 3166 country codes.
    /// </summary>
    public Iso3166Options? Iso3166 { get; set; }

    /// <summary>
    /// Options for generating ISO 4217 currency codes.
    /// </summary>
    public Iso4217Options? Iso4217 { get; set; }
}
