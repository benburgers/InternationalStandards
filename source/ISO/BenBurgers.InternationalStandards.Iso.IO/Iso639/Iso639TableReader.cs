/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.IO.Exceptions;
using BenBurgers.InternationalStandards.Iso.Iso639;
using System.Data;
using System.Reflection;

namespace BenBurgers.InternationalStandards.Iso.IO.Iso639;

/// <summary>
/// An ISO 639 Table Reader base implementation.
/// </summary>
public sealed class Iso639TableReader<TRecord> : IDisposable
    where TRecord : class
{
    private static readonly IReadOnlyList<(string ColumnName, Type PropertyType)> ConstructorParameters =
        typeof(TRecord)
            .GetProperties()
            .Select(p => (p.GetCustomAttribute<Iso639TableColumnAttribute>()!.ColumnName, p.PropertyType))
            .ToArray();

    private const char ColumnSeparator = '\t';
    private bool disposedValue;
    private readonly StreamReader streamReader;

    private static object? Convert(string value, Type typeToConvert)
    {
        static Iso639Scope Scope(string scopeValue)
        {
            return scopeValue switch
            {
                "I" => Iso639Scope.Individual,
                "M" => Iso639Scope.Macrolanguage,
                "S" => Iso639Scope.Special,
                _ => Iso639Scope.None
            };
        }

        static Iso639LanguageType LanguageType(string languageTypeValue)
        {
            return languageTypeValue switch
            {
                "A" => Iso639LanguageType.Ancient,
                "C" => Iso639LanguageType.Constructed,
                "E" => Iso639LanguageType.Extinct,
                "H" => Iso639LanguageType.Historical,
                "L" => Iso639LanguageType.Living,
                "S" => Iso639LanguageType.Special,
                _ => Iso639LanguageType.None
            };
        }

        static DateOnly Date(string dateValue)
        {
            return DateOnly.Parse(dateValue);
        }

        return typeToConvert switch
        {
            { Name: nameof(String) } => value,
            { Name: nameof(DateOnly) } => Date(value),
            { Name: nameof(Iso639Scope) } => Scope(value),
            { Name: nameof(Iso639LanguageType) } => LanguageType(value),
            { Name: nameof(Alpha2) } => string.IsNullOrWhiteSpace(value) ? null : new Alpha2(value),
            { Name: nameof(Alpha3) } => string.IsNullOrWhiteSpace(value) ? null : new Alpha3(value),
            _ => null
        };
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso639TableReader{TRecord}" />.
    /// </summary>
    /// <param name="stream">
    /// The stream from which to read the table.
    /// </param>
    public Iso639TableReader(Stream stream)
    {
        this.streamReader = new StreamReader(stream);
    }

    /// <summary>
    /// Reads the column line at the start of the stream.
    /// </summary>
    /// <returns>
    /// A list of column names and their indices.
    /// </returns>
    private async Task<IReadOnlyList<string>> ReadColumnsAsync()
    {
        var columnsLine = (await streamReader.ReadLineAsync())!;
        return
            columnsLine
                .Split(ColumnSeparator)
                .ToArray();
    }

    /// <summary>
    /// Reads the next line from the stream and arranges the values by their columns.
    /// </summary>
    /// <param name="columns">
    /// The names of the columns, in order of the values being read.
    /// </param>
    /// <returns>
    /// A dictionary that contains the names of the columns and their respective values.
    /// </returns>
    private async Task<TRecord?> ReadLineAsync(IReadOnlyList<string> columns)
    {
        if ((await this.streamReader.ReadLineAsync()) is not { } line)
            return null;
        var values = line.Split(ColumnSeparator);
        var valueDictionary =
            columns
                .Select((c, i) => new KeyValuePair<string, string>(c, values[i]))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        var constructorParameterValues =
            ConstructorParameters
                .Select(cp => Convert(valueDictionary[cp.ColumnName], cp.PropertyType))
                .ToArray();
        return (TRecord)Activator.CreateInstance(typeof(TRecord), constructorParameterValues)!;
    }

    /// <summary>
    /// Reads all <typeparamref name="TRecord" /> records from the table.
    /// </summary>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// A list of <typeparamref name="TRecord" /> as read from the table.
    /// </returns>
    /// <exception cref="Iso639IOException">
    /// An <see cref="Iso639IOException" /> is thrown if reading the table failed.
    /// </exception>
    public async Task<IReadOnlyList<TRecord>> ReadAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var columns = await this.ReadColumnsAsync();

            var records = new List<TRecord>();
            while (await this.ReadLineAsync(columns) is { } record)
            {
                cancellationToken.ThrowIfCancellationRequested();
                records.Add(record);
            }

            return records;
        }
        catch (Exception ex)
        {
            throw new Iso639IOException(ExceptionMessages.Iso639Part3NameIndexReaderFailed, ex);
        }
    }

    /// <summary>
    /// Disposes resources that have been in use.
    /// </summary>
    /// <param name="disposing">
    /// A <see cref="bool" /> value that indicates whether this method was called by code, rather than the Garbage Collector.
    /// </param>
    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
                this.streamReader.Dispose();
            disposedValue = true;
        }
    }

    /// <summary>
    /// Disposes any resources held by <see cref="Iso639TableReader{TRecord}" />.
    /// </summary>
    public void Dispose()
    {
        this.Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
