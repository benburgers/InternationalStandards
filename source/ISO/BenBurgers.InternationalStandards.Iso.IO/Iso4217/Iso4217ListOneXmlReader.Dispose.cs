/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Iso4217;

public sealed partial class Iso4217ListOneXmlReader
{
    private bool disposedValue;
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
    /// Disposes any resources held by <see cref="Iso4217ListOneXmlReader" />.
    /// </summary>
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
