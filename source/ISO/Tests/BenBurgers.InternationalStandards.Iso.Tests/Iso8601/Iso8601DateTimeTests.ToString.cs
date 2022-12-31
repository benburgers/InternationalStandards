/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601DateTimeTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[] { new Iso8601DateTime(new Iso8601CalendarDate(2023, 2, 3)), "2023-02-03" },
            new object?[] { new Iso8601DateTime(new Iso8601Time(23, 10, 5)), "23:10:05" },
            new object?[] { new Iso8601DateTime(new Iso8601CalendarDate(2023, 2, 3), new Iso8601Time(23, 10, 5)), "2023-02-03T23:10:05" }
        };

    [Theory(DisplayName = "Iso8601DateTime :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(Iso8601DateTime dateTime, string expected)
    {
        var actual = dateTime.ToString();
        Assert.Equal(expected, actual);
    }
}
