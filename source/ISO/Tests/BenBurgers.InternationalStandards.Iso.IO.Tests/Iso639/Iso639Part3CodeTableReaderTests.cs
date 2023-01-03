/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Tests.Iso639;

[Collection(nameof(Iso639TestCollection))]
public class Iso639Part3CodeTableReaderTests
{
    private readonly Iso639TestFixture testFixture;

    public Iso639Part3CodeTableReaderTests(Iso639TestFixture testFixture)
    {
        this.testFixture = testFixture;
    }

    [Fact(DisplayName = "ISO 639 Part 3 Code Table Reader reads the code table.")]
    public async Task ReadAllTestAsync()
    {
        // Arrange
        var options = this.testFixture.ServiceProvider.GetRequiredService<IOptions<Iso639TestOptions>>().Value;
        using var fileStream = File.OpenRead(options.Part3CodeTableFileName);
        using var reader = new Iso639TableReader<Iso639Part3CodeTableRecord>(fileStream);

        // Act
        var codes = await reader.ReadAllAsync();

        // Assert
        Assert.NotEmpty(codes);
    }
}
