/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;
using BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601OrdinalDateTests
{
    public static readonly IEnumerable<object?[]> ConstructorParameters =
        new[]
        {
            new object?[] { 2022, 20 },
            new object?[] { 2023, 10 }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: Constructor")]
    [MemberData(nameof(ConstructorParameters))]
    public void ConstructorTests(int year, ushort dayOfYear)
    {
        var ordinalDate = new Iso8601OrdinalDate(year, dayOfYear);
        Assert.Equal(year, ordinalDate.Year);
        Assert.Equal(dayOfYear, ordinalDate.DayOfYear);
    }

    public static readonly IEnumerable<object?[]> ConstructorOutOfRangeParameters =
        new[]
        {
            new object?[] { 2023, 367 },
            new object?[] { 2020, 388 }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: Constructor out of range")]
    [MemberData(nameof(ConstructorOutOfRangeParameters))]
    public void ConstructorOutOfRangeTests(int year, ushort dayOfYear)
    {
        Assert.Throws<Iso8601OrdinalDateOutOfRangeException>(() => new Iso8601OrdinalDate(year, dayOfYear));
    }
}
