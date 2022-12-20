/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Iso639;

public sealed partial class Iso639TableReader<TRecord>
{
    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
                this.csvReader.Dispose();
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
