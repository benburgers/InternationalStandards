/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.Text.Csv.Attributes;

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
public sealed record Iso639Part3NameIndexRecord(
    Alpha3 Id,
    [property: CsvColumn("Print_Name")] string PrintName,
    [property: CsvColumn("Inverted_Name")] string InvertedName) : IIso639Part3TableRecord;