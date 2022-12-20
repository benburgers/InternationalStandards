/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.IO.Iso3166.Xml;

/// <summary>
/// A multilingual name for an ISO 3166 code.
/// </summary>
public sealed class Iso3166XmlMultilingualName : Dictionary<Iso639Code, string>
{
    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            Iso3166XmlMultilingualName other => this.Equals(other),
            _ => false
        };
    }

    private bool Equals(Iso3166XmlMultilingualName other)
    {
        var equal = true;
        equal &=
            this.Keys.All(k => other.Keys.Contains(k))
            && other.Keys.All(k => this.Keys.Contains(k));
        foreach (var key in this.Keys)
        {
            equal &= this[key].Equals(other[key]);
        }
        return equal;
    }

    /// <inheritdoc />
    public override int GetHashCode() => base.GetHashCode();
}
