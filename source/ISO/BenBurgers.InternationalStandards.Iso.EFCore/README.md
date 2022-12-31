# Contents

- [Introduction](#Introduction)
- [GitHub Sponsors](#GitHub-Sponsors)
- [Packages](#Packages)
- [Manual](#Manual)
    - [Supported ISO standards](#Supported-ISO-standards)
        - [Alpha](#Alpha)
        - [ISO 639 language codes](#ISO-639-language-codes)
        - [ISO 3166 country codes](#ISO-3166-country-codes)
        - [ISO 4217 currency codes](#ISO-4217-currency-codes)
        - [ISO 8601 date and time](#ISO-8601-date-and-time)

# Introduction

Thank you for choosing this package.

The `BenBurgers.InternationalStandards.Iso.EFCore` package contains Entity Framework Core features for codes and features that belong to standards of the International Organization for Standardization (ISO).

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
| _**`BenBurgers.InternationalStandards.Iso.EFCore`**_     | _**Features for storing codes using Entity Framework Core.**_          |
| `BenBurgers.InternationalStandards.Iso.EFCore.SqlServer` | Features for storing codes using Entity Framework Core and SQL Server. |
| `BenBurgers.InternationalStandards.Iso.IO`               | Features for reading Code Tables from authorities.                     |
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
| ISO 8601                     | Date and time       |

### Alpha

This package contains Entity Framework Core value converters for Alpha codes.
The converters and their options are in the `BenBurgers.InternationalStandards.Iso.EFCore.Storage.ValueConversion` namespace.

### ISO 639 language codes

This package contains Entity Framework Core value converters for ISO 639 language codes.
The converters and their options are in the namespaces:

- `BenBurgers.InternationalStandards.Iso.EFCore.Iso639.Storage.ValueConversion.Alpha`

### ISO 3166 country codes

This package contains Entity Framework Core value converters for ISO 3166 country codes.
The converters and their options are in the namespaces:

- `BenBurgers.InternationalStandards.Iso.EFCore.Iso3166.Storage.ValueConversion.Alpha`
- `BenBurgers.InternationalStandards.Iso.EFCore.Iso3166.Storage.ValueConversion.Numeric`

### ISO 4217 currency codes

This package contains Entity Framework Core value converters for ISO 4217 currency codes.
The converters and their options are in the namespaces:

- `BenBurgers.InternationalStandards.Iso.EFCore.Iso4217.Storage.ValueConversion.Alpha`
- `BenBurgers.InternationalStandards.Iso.EFCore.Iso4217.Storage.ValueConversion.Numeric`

### ISO 8601 date and time

The value converters for ISO 8601 date and time are in the following namespace:

- `BenBurgers.InternationalStandars.Iso.EFCore.Iso8601.Storage.ValueConversion`