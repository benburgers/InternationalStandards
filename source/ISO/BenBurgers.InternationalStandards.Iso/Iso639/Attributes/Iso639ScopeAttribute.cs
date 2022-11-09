/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Attributes;

/// <summary>
/// An attribute that specifies an ISO 639 Scope.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal sealed class Iso639ScopeAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639ScopeAttribute" />.
    /// </summary>
    /// <param name="scope">
    /// The ISO 639 Scope.
    /// </param>
    internal Iso639ScopeAttribute(Iso639Scope scope)
    {
        this.Scope = scope;
    }

    /// <summary>
    /// Gets the ISO 639 Scope.
    /// </summary>
    internal Iso639Scope Scope { get; }
}
