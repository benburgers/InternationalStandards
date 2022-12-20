/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.Text.Csv.Attributes;

namespace BenBurgers.InternationalStandards.Iso.IO.Iso639;

/// <summary>
/// A record in an ISO 639-3 retirements table.
/// </summary>
/// <param name="Id">
/// The ISO 639-3 Alpha-3 code.
/// </param>
/// <param name="RefName">
/// The reference name of the code.
/// </param>
/// <param name="RetReason">
/// The reason of the code's retirement.
/// </param>
/// <param name="ChangeTo">
/// The new code, if applicable.
/// </param>
/// <param name="RetRemedy">
/// An eventual remedy for the retirement of the code.
/// </param>
/// <param name="Effective">
/// The date from which the retirement is effective.
/// </param>
public sealed record Iso639Part3RetirementsRecord(
    Alpha3 Id,
    [property: CsvColumn("Ref_Name")] string RefName,
    [property: CsvColumn("Ret_Reason")] string RetReason,
    [property: CsvColumn("Change_To")] string ChangeTo,
    [property: CsvColumn("Ret_Remedy")] string RetRemedy,
    DateOnly Effective) : IIso639Part3TableRecord;
