/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639;

/// <summary>
/// Filter options for a query of <see cref="Iso639Code" />.
/// </summary>
/// <param name="MustHavePart1">
/// A <see cref="bool" /> value that indicates whether an ISO 639-1 Alpha-2 code should be designated.
/// </param>
/// <param name="MustHavePart2">
/// A <see cref="bool" /> value that indicates whether an ISO 639-2 Alpha-3 code should be designated.
/// </param>
/// <param name="MustHavePart3">
/// A <see cref="bool" /> value that indicates whether an ISO 639-3 Alpha-3 code should be designated.
/// </param>
/// <param name="Scope">
/// <see cref="Iso639Scope" /> flags that indicate which ISO 639 scopes should be included.
/// </param>
/// <param name="LanguageType">
/// <see cref="Iso639LanguageType" /> flags that indicate which ISO 639 language types should be included.
/// </param>
/// <param name="IncludeDeprecated">
/// A <see cref="bool" /> value that indicates whether deprecated codes should be included.
/// </param>
public record Iso639FilterOptions(
    bool MustHavePart1 = false,
    bool MustHavePart2 = false,
    bool MustHavePart3 = false,
    Iso639Scope Scope = Iso639Scope.None,
    Iso639LanguageType LanguageType = Iso639LanguageType.None,
    bool IncludeDeprecated = false);