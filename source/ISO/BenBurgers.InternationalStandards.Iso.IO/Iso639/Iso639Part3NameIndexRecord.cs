/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Iso639;

/// <summary>
/// A record in an ISO 639-3 Name Index.
/// </summary>
/// <param name="Id">
/// The ISO 639-3 identifier of the record.
/// </param>
/// <param name="PrintName">
/// The ISO 639-3 name for printing.
/// </param>
/// <param name="InvertedName">
/// The ISO 639-3 inverted name.
/// </param>
public record Iso639Part3NameIndexRecord(
    [property: Iso639TableColumn("Id")]
    Alpha3 Id,

    [property: Iso639TableColumn("Print_Name")]
    string PrintName,

    [property: Iso639TableColumn("Inverted_Name")]
    string InvertedName);