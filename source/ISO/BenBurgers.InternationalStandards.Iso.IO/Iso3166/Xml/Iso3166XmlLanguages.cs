/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Iso3166.Xml;

/// <summary>
/// A set of languages that are recognised by an ISO 3166 country.
/// </summary>
public sealed class Iso3166XmlLanguages : HashSet<Iso3166XmlLanguage>
{
    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            Iso3166XmlLanguages other => this.Equals(other),
            _ => false
        };
    }

    private bool Equals(Iso3166XmlLanguages other)
    {
        return
            this.Count == other.Count
            && this.All(l1 => other.Any(l2 => l1.Iso639Code == l2.Iso639Code && l1.IsAdministrative == l2.IsAdministrative))
            && other.All(l2 => this.Any(l1 => l1.Iso639Code == l2.Iso639Code && l1.IsAdministrative == l2.IsAdministrative));
    }

    /// <inheritdoc />
    public override int GetHashCode() =>
        base.GetHashCode();
}
