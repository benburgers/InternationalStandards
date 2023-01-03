/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration.Iso3166;

public sealed class Iso3166Options : IsoOptionsBase
{
    /// <summary>
    /// Gets the file name of the XML file that contains information for ISO 3166 codes.
    /// </summary>
    public string XmlFileName { get; set; } = default!;
}
