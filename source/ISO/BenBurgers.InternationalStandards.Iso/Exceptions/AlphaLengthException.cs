/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Exceptions;

/// <summary>
/// An exception that is thrown if an Alpha-2 or an Alpha-3 length restriction was violated.
/// </summary>
public sealed class AlphaLengthException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="AlphaLengthException" />.
    /// </summary>
    /// <param name="required">
    /// The required number of characters. For Alpha-2 two, for Alpha-3 three.
    /// </param>
    /// <param name="value">
    /// The invalid value.
    /// </param>
    public AlphaLengthException(int required, string value)
        : base(GetExceptionMessage(required, value))
    {
        this.Required = required;
        this.Value = value;
    }

    /// <summary>
    /// Gets the required number of characters. For Alpha-2 two, for Alpha-3 three.
    /// </summary>
    public int Required { get; }

    /// <summary>
    /// Gets the invalid value.
    /// </summary>
    public string Value { get; }

    private static string GetExceptionMessage(int required, string value)
    {
        return string.Format(ExceptionMessages.AlphaNotRequiredLength, value, required);
    }
}
