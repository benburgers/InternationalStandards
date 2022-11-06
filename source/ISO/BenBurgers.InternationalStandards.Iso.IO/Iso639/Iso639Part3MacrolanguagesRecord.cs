/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

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
public record Iso639Part3MacrolanguagesRecord(
    [property: Iso639TableColumn("M_Id")]
    Alpha3 MacroId,

    [property: Iso639TableColumn("I_Id")]
    Alpha3 IndividualId,

    [property: Iso639TableColumn("I_Status")]
    Iso639Status IndividualStatus);
