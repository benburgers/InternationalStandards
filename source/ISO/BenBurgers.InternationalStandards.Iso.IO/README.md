# Contents

- [Introduction](#Introduction)
- [GitHub Sponsors](#GitHub-Sponsors)
- [Packages](#Packages)
- [Manual](#Manual)
    - [Supported ISO standards](#Supported-ISO-standards)
    - [ISO 639 language codes](#ISO-639-language-codes)
    - [ISO 3166 country codes](#ISO-3166-country-codes)
    - [ISO 4217 currency codes](#ISO-4217-currency-codes)

# Introduction

Thank you for choosing this package.

The `BenBurgers.InternationalStandards.Iso.IO` package contains I/O features for codes and features that belong to standards of the International Organization for Standardization (ISO).

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
| _**`BenBurgers.InternationalStandards.Iso.IO`**_         | _**Features for reading Code Tables from authorities.**_               |
| `BenBurgers.InternationalStandards.Iso.Json`             | Features for serializing and deserializing codes in JSON.              |

Please refer to [NuGet](https://www.nuget.org/profiles/benburgers) to download the packages and [GitHub](https://github.com/users/benburgers/projects/1) for the source code.

# Manual

## Supported ISO standards

The following are the currently supported ISO standards.

| Name                         | Description         |
| ---------------------------- | ------------------- |
| ISO 639                      | Language codes      |
| ISO 3166                     | Country codes       |
| ISO 4217                     | Currency codes      |

## ISO 639 language codes

ISO 639 language codes are read from a tabular file, which may be found at [SIL International](https://iso639-3.sil.org/code_tables/download_tables).
The `Iso639TableReader` reads the relevant records.
Each tabular file has their own record type. The record types are mapped to the column names and their respective values.
The reader and record types may be found in the namespace:

- `BenBurgers.InternationalStandards.Iso.IO.Iso639`

## ISO 3166 country codes

The ISO 3166 country codes are read from an XML file, a sample of which may be downloaded from the ISO 3166 Maintenance Agency website.
The current codes have been collected from the [ISO Online Browsing Platform (OBP)](https://www.iso.org/obp/ui), although XML and CSV formats exist and may be bought from the ISO store.

- `BenBurgers.InternationalStandards.Iso.IO.Iso3166`

## ISO 4217 currency codes

ISO 4217 currency codes are read from an XML file, which may be found at [SIX Financial Information AG](https://www.six-group.com/en/products-services/financial-information/data-standards.html).
The `Iso4217ListOneXmlReader` reads List One.
List Two and List Three are not supported yet.
The reader and record types may be found in the namespace:

- `BenBurgers.InternationalStandards.Iso.IO.Iso4217`