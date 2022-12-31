# Contents

- [Introduction](#Introduction)
- [GitHub Sponsors](#GitHub-Sponsors)
- [Packages](#Packages)
- [Manual](#Manual)
    - [Supported ISO standards](#Supported-ISO-standards)
        - [ISO 639 language codes](#ISO-639-language-codes)
        - [ISO 3166 country codes](#ISO-3166-country-codes)
        - [ISO 4217 currency codes](#ISO-4217-currency-codes)
        - [Comparers](#Comparers)
        - [ISO 8601 date and time](#ISO-8601-date-and-time)

# Introduction

Thank you for choosing this package.

The `BenBurgers.InternationalStandards.Iso` package contains codes and features that belong to standards of the International Organization for Standardization (ISO).

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
| _**`BenBurgers.InternationalStandards.Iso`**_            | _**The main package with the codes and metadata.**_                    |
| `BenBurgers.InternationalStandards.Iso.EFCore`           | Features for storing codes using Entity Framework Core.                |
| `BenBurgers.InternationalStandards.Iso.EFCore.SqlServer` | Features for storing codes using Entity Framework Core and SQL Server. |
| `BenBurgers.InternationalStandards.Iso.IO`               | Features for reading Code Tables from authorities.                     |
| `BenBurgers.InternationalStandards.Iso.Json`             | Features for serializing and deserializing codes in JSON.              |

Please refer to [NuGet](https://www.nuget.org/profiles/benburgers) to download the packages and [GitHub](https://github.com/users/benburgers/projects/1) for the source code.

# Manual

## Supported ISO standards

The following are the currently supported ISO standards.

| Name                         | Description              |
| ---------------------------- | ------------------------ |
| ISO 639                      | Language codes           |
| ISO 3166                     | Country codes            |
| ISO 4217                     | Currency codes           |
| ISO 8601                     | Date and Time formatting |

### ISO 639 language codes

#### Legal

The [Austrian Standards](https://www.austrian-standards.at/en) is the Maintenance Agency of ISO 639-1 codes.
Only they can designate ISO 639-1 codes.
This work is a derivation and enhancement and anything other than ISO 639-1 is the responsibility of the respective copyright holders.

The [Library of Congress](https://www.loc.gov/standards/iso639-2/) is the Maintenance Agency of ISO 639-2 codes.
Only they can designate ISO 639-2 codes.
This work is a derivation and enhancement and anything other than ISO 639-2 is the responsibility of the respective copyright holders.

The [SIL International](https://www.iso639-3.sil.org) is the Maintenance Agency of ISO 639-3 codes.
Only they can designate ISO 639-3 codes.
This work is a derivation and enhancement and anything other than ISO 639-3 is the responsibility of the respective copyright holders.

The ISO 639-3 codes in this version are effective from **11 March 2022** until the Maintenance Agency publishes new codes.

#### Codes

The `Iso639Code` enum in the `BenBurgers.InternationalStandards.Iso.Iso639` namespace defines the codes from the ISO 639 language codes standard.
In order to effectively store, read, write and transfer the codes, extension methods have been made available in `Iso639CodeExtensions`.

##### Part 1

Before requesting a value for ISO 639-1, it is possible to request whether a Part 1 code has been designated by calling the `HasPart1` method.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso639;

const Iso639Code Value = Iso639Code.Mayan_Epigraphic;
var hasPart1 = Value.HasPart1(allowDeprecated: true); // false
Console.Write(hasPart1.ToString());

/*
* Output:
* 
* false
*/
```

The method `ToPart1` returns the Alpha-2 code for ISO 639-1 or `null` if it has not been designated or deprecated if deprecated codes are not allowed.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso639;

const Iso639Code Value = Iso639Code.English;
var part1 = Value.ToPart1(allowDeprecated: true); // en
Console.Write(part1);

/*
* Output:
* 
* en
*/
```

##### Part 2

Before requesting a value for ISO 639-2T or ISO 639-2B, it is possible to request whether a Part 2 code has been designated by calling the `HasPart2` method.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso639;

const Iso639Code Value = Iso639Code.Dutch_Flemish;
var hasPart2 = Value.HasPart2(); // true
Console.Write(hasPart2.ToString());

/*
* Output:
* 
* true
*/
```

The method `ToPart2` returns the Alpha-3 code for either ISO 639-2T or ISO 639-2B, or `null` if it has not been designated or deprecated if deprecated codes are not allowed.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso639;

const Iso639Code Value = Iso639Code.French;
var part2T = Value.ToPart2(Iso639Part2Type.Terminological); // fra
var part2B = Value.ToPart2(Iso639Part2Type.Bibliographic); // fre
Console.WriteLine(part2T);
Console.WriteLine(part2B);

/*
* Output:
*
* fra
* fre
*/
```

##### Part 3

Before requesting a value for ISO 639-3, it is possible to request whether a Part 3 code has been designated by calling the `HasPart3` method.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso639;

const Iso639Code Value = Iso639Code.Frisian_Western;
var hasPart3 = Value.HasPart3(); // true
Console.Write(hasPart3.ToString());

/*
* Output:
*
* true
*/
```

The method `ToPart3` returns the Alpha-3 code for ISO 639-3, or `null` if it has not been designated or deprecated if deprecated codes are not allowed.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso639;

const Iso639Code Value = Iso639Code.Hindi;
var part3 = Value.ToPart3(); // hin
Console.Write(part3);

/*
* Output:
*
* hin
*/
```

##### Model

For requesting a code's metadata all at once, the method `ToModel` returns a record containing the metadata.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso639;

const Iso639Code Value = Iso639Code.Hittite;
var (part1, part2T, part2B, part3, scope, languageType, refName, printName, invertedName) = Value.ToModel();
Console.WriteLine(part2T);
Console.WriteLine(part2B);
Console.WriteLine(part3);
Console.WriteLine(scope.ToString());
Console.WriteLine(languageType.ToString());

/*
* Output:
*
* hit
* hit
* hit
* Individual
* Ancient
*/
```

##### Language Type

The ISO 639 standard defines the following language types:

| Name                  |
| --------------------- |
| Ancient               |
| Constructed           |
| Extinct               |
| Genetic               |
| GeneticAncient        |
| GeneticLike           |
| Geographic            |
| Historical            |
| Living                |
| Special               |

For their descriptions and usages, please refer to [SIL International's page about language types](https://iso639-3.sil.org/about/types).

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso639;

const Iso639Code Value = Iso639Code.Indonesian;
var languageType = Value.GetLanguageType(); // Iso639LanguageType.Living
Console.Write(languageType.ToString());

/*
* Output:
* 
* Living
*/
```

##### From text

Converting a code from text is possible with the `ToIso639` and `TryToIso639` extension methods on `string`.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso639;

const string Value = "hke";
var code = Value.ToIso639(); // Iso639Code.Hunde
Console.Write(code.ToString());

/*
* Output:
*
* Hunde
*/
```

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso639;

const string Value = "yyy"
if (Value.TryToIso639(out var code)) {
    Console.WriteLine("Valid");
    Console.WriteLine(code!.ToString());
} else {
    Console.Write("Invalid");
}

/*
* Output:
*
* Invalid
*/
```

### ISO 3166 country codes

#### Legal

The [ISO 3166 Maintenance Agency](https://www.iso.org/iso-3166-country-codes.html) is the sole authority of ISO 3166 codes.
Only they can designate ISO 3166 codes.
This work is a derivation and enhancement and anything other than the ISO 3166 codes is the responsibility of the respective copyright holders.

#### Codes

The `Iso3166Code` enum in the `BenBurgers.InternationalStandards.Iso.Iso3166` namespace defines the codes from the ISO 3166 country codes standard.
In order to effectively store, read, write and transfer the codes, extension methods have been made available in `Iso3166CodeExtensions`.

##### Alpha-2

To request the Alpha-2 two-letter code for ISO 3166 codes, the `ToAlpha2` method may be called.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso3166;

const Iso3166Code Value = Iso3166Code.Thailand;
var alpha2 = Value.ToAlpha2(); // TH
Console.Write(alpha2);

/*
* Output:
*
* TH
*/
```

##### Alpha-3

To request the Alpha-3 three-letter code for ISO 3166 codes, the `ToAlpha3` method may be called.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso3166;

const Iso3166Code Value = Iso3166Code.Tuvalu;
var alpha3 = Value.ToAlpha3();
Console.Write(alpha3);

/*
* Output:
*
* TUV
*/
```

##### Numeric

The numeric value of ISO 3166 codes is the integer value of the `enum` field.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso3166;

const Iso3166Code Value = Iso3166Code.UnitedStatesOfAmerica;
var numeric = (int)Value; // 840
Console.Write(numeric.ToString());

/*
* Output:
*
* 840
*/
```

##### Model

For requesting a code's metadata all at once, the method `ToModel` returns a record containing the metadata.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso3166;

const Iso3166Code Value = Iso3166Code.Ukraine;
var (numeric, alpha2, alpha3) = Value.ToModel();
Console.WriteLine(numeric.ToString());
Console.WriteLine(alpha2.Value);
Console.WriteLine(alpha3.Value);

/*
* Output:
*
* 804
* UA
* UKR
*/
```

##### Name

The extension method `GetName` provides a localized name (in one of the supported cultures of the packages) for the country.
These names are not part of the ISO 3166 standard, but provided by the package itself.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso3166;
using System.Globalization;

const Iso3166Code Value = Iso3166Code.Bhutan;
var culture = new CultureInfo("fr");
var name = Value.GetName(culture, Iso3166NameVariant.Long); // royaume du Bhoutan
Console.Write(name);

/*
* Output:
*
* royaume du Bhoutan
*/
```

##### From text

The `ToIso3166` and `TryToIso3166` methods convert a code from `string` to the `enum` value.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso3166;

const string Value = "ZM";
var code = Value.ToIso3166(); // Iso3166Code.Zambia
Console.WriteLine(code.ToString());

/*
* Output:
*
* Zambia
*/
```

Using `TryToIso3166`:

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso3166;

const string Value = "AAA";
if (Value.TryToIso3166(out var code)) {
    Console.WriteLine("Valid");
    Console.WriteLine(code!.ToString());
} else {
    Console.Write("Invalid");
}

/*
* Output:
*
* Invalid
*/
```

### ISO 4217 currency codes

#### Legal

The [SIX Financial Information AG](https://www.six-group.com/en/products-services/financial-information/data-standards.html) is the Maintenance Agency of ISO 4217 codes.
Only they can designate ISO 4217 codes.
This work is a derivation and enhancement and anything other than the ISO 4217 codes is the responsibility of the respective copyright holders.

The ISO 4217 codes in this version were published at **23 September 2022**.

#### Codes

The `Iso4217Code` enum in the `BenBurgers.InternationalStandards.Iso.Iso4217` namespace defines the codes from the ISO 4217 currency codes standard.
In order to effectively store, read, write and transfer the codes, extension methods have been made available in `Iso4217CodeExtensions`.

##### Alpha-3

To retrieve the Alpha-3 three-letter code of the ISO 4217 code, one may call the method `ToAlpha`.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso4217;

const Iso4217Code Value = Iso4217Code.Euro;
var alpha = Value.ToAlpha(); // EUR
Console.Write(alpha);

/*
* Output:
*
* EUR
*/
```

##### Numeric

The ISO 4217 numeric code is the integer value.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso4217;

const Iso4217Code Value = Iso4217Code.USDollar;
var numeric = (int)Value; // 840
Console.Write(numeric.ToString());

/*
* Output:
*
* 840
*/
```

##### Model

A model with all metadata can be requested with the method `ToModel`.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso4217;

const Iso4217Code Value = Iso4217Code.PoundSterling;
var model = Value.ToModel();
Console.WriteLine(model.CurrencyName);
Console.WriteLine(model.Currency!.Value);
Console.WriteLine(model.CurrencyNumber.ToString());
Console.WriteLine(model.CurrencyMinorUnits!.ToString());
Console.WriteLine(string.Join(", ", model.Entities));

/*
* Output:
*
* Pound Sterling
* GBP
* 826
* 2
* GUERNSEY, ISLE OF MAN, JERSEY, UNITED KINGDOM OF GREAT BRITAIN AND NORTHERN IRELAND (THE)
*/
```

##### Entities

The method `GetEntities` returns the entities that trade a currency.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso4217;

const Iso4217Code Value = Iso4217Code.IndianRupee;
var entities = Value.GetEntities();
Console.Write(string.Join(", ", entities));

/*
* Output:
*
* BHUTAN, INDIA
*/
```

##### Reference Name

To get an ISO 4217 code's reference name, the method `GetReferenceName` may be called.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso4217;

const Iso4217Code Value = Iso4217Code.IcelandKrona;
var referenceName = Value.GetReferenceName(); // "Iceland Krona"
Console.Write(referenceName);

/*
* Output:
*
* Iceland Krona
*/
```

##### Minor Units

A currency may also have a number of digits as decimals. The method `GetMinorUnits` returns that number, if applicable and available.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso4217;

const Iso4217Code Value = Iso4217Code.JamaicanDollar;
var minorUnits = Value.GetMinorUnits(); // 2
Console.Write(minorUnits!.ToString());

/*
* Output:
*
* 2
*/
```

##### From text

The methods `ToIso4217` and `TryToIso4217` may be called on a `string` to convert a three-letter text to the ISO 4217 code.

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso4217;

const string Value = "JPY";
var code = Value.ToIso4217(); // Iso4217Code.Yen;
Console.Write(code.ToString());

/*
* Output:
*
* Yen
*/
```

Using `TryToIso4217`:

###### Example

```csharp
using BenBurgers.InternationalStandards.Iso.Iso4217;

const string Value = "AAA";
if (Value.TryToIso4217(out var code)) {
    Console.WriteLine("Valid");
    Console.WriteLine(code!.ToString());
} else {
    Console.Write("Invalid");
}

/*
* Output:
*
* Invalid
*/
```

### Comparers

All ISO codes have comparers.
These can be found in the namespaces.

- `BenBurgers.InternationalStandards.Iso.Iso3166.Comparers`
- `BenBurgers.InternationalStandards.Iso.Iso4217.Comparers`
- `BenBurgers.InternationalStandards.Iso.Iso639.Comparers`

A useful application could be in a `SortedDictionary<...>` with the ISO code as its items.

### ISO 8601 date and time

The ISO 8601 standard describes how dates and times (or a combination thereof) are formatted.

The `BenBurgers.InternationalStandards.Iso.Iso8601` namespace contains the following value types:

- `Iso8601CalendarDate`
- `Iso8601OrdinalDate`
- `Iso8601Time`
- `Iso8601DateTime`

Please review the [official ISO 8601 standard](https://www.iso.org/iso-8601-date-and-time-format.html) for more information.
This is the only authority that maintains the standard.

The value types support conversion from and to the .NET value types for times and dates by means of explicit casting or the methods provided.

The `ToString` and (static) `Parse`/`TryParse` methods provide ways to print or read the formatted values.

#### ISO 8601 Calendar Date

An ISO 8601 Calendar Date may have the following format: `2023-02-02` (`yyyy-MM-dd`).
From the least significant up to the most significant component, components may be omitted, such as `2023-02` and `2023`.
The year is the only required component.

#### ISO 8601 Ordinal Date

An ISO 8601 Ordinal Date may have the following format: `2023-10` (`yyyy-DDD`).
In this case the latter component is the day of the year, rather than month and day of month.

#### ISO 8601 Time

An ISO 8601 Time may have the following format: `23:10:05,0123+02:00` (`HH:mm:ss,ssss+HH:mm`).
It is comprised of an hour, minute, second, fraction and UTC offset to indicate the time zone.
As with the date, the least significant components may be omitted in order.
The time zone may be included or omitted in any case.
A special case of the time zone is the letter `Z` instead of `+02:00` or `-03:30`. The `Z` indicates the UTC time and is used instead of `+00:00`.

#### ISO 8601 Date and Time

The ISO 8601 Date and Time combination combines the Date and Time components as described above.
If both are specified, they will be separated by the letter `T`; e.g. `2023-02-02T23:10:05,0123+02:00`.