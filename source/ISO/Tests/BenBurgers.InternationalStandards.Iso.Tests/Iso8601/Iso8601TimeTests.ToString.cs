/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601TimeTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[] { new Iso8601Time(23), "23" },
            new object?[] { new Iso8601Time(23, simple: true), "23" },
            new object?[] { new Iso8601Time(23, TimeSpan.Zero), "23Z" },
            new object?[] { new Iso8601Time(23, TimeSpan.Zero, simple: true), "23Z" },
            new object?[] { new Iso8601Time(23, TimeSpan.FromHours(2)), "23+02:00" },
            new object?[] { new Iso8601Time(23, TimeSpan.FromHours(-3), simple: true), "23-0300" },
            new object?[] { new Iso8601Time(23, 50), "23:50" },
            new object?[] { new Iso8601Time(23, 50, simple: true), "2350" },
            new object?[] { new Iso8601Time(23, 50, TimeSpan.Zero), "23:50Z" },
            new object?[] { new Iso8601Time(23, 50, TimeSpan.Zero, simple: true), "2350Z" },
            new object?[] { new Iso8601Time(23, 50, TimeSpan.FromHours(-2)), "23:50-02:00" },
            new object?[] { new Iso8601Time(23, 50, TimeSpan.FromHours(3), simple: true), "2350+0300" },
            new object?[] { new Iso8601Time(23, 50, 10), "23:50:10" },
            new object?[] { new Iso8601Time(23, 50, 10, simple: true), "235010" },
            new object?[] { new Iso8601Time(23, 50, 10, TimeSpan.Zero), "23:50:10Z" },
            new object?[] { new Iso8601Time(23, 50, 10, TimeSpan.Zero, simple: true), "235010Z" },
            new object?[] { new Iso8601Time(23, 50, 10, TimeSpan.FromHours(2)), "23:50:10+02:00" },
            new object?[] { new Iso8601Time(23, 50, 10, TimeSpan.FromHours(-3), simple: true), "235010-0300" },
            new object?[] { new Iso8601Time(23, 50, 10, 0.123m), "23:50:10,123" },
            new object?[] { new Iso8601Time(23, 50, 10, 0.123m, simple: true), "235010,123" },
            new object?[] { new Iso8601Time(23, 50, 10, 0.123m, TimeSpan.Zero), "23:50:10,123Z" },
            new object?[] { new Iso8601Time(23, 50, 10, 0.123m, TimeSpan.Zero, simple: true), "235010,123Z" },
            new object?[] { new Iso8601Time(23, 50, 10, 0.123m, TimeSpan.FromHours(-2)), "23:50:10,123-02:00" },
            new object?[] { new Iso8601Time(23, 50, 10, 0.123m, TimeSpan.FromHours(3), simple: true), "235010,123+0300" }
        };

    [Theory(DisplayName = "Iso8601Time :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(Iso8601Time time, string expected)
    {
        var actual = time.ToString();
        Assert.Equal(expected, actual);
    }
}
