/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Exceptions;

/// <summary>
/// An exception that is thrown if an invalid XML attribute is encountered, or the attribute is missing.
/// </summary>
public sealed class InvalidXmlAttributeException : IsoIOException
{
    /// <summary>
    /// Initializes a new instance of <see cref="InvalidXmlAttributeException" />.
    /// </summary>
    /// <param name="elementName">The name of the XML element involved.</param>
    /// <param name="attributeName">The name of the XML attribute involved.</param>
    internal InvalidXmlAttributeException(string elementName, string attributeName)
        : base(CreateExceptionMessage(elementName, attributeName))
    {
        this.ElementName = elementName;
        this.AttributeName = attributeName;
    }

    /// <summary>
    /// Gets the name of the XML element involved.
    /// </summary>
    public string ElementName { get; }

    /// <summary>
    /// Gets the name of the XML attribute involved.
    /// </summary>
    public string AttributeName { get; }

    private static string CreateExceptionMessage(string elementName, string attributeName) =>
        string.Format(ExceptionMessages.InvalidXmlAttribute, elementName, attributeName);
}
