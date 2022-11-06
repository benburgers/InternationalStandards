/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Tests.Iso639;

[Collection(nameof(Iso639TestCollection))]
public class Iso639Part3NameIndexReaderTests
{
    private readonly Iso639TestFixture testFixture;

    public Iso639Part3NameIndexReaderTests(Iso639TestFixture testFixture)
    {
        this.testFixture = testFixture;
    }

    [Fact]
    public async Task ReadAllTestAsync()
    {
        // Arrange
        var options = this.testFixture.ServiceProvider.GetRequiredService<IOptions<Iso639TestOptions>>().Value;
        using var fileStream = File.OpenRead(options.Part3NameIndexFileName);
        using var reader = new Iso639TableReader<Iso639Part3NameIndexRecord>(fileStream);

        // Act
        var codes = await reader.ReadAllAsync();

        // Assert
        Assert.NotEmpty(codes);
    }
}
