# Contents

- [Introduction](#Introduction)
- [GitHub Sponsors](#GitHub-Sponsors)
- [Packages](#Packages)
- [Manual](#Manual)
    - [Supported ISO standards](#Supported-ISO-standards)
        - [ISO 639 language codes](#ISO-639-language-codes)
        - [ISO 3166 country codes](#ISO-3166-country-codes)
        - [ISO 4217 currency codes](#ISO-4217-currency-codes)
        - [ISO 8601 date and time](#ISO-8601-date-and-time)
    - [Supported languages](#Supported-languages)

# Introduction

Thank you for choosing this package.

The `BenBurgers.InternationalStandards.Iso.IO` package contains JSON features for codes and features that belong to standards of the International Organization for Standardization (ISO).

> The *International Organization for Standardization* (*ISO*) is an international standard development organization composed of representatives from the national standards organizations of member countries.
> The organization develops and publishes standardization in all technical and nontechnical fields other than electrical and electronic engineering.[^1]

[^1]: [Wikipedia](https://en.wikipedia.org/wiki/International_Organization_for_Standardization), downloaded at 31 October 2022, 23:33 CET.

You are kindly encouraged to buy the standards you use at the [ISO Store](https://www.iso.org/store.html) in order to fund their mission.

# GitHub Sponsors

If you like my contributions, please have a look at my [GitHub Sponsors profile](https://github.com/sponsors/benburgers).
My open source contributions are available free of charge (but subject to licenses) and the contributions are made entirely in my free time, but sponsorship would be sincerely appreciated. Thank you.

If possible, please also buy a standard from the respective Maintenance Agency or ISO itself to cover the costs of the Maintenance Agencies and the ISO in maintaining the standards.

# Packages

These are the packages that concern the ISO standards:

| Name                                                     | Description                                                            |
| ---------------------------------------------------------|------------------------------------------------------------------------|
| `BenBurgers.InternationalStandards.Iso`                  | The main package with the codes and metadata.                          |
| `BenBurgers.InternationalStandards.Iso.EFCore`           | Features for storing codes using Entity Framework Core.                |
| `BenBurgers.InternationalStandards.Iso.EFCore.SqlServer` | Features for storing codes using Entity Framework Core and SQL Server. |
| `BenBurgers.InternationalStandards.Iso.IO`               | Features for reading Code Tables from authorities.                     |
| _**`BenBurgers.InternationalStandards.Iso.Json`**_       | _**Features for serializing and deserializing codes in JSON.**_        |

Please refer to [NuGet](https://www.nuget.org/profiles/benburgers) to download the packages and [GitHub](https://github.com/users/benburgers/projects/1) for the source code.

# Manual

## Supported ISO standards

The following are the currently supported ISO standards.

| Name                         | Description         |
| ---------------------------- | ------------------- |
| ISO 639                      | Language codes      |
| ISO 3166                     | Country codes       |
| ISO 4217                     | Currency codes      |

### ISO 639 language codes

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

### ISO 3166 country codes

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

### ISO 4217 currency codes

There are JSON Converters for ISO 4217 from and to the alpha-3 codes as well as the numeric code.
The converters can be used directly or in the JSON serializer from `System.Text.Json`.

#### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Json.Iso4217.Alpha;
using System.Text.Json;

const Iso4217Code Value = Iso4217Code.Euro;
var options = new Iso4217JsonConverterOptions();
var jsonConverter = new Iso4217AlphaJsonConverter(options);
using var stream = new MemoryStream();
using var writer = new Utf8JsonWriter(stream);

writer.WriteStartObject();
writer.WritePropertyName("Currency");
jsonConverter.Write(writer, Value, new JsonSerializerOptions());
writer.WriteEndObject();
writer.Flush();

/*
* The result will be:
*
* {"Currency":"EUR"}
*/
```

### ISO 8601 date and time

Each ISO 8601 value type has its own JSON converter.

- `Iso8601CalendarDateJsonConverter` for `Iso8601CalendarDate`.
- `Iso8601DateTimeJsonConverter` for `Iso8601DateTime`.
- `Iso8601OrdinalDateJsonConverter` for `Iso8601OrdinalDate`.
- `Iso8601TimeJsonConverter` for `Iso8601Time`.

## Supported Languages

The supported languages in the ISO packages are:

| ISO 639-1 | Name     |
| --------- | -------- |
|           | neutral  |
| en        | English  |
| fr        | French   |
| nl        | Dutch    |

More may be added in the future.