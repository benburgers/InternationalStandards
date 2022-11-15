/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.CodeDom;

namespace BenBurgers.InternationalStandards.Iso.CodeGenerator.Common;

/// <summary>
/// A copyright notice in code generation.
/// </summary>
internal class CopyrightNotice : CodeCommentStatementCollection
{
    /// <summary>
    /// The singleton instance of <see cref="CopyrightNotice" />.
    /// </summary>
    internal static readonly CopyrightNotice Instance = new();

    /// <summary>
    /// Initializes a new instance of <see cref="CopyrightNotice" />.
    /// </summary>
    private CopyrightNotice()
        : base(GetContents())
    {
    }

    private static CodeCommentStatement[] GetContents()
    {
        return new CodeCommentStatement[]
        {
            new("© 2022 Ben Burgers and contributors."),
            new("This work is licensed by GNU General Public License version 3.")
        };
    }
}
