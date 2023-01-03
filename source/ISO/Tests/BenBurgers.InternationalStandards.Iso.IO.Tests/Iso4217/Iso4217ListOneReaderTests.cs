/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.IO.Iso4217;

namespace BenBurgers.InternationalStandards.Iso.IO.Tests.Iso4217;

[Collection(nameof(Iso4217TestCollection))]
public class Iso4217ListOneReaderTests
{
    private readonly Iso4217TestFixture testFixture;

    public Iso4217ListOneReaderTests(Iso4217TestFixture testFixture)
    {
        this.testFixture = testFixture;
    }

    [Fact(DisplayName = "ISO 4217 List One Reader reads ISO 4217 codes.")]
    public async Task ReadTestAsync()
    {
        // Arrange
        var options = this.testFixture.ServiceProvider.GetRequiredService<IOptions<Iso4217TestOptions>>().Value;
        using var fileStream = File.OpenRead(options.ListOneFileName);
        using var reader = new Iso4217ListOneXmlReader(fileStream);

        // Act
        var dataSet = await reader.ReadAsync();

        // Assert
        Assert.NotNull(dataSet);
        Assert.NotNull(dataSet.Table);
        Assert.NotEmpty(dataSet.Table.Entries);
    }
}
