/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

/// <summary>
/// An ISO 8601 Time.
/// </summary>
public readonly partial struct Iso8601Time : IIso8601TimeValue
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601Time" />.
    /// </summary>
    public Iso8601Time()
    {
        var now = DateTime.UtcNow;
        this.Hour = (byte)now.Hour;
        this.Minute = (byte)now.Minute;
        this.Second = (byte)now.Second;
#if NET6_0
        this.Fraction = now.Millisecond / 1000m;
#endif
#if NET7_0_OR_GREATER
        this.Fraction = now.Microsecond / 10000m;
#endif
        this.UtcOffset = null;
        this.Simple = false;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="hour">The hour.</param>
    /// <param name="simple">A value that indicates whether the ISO 8601 Time has a simple representation.</param>
    /// <exception cref="Iso8601TimeOutOfRangeException">
    /// An <see cref="Iso8601TimeOutOfRangeException" /> is thrown if any of the components is out of the accepted range of ISO 8601 Time values.
    /// </exception>
    public Iso8601Time(byte hour, bool simple = false)
    {
        this.Hour = hour;
        this.Minute = null;
        this.Second = null;
        this.Fraction = null;
        this.UtcOffset = null;
        this.Simple = simple;
        this.ValidateHour();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="hour">The hour.</param>
    /// <param name="utcOffset">The UTC offset.</param>
    /// <param name="simple">A value that indicates whether the ISO 8601 Time has a simple representation.</param>
    /// <exception cref="Iso8601TimeOutOfRangeException">
    /// An <see cref="Iso8601TimeOutOfRangeException" /> is thrown if any of the components is out of the accepted range of ISO 8601 Time values.
    /// </exception>
    public Iso8601Time(byte hour, TimeSpan utcOffset, bool simple = false)
    {
        this.Hour = hour;
        this.Minute = null;
        this.Second = null;
        this.Fraction = null;
        this.UtcOffset = utcOffset;
        this.Simple = simple;
        this.ValidateHour();
        this.ValidateUtcOffset();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="hour">The hour.</param>
    /// <param name="minute">The minute.</param>
    /// <param name="simple">A value that indicates whether the ISO 8601 Time has a simple representation.</param>
    /// <exception cref="Iso8601TimeOutOfRangeException">
    /// An <see cref="Iso8601TimeOutOfRangeException" /> is thrown if any of the components is out of the accepted range of ISO 8601 Time values.
    /// </exception>
    public Iso8601Time(byte hour, byte minute, bool simple = false)
    {
        this.Hour = hour;
        this.Minute = minute;
        this.Second = null;
        this.Fraction = null;
        this.UtcOffset = null;
        this.Simple = simple;
        this.ValidateHour();
        this.ValidateMinute();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="hour">The hour.</param>
    /// <param name="minute">The minute.</param>
    /// <param name="utcOffset">The UTC offset.</param>
    /// <param name="simple">A value that indicates whether the ISO 8601 Time has a simple representation.</param>
    /// <exception cref="Iso8601TimeOutOfRangeException">
    /// An <see cref="Iso8601TimeOutOfRangeException" /> is thrown if any of the components is out of the accepted range of ISO 8601 Time values.
    /// </exception>
    public Iso8601Time(byte hour, byte minute, TimeSpan utcOffset, bool simple = false)
    {
        this.Hour = hour;
        this.Minute = minute;
        this.Second = null;
        this.Fraction = null;
        this.UtcOffset = utcOffset;
        this.Simple = simple;
        this.ValidateHour();
        this.ValidateMinute();
        this.ValidateUtcOffset();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="hour">The hour.</param>
    /// <param name="minute">The minute.</param>
    /// <param name="second">The second.</param>
    /// <param name="simple">A value that indicates whether the ISO 8601 Time has a simple representation.</param>
    /// <exception cref="Iso8601TimeOutOfRangeException">
    /// An <see cref="Iso8601TimeOutOfRangeException" /> is thrown if any of the components is out of the accepted range of ISO 8601 Time values.
    /// </exception>
    public Iso8601Time(byte hour, byte minute, byte second, bool simple = false)
    {
        this.Hour = hour;
        this.Minute = minute;
        this.Second = second;
        this.Fraction = null;
        this.UtcOffset = null;
        this.Simple = simple;
        this.ValidateHour();
        this.ValidateMinute();
        this.ValidateSecond();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="hour">The hour.</param>
    /// <param name="minute">The minute.</param>
    /// <param name="second">The second.</param>
    /// <param name="utcOffset">The UTC offset.</param>
    /// <param name="simple">A value that indicates whether the ISO 8601 Time has a simple representation.</param>
    /// <exception cref="Iso8601TimeOutOfRangeException">
    /// An <see cref="Iso8601TimeOutOfRangeException" /> is thrown if any of the components is out of the accepted range of ISO 8601 Time values.
    /// </exception>
    public Iso8601Time(byte hour, byte minute, byte second, TimeSpan utcOffset, bool simple = false)
    {
        this.Hour = hour;
        this.Minute = minute;
        this.Second = second;
        this.Fraction = null;
        this.UtcOffset = utcOffset;
        this.Simple = simple;
        this.ValidateHour();
        this.ValidateMinute();
        this.ValidateSecond();
        this.ValidateUtcOffset();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="hour">The hour.</param>
    /// <param name="minute">The minute.</param>
    /// <param name="second">The second.</param>
    /// <param name="fraction">The fraction of a second.</param>
    /// <param name="simple">A value that indicates whether the ISO 8601 Time has a simple representation.</param>
    /// <exception cref="Iso8601TimeOutOfRangeException">
    /// An <see cref="Iso8601TimeOutOfRangeException" /> is thrown if any of the components is out of the accepted range of ISO 8601 Time values.
    /// </exception>
    public Iso8601Time(byte hour, byte minute, byte second, decimal fraction, bool simple = false)
    {
        this.Hour = hour;
        this.Minute = minute;
        this.Second = second;
        this.Fraction = fraction;
        this.UtcOffset = null;
        this.Simple = simple;
        this.ValidateHour();
        this.ValidateMinute();
        this.ValidateSecond();
        this.ValidateFraction();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="hour">The hour.</param>
    /// <param name="minute">The minute.</param>
    /// <param name="second">The second.</param>
    /// <param name="fraction">The fraction of a second.</param>
    /// <param name="utcOffset">The UTC offset.</param>
    /// <param name="simple">A value that indicates whether the ISO 8601 Time has a simple representation.</param>
    /// <exception cref="Iso8601TimeOutOfRangeException">
    /// An <see cref="Iso8601TimeOutOfRangeException" /> is thrown if any of the components is out of the accepted range of ISO 8601 Time values.
    /// </exception>
    public Iso8601Time(byte hour, byte minute, byte second, decimal fraction, TimeSpan utcOffset, bool simple = false)
    {
        this.Hour = hour;
        this.Minute = minute;
        this.Second = second;
        this.Fraction = fraction;
        this.UtcOffset = utcOffset;
        this.Simple = simple;
        this.ValidateHour();
        this.ValidateMinute();
        this.ValidateSecond();
        this.ValidateFraction();
        this.ValidateUtcOffset();
    }

    /// <summary>
    /// Gets the hour component.
    /// </summary>
    public byte Hour { get; }

    /// <summary>
    /// Gets the minute component.
    /// </summary>
    public byte? Minute { get; }

    /// <summary>
    /// Gets the second component.
    /// </summary>
    public byte? Second { get; }

    /// <summary>
    /// Gets the fraction of a second component.
    /// </summary>
    public decimal? Fraction { get; }

    /// <summary>
    /// Gets the UTC offset component.
    /// </summary>
    public TimeSpan? UtcOffset { get; }

    /// <summary>
    /// Gets a value that indicates whether the ISO 8601 Time has a simple representation.
    /// </summary>
    public bool Simple { get; }

    private void ValidateHour()
    {
        if (this.Hour > 23)
            throw new Iso8601TimeOutOfRangeException(nameof(this.Hour));
    }

    private void ValidateMinute()
    {
        if (this.Minute is not { } minute || minute > 59)
            throw new Iso8601TimeOutOfRangeException(nameof(this.Minute));
    }

    private void ValidateSecond()
    {
        if (this.Second is not { } second || second > 59)
            throw new Iso8601TimeOutOfRangeException(nameof(this.Second));
    }

    private void ValidateFraction()
    {
        if (this.Fraction is not { } fraction || fraction >= 1.0m || fraction < 0.0m)
            throw new Iso8601TimeOutOfRangeException(nameof(this.Fraction));
    }

    private void ValidateUtcOffset()
    {
        if (this.UtcOffset is not { } utcOffset)
            throw new Iso8601TimeOutOfRangeException(nameof(this.UtcOffset));
        if (Math.Abs(utcOffset.Minutes) != 0 && Math.Abs(utcOffset.Minutes) != 30)
            throw new Iso8601TimeOutOfRangeException(nameof(this.UtcOffset));
    }
}
