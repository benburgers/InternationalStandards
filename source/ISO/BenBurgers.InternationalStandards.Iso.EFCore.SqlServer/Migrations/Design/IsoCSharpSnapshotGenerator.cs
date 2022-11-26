/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations.Design;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Design;

/// <summary>
/// Generates model snapshots for ISO standards.
/// </summary>
internal sealed class IsoCSharpSnapshotGenerator : CSharpSnapshotGenerator
{
    /// <summary>
    /// Initializes a new instance of <see cref="IsoCSharpSnapshotGenerator" />.
    /// </summary>
    /// <param name="dependencies">
    /// The dependencies.
    /// </param>
    public IsoCSharpSnapshotGenerator(CSharpSnapshotGeneratorDependencies dependencies)
        : base(dependencies)
    {
    }

    /// <inheritdoc />
    public override void Generate(string modelBuilderName, IModel model, IndentedStringBuilder stringBuilder)
    {
        base.Generate(modelBuilderName, model, stringBuilder);
    }
}
