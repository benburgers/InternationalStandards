# Introduction

The collection of packages to which this package belongs contain codes, features and tools for standards of the International Organization for Standardization (ISO).

> The *International Organization for Standardization* (*ISO*) is an international standard development organization composed of representatives from the national standards organizations of member countries.
> The organization develops and publishes standardization in all technical and nontechnical fields other than electrical and electronic engineering.[^1]

[^1]: [Wikipedia](https://en.wikipedia.org/wiki/International_Organization_for_Standardization), downloaded at 31 October 2022, 23:33 CET.

# GitHub Sponsors

If you like my contributions, please have a look at my [GitHub Sponsors profile](https://github.com/sponsors/benburgers).
My open source contributions are available free of charge (but subject to licenses) and the contributions are made entirely in my free time, but sponsorship would be sincerely appreciated. Thank you.

# Packages

| Name                                         | Description                                        |
| ---------------------------------------------|----------------------------------------------------|
| `BenBurgers.InternationalStandards.Iso`      | The main package with the codes and metadata.      |
| `BenBurgers.InternationalStandards.Iso.IO`   | Features for reading Code Tables from authorities. |
| `BenBurgers.InternationalStandards.Iso.Json` | Features for serializing and deserializing JSON.   |

## BenBurgers.InternationalStandards.Iso

The currently supported ISO standards are:

| Name                         | Description         |
| ---------------------------- | ------------------- |
| ISO 639                      | Language codes      |
| ISO 3166                     | Country codes       |

### ISO 639

The ISO 639 standard defines language codes. The list of language codes may include "nl" (ISO 639-1) for Dutch / Flemish, or "ara" (ISO 639-3) for Arabic.

The ISO 639-1 (Part 1) code is a two-letter code.

The ISO 639-2T (Part 2, Terminological) code is a three-letter code.

The ISO 639-2B (Part 2, Bibliographic) code is a three-letter code.

The ISO 639-3 (Part 3) code is a three-letter code.

#### Example
```csharp
var albanian = Iso639Code.Albanian;
var part1 = albanian.ToPart1(); // sq
var part2T = albanian.ToPart2(Iso639Part2Type.Terminological); // sqi
var part2B = albanian.ToPart2(Iso639Part2Type.Bibliographic); // alb
var part3 = albanian.ToPart3(); // alb
```

### ISO 3166

The ISO 3166 standard defines country codes. The list of country codes may include AQ for Antarctica, or NL for the Netherlands.

The Alpha-2 code is a two-letter code as previously mentioned.

The Alpha-3 code is a three-letter code.

There is also a numeric code, which is unique for every country.

#### Example
```csharp
using System.Globalization;
using BenBurgers.InternationalStandards.Iso.Iso3166;

var antarctica = Iso3166Code.Antarctica;
var alpha2 = antarctica.ToAlpha2(); // "AQ"
var alpha3 = antarctica.ToAlpha3(); // "ATA"
var numeric = (int)antarctica; // 010

var cultureInfo = new CultureInfo("fr");
var nameShort = antarctica.GetName(Iso3166NameVariant.Short, cultureInfo); // "Antarctique"
var nameLong = antarctica.GetName(Iso3166NameVariant.Long, cultureInfo); // "Antarctique"

var fromString2 = "AQ".ToIso3166(); // Iso3166Code.Antarctica
var fromString3 = "ATA".ToIso3166(); // Iso3166Code.Antarctica
```

## BenBurgers.InternationalStandards.Iso.Json

The `BenBurgers.InternationalStandards.Iso.Json` package contains features for serializing and deserializing to and from JSON using the ISO standards.
The package provides, among other features, JSON converters that may be added to the serialization options in order to control the serialization and deserialization of ISO compliant data.

### ISO 639

There are JSON Converters for ISO 639 from and to the ISO 639-1, ISO 639-2T, ISO 639-2B and ISO 639-3 codes.
The converters can be used directly, like in the example below, or in the JSON serializer from `System.Text.Json`.

#### Example
```csharp
const Iso639Code Value = Iso639Code.Albanian;
var options = new Iso639JsonConverterOptions(Iso639AlphaMode.Part2T);
var jsonConverter = new Iso639AlphaJsonConverter(options);
using var stream = new MemoryStream();
using var utf8JsonWriter = new Utf8JsonWriter(stream);

utf8JsonWriter.WriteStartObject();
utf8JsonWriter.WritePropertyName("Albanian");
jsonConverter.Write(utf8JsonWriter, Value, new JsonSerializerOptions());
utf8JsonWriter.WriteEndObject();
utf8JsonWriter.Flush();

/*
* The result will be:
*
* {"Albanian":"sqi"}
*/
```

### ISO 3166

There are JSON Converters for ISO 3166 from and to the alpha-2 and alpha-3 codes as well as the numeric code.
The converters can be used directly, like in the example below, or in the JSON serializer from `System.Text.Json`.

#### Example
```csharp
using BenBurgers.InternationalStandards.Iso.Iso3166;
using BenBurgers.InternationalStandards.Iso.Json.Iso3166.Alpha;
using System.Text.Json;

const Iso3166Code Value = Iso3166Code.Antarctica;
var options = new Iso3166JsonConverterOptions(Iso3166AlphaMode.Alpha2);
var jsonConverter = new Iso3166AlphaJsonConverter(options);
using var stream = new MemoryStream();
using var writer = new Utf8JsonWriter(stream);

writer.WriteStartObject();
writer.WritePropertyName("Antarctica");
jsonConverter.Write(writer, Value, new JsonSerializerOptions());
writer.WriteEndObject();
writer.Flush();

/*
* The result will be:
*
* {"Antarctica":"AQ"}
*/
```

## Supported Languages

The supported languages in the ISO packages are:

| ISO 639-1 | Name     |
| --------- | -------- |
|           | neutral  |
| en        | English  |
| fr        | French   |
| nl        | Dutch    |

More may be added in the future.