/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer;

/// <summary>
/// Writes messages to the console in case the `dotnet ef` tool is being executed.
/// </summary>
internal static class IsoConsole
{
    /// <summary>
    /// Writes the lines to the console.
    /// </summary>
    /// <param name="lines">
    /// The lines to write.
    /// </param>
    internal static void WriteLines(params string[] lines)
    {
        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (var line in lines)
        {
            Console.WriteLine($"[ISO] {line}");
        }
        Console.ForegroundColor = previousColor;
    }
}
