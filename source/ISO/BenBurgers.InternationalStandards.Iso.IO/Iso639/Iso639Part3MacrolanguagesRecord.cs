/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.Text.Csv.Attributes;

namespace BenBurgers.InternationalStandards.Iso.IO.Iso639;

/// <summary>
/// A record in an ISO 639-3 macrolanguages table.
/// </summary>
/// <param name="MacroId">
/// The ISO 639-3 code of the macrolanguage.
/// </param>
/// <param name="IndividualId">
/// The ISO 639-3 code of the individual language.
/// </param>
/// <param name="IndividualStatus">
/// The status of the individual language.
/// </param>
public sealed record Iso639Part3MacrolanguagesRecord(
    [property: CsvColumn("M_Id")] Alpha3 MacroId,
    [property: CsvColumn("I_Id")] Alpha3 IndividualId,
    [property: CsvColumn("I_Status")] Iso639Status IndividualStatus) : IIso639Part3TableRecord;
