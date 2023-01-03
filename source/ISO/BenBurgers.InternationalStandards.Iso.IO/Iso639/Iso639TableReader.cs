/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.IO.Exceptions;
using BenBurgers.Text.Csv;
using BenBurgers.Text.Csv.Mapping;

namespace BenBurgers.InternationalStandards.Iso.IO.Iso639;

/// <summary>
/// An ISO 639 Table Reader base implementation.
/// </summary>
public sealed partial class Iso639TableReader<TRecord> : IDisposable
    where TRecord : class, IIso639Part3TableRecord
{
    private static readonly Iso639TableTypeConverter TC = new();
    private const char ColumnSeparator = '\t';
    private bool disposedValue;
    private readonly CsvReader<TRecord> csvReader;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso639TableReader{TRecord}" />.
    /// </summary>
    /// <param name="stream">
    /// The stream from which to read the table.
    /// </param>
    public Iso639TableReader(Stream stream)
    {
        var mapping = new CsvHeaderTypeMapping<TRecord>(TC);
        var options = new CsvOptions<TRecord>(mapping, Delimiter: ColumnSeparator);
        this.csvReader = new CsvReader<TRecord>(stream, options);
    }

    /// <summary>
    /// Reads the next line from the stream and arranges the values by their columns.
    /// </summary>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// A dictionary that contains the names of the columns and their respective values.
    /// </returns>
    private async Task<TRecord?> ReadLineAsync(CancellationToken cancellationToken = default)
    {
        return await this.csvReader.ReadLineAsync(cancellationToken);
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
            var records = new List<TRecord>();
            while (await this.csvReader.ReadLineAsync(cancellationToken) is { } record)
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
}