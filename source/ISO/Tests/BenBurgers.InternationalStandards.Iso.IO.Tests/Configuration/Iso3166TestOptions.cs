/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Tests.Configuration;

/// <summary>
/// Configuration options for ISO 3166 feature tests.
/// </summary>
public sealed class Iso3166TestOptions
{
    /// <summary>
    /// Gets the CSV sample files.
    /// </summary>
    public IDictionary<string, string> CsvFiles { get; init; } = new Dictionary<string, string>();

    /// <summary>
    /// Gets the XML sample files.
    /// </summary>
    public IDictionary<string, string> XmlFiles { get; init; } = new Dictionary<string, string>();
}
