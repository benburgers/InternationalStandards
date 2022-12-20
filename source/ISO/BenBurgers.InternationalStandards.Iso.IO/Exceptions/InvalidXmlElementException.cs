/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Exceptions;

/// <summary>
/// An exception that is thrown if the XML is not in the expected format.
/// </summary>
public sealed class InvalidXmlElementException : IsoIOException
{
    /// <summary>
    /// Initializes a new instance of <see cref="InvalidXmlElementException" />.
    /// </summary>
    /// <param name="elementName">The name of the element involved.</param>
    /// <param name="innerException">The optional inner exception.</param>
    internal InvalidXmlElementException(string elementName, Exception? innerException = null)
        : base(CreateExceptionMessage(elementName), innerException)
    {
        this.ElementName = elementName;
    }

    /// <summary>
    /// Gets the name of the element involved.
    /// </summary>
    public string ElementName { get; }

    private static string CreateExceptionMessage(string elementName) =>
        string.Format(ExceptionMessages.InvalidXmlElement, elementName);
}
