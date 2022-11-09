/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Iso639;

/// <summary>
/// An attribute for an ISO 639 Table column.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public sealed class Iso639TableColumnAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639TableColumnAttribute" />.
    /// </summary>
    /// <param name="columnName">
    /// The name of the column.
    /// </param>
    public Iso639TableColumnAttribute(string columnName)
    {
        this.ColumnName = columnName;
    }

    /// <summary>
    /// Gets the name of the column.
    /// </summary>
    public string ColumnName { get; }
}
