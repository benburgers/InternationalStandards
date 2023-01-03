/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.IO.Iso3166;
using BenBurgers.InternationalStandards.Iso.IO.Iso3166.Xml;
using BenBurgers.InternationalStandards.Iso.Iso3166;
using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.IO.Tests.Iso3166.Xml;

[Collection(nameof(Iso3166TestCollection))]
public class Iso3166XmlReaderTests
{
    private readonly Iso3166TestFixture iso3166TestFixture;

    public static readonly IEnumerable<object?[]> ReadTestParameters =
        new[]
        {
            new object?[]
            {
                "BR",
                new Iso3166XmlDataSet(
                    Generated: DateTimeOffset.Parse("2022-11-29T16:24:21.045119+01:00"),
                    Countries: new HashSet<Iso3166XmlCountry>
                    {
                        new Iso3166XmlCountry(
                            new Alpha2("BR"),
                            78,
                            new Alpha2("BR"),
                            new Alpha3("BRA"),
                            76,
                            true,
                            Iso3166Status.OfficiallyAssigned,
                            new Iso3166XmlMultilingualName
                            {
                                { Iso639Code.English, "the Federative Republic of Brazil" },
                                { Iso639Code.French, "la République fédérative du Brésil" }
                            },
                            new Iso3166XmlMultilingualName
                            {
                                { Iso639Code.English, "Brazil" },
                                { Iso639Code.French, "Brésil (le)" },
                                { Iso639Code.Portuguese, "Brasil (o)" }
                            },
                            new Iso3166XmlMultilingualName
                            {
                                { Iso639Code.English, "BRAZIL" },
                                { Iso639Code.French, "BRÉSIL" },
                                { Iso639Code.Portuguese, "Brasil (o)" }
                            },
                            new Iso3166XmlLanguages
                            {
                                new Iso3166XmlLanguage(Iso639Code.English, false),
                                new Iso3166XmlLanguage(Iso639Code.French, false),
                                new Iso3166XmlLanguage(Iso639Code.Portuguese, true)
                            }),
                    })
            },
            new object?[]
            {
                "CH",
                new Iso3166XmlDataSet(
                    Generated: DateTimeOffset.Parse("2022-11-29T16:24:36.411743+01:00"),
                    Countries: new HashSet<Iso3166XmlCountry>
                    {
                        new Iso3166XmlCountry(
                            new Alpha2("CH"),
                            78,
                            new Alpha2("CH"),
                            new Alpha3("CHE"),
                            756,
                            true,
                            Iso3166Status.OfficiallyAssigned,
                            new Iso3166XmlMultilingualName
                            {
                                { Iso639Code.English, "the Swiss Confederation" },
                                { Iso639Code.French, "la Confédération suisse" }
                            },
                            new Iso3166XmlMultilingualName
                            {
                                { Iso639Code.German, "Schweiz (die)" },
                                { Iso639Code.English, "Switzerland" },
                                { Iso639Code.French, "Suisse (la)" },
                                { Iso639Code.Italian, "Svizzera (la)" },
                                { Iso639Code.Romansh, "Svizra (la)" }
                            },
                            new Iso3166XmlMultilingualName
                            {
                                { Iso639Code.German, "Schweiz (die)" },
                                { Iso639Code.English, "SWITZERLAND" },
                                { Iso639Code.French, "SUISSE" },
                                { Iso639Code.Italian, "Svizzera (la)" },
                                { Iso639Code.Romansh, "Svizra (la)" }
                            },
                            new Iso3166XmlLanguages
                            {
                                new Iso3166XmlLanguage(Iso639Code.German, true),
                                new Iso3166XmlLanguage(Iso639Code.English, false),
                                new Iso3166XmlLanguage(Iso639Code.French, true),
                                new Iso3166XmlLanguage(Iso639Code.Italian, true),
                                new Iso3166XmlLanguage(Iso639Code.Romansh, true)
                            })
                    })
            },
            new object?[]
            {
                "NZ",
                new Iso3166XmlDataSet(
                    Generated: DateTimeOffset.Parse("2022-11-29T16:24:27.101805+01:00"),
                    Countries: new HashSet<Iso3166XmlCountry>
                    {
                        new Iso3166XmlCountry(
                            new Alpha2("NZ"),
                            78,
                            new Alpha2("NZ"),
                            new Alpha3("NZL"),
                            554,
                            true,
                            Iso3166Status.OfficiallyAssigned,
                            new Iso3166XmlMultilingualName(),
                            new Iso3166XmlMultilingualName
                            {
                                { Iso639Code.English, "New Zealand" },
                                { Iso639Code.French, "Nouvelle-Zélande (la)" },
                                { Iso639Code.Maori, "Aotearoa" }
                            },
                            new Iso3166XmlMultilingualName
                            {
                                { Iso639Code.English, "NEW ZEALAND" },
                                { Iso639Code.French, "NOUVELLE-ZÉLANDE" },
                                { Iso639Code.Maori, "Aotearoa" }
                            },
                            new Iso3166XmlLanguages
                            {
                                new Iso3166XmlLanguage(Iso639Code.English, true),
                                new Iso3166XmlLanguage(Iso639Code.French, false),
                                new Iso3166XmlLanguage(Iso639Code.Maori, true)
                            })
                    })
            }
        };

    public Iso3166XmlReaderTests(Iso3166TestFixture iso3166TestFixture)
    {
        this.iso3166TestFixture = iso3166TestFixture;
    }

    [Theory(DisplayName = "ISO 3166 XML Reader test")]
    [MemberData(nameof(ReadTestParameters))]
    public void ReadTest(
        string code,
        Iso3166XmlDataSet expected)
    {
        // Arrange
        var options =
            this
                .iso3166TestFixture
                .ServiceProvider
                .GetRequiredService<IOptions<Iso3166TestOptions>>()
                .Value;
        var fileName = options.XmlFiles[code];
        using var fileStream = File.OpenRead(fileName);
        using var iso3166Reader = new Iso3166XmlReader(fileStream);

        // Act
        var actual = iso3166Reader.Read();

        // Assert
        Assert.NotNull(actual);
        foreach (var (expectedCountry, actualCountry) in expected.Countries.Zip(actual.Countries, (e, a) => (Expected: e, Actual: a)))
        {
            Assert.Equal(expectedCountry, actualCountry);
        }
    }

    [Theory(DisplayName = "ISO 3166 XML Reader test asynchronous")]
    [MemberData(nameof(ReadTestParameters))]
    public async Task ReadTestAsync(
        string code,
        Iso3166XmlDataSet expected)
    {
        // Arrange
        var options =
            this
                .iso3166TestFixture
                .ServiceProvider
                .GetRequiredService<IOptions<Iso3166TestOptions>>()
                .Value;
        var fileName = options.XmlFiles[code];
        using var fileStream = File.OpenRead(fileName);
        using var iso3166Reader = new Iso3166XmlReader(fileStream);

        // Act
        var actual = await iso3166Reader.ReadAsync();

        // Assert
        Assert.NotNull(actual);
        foreach (var (expectedCountry, actualCountry) in expected.Countries.Zip(actual.Countries, (e, a) => (Expected: e, Actual: a)))
        {
            Assert.Equal(expectedCountry, actualCountry);
        }
    }
}
