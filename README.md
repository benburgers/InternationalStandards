# Introduction

This solution provides international standards for use in applications, interfaces and services.
The authors of this solution are going to the greatest extent to stay true to the standards as they have been adopted,
although it cannot be guaranteed that they will always be up to date.
Please refer to the official documentation and authority of the respective standard for the latest contents, in case of doubt.

# GitHub Sponsors

If you like my contributions, please have a look at my [GitHub Sponsors profile](https://github.com/sponsors/benburgers).
My open source contributions are available free of charge (but subject to licenses) and the contributions are made entirely in my free time, but sponsorship would be sincerely appreciated. Thank you.

# Packages

## ISO

The `BenBurgers.InternationalStandards.Iso` package contains standards of the International Organization for Standardization (ISO).

The *International Organization for Standardization* (*ISO*) is an international standard development organization composed of representatives from the national standards organizations of member countries.
The organization develops and publishes standardization in all technical and nontechnical fields other than electrical and electronic engineering.[^1]

[^1]: [Wikipedia](https://en.wikipedia.org/wiki/International_Organization_for_Standardization), downloaded at 31 October 2022, 23:33 CET.

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
```

## ISO JSON

The `BenBurgers.InternationalStandards.Iso.Json` package contains features for serializing and deserializing to and from JSON using the ISO standards.
The package provides, among other features, JSON converters that may be added to the serialization options in order to control the serialization and deserialization of ISO compliant data.

### ISO 3166

There are JSON Converters for ISO 3166 from and to the alpha-2 and alpha-3 codes as well as the numeric code.

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

### Supported Languages

The supported languages in the ISO packages are:

| ISO 639-1 | Name     |
| --------- | -------- |
|           | neutral  |
| en        | English  |
| fr        | French   |
| nl        | Dutch    |

More may be added in the future.