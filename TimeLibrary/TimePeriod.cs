using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLibrary
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private const int SECOND_PER_HOUR = 3600;
        private const int SECOND_PER_MINUTE = 60;

        private readonly long _totalSeconds;

        /// <summary>
        /// The total number of seconds in the time period.
        /// </summary>
        public long TotalSeconds => _totalSeconds;

        /// <summary>
        /// The number of hours in the time period.
        /// </summary>
        public byte Hours => (byte)(TotalSeconds / SECOND_PER_HOUR);

        /// <summary>
        /// The number of minutes in the time period.
        /// </summary>
        public byte Minutes => (byte)(TotalSeconds / SECOND_PER_MINUTE % 60);

        /// <summary>
        /// The number of seconds in the time period.
        /// </summary>
        public byte Seconds => (byte)(TotalSeconds % 60);

        /// <summary>
        /// Initializes a new instance of the struct using a number of seconds.
        /// </summary>
        /// <param name="seconds">The number of seconds in the time period.</param>
        /// <exception cref="ArgumentException">Thrown when the number of seconds is negative.</exception>
        public TimePeriod(long seconds)
        {
            if (seconds < 0)
                throw new ArgumentException("Seconds cannot be negative.");

            _totalSeconds = seconds;
        }

        /// <summary>
        /// Initializes a new instance of the struct using hours, minutes, and seconds.
        /// </summary>
        /// <param name="seconds">The number of seconds in the time period.</param>
        /// <param name="minute">The number of minutes in the time period.</param>
        /// <param name="hour">The number of hours in the time period.</param>
        /// <exception cref="ArgumentException">Thrown when any of the time values are negative.</exception>
        public TimePeriod(byte seconds, byte minute = 0, byte hour = 0)
        {
            if (hour < 0 || minute < 0 || seconds < 0)
                throw new ArgumentException("The time cannot be less than zero!");

            _totalSeconds = hour * SECOND_PER_HOUR + minute * SECOND_PER_MINUTE + seconds;
        }

        /// <summary>
        /// Initializes a new instance of the struct using a start and end time.
        /// </summary>
        /// <param name="start">The start time of the time period.</param>
        /// <param name="end">The end time of the time period.</param>
        /// <exception cref="ArgumentException">Thrown when the end time is earlier than the start time.</exception>
        public TimePeriod(Time start, Time end)
        {
            if (start < end)
                throw new ArgumentException("End time cannot be earlier than start time.");

            _totalSeconds = start.TimeInSeconds - end.TimeInSeconds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimePeriod"/> struct using the specified string representation of a time.
        /// The time string must be in the format "hours:minutes:seconds".
        /// </summary>
        /// <param name="time">A string representing a time in the format "hours:minutes:seconds".</param>
        /// <exception cref="FormatException">Thrown when the time string is in an invalid format.</exception>
        /// <exception cref="ArgumentException">Thrown when the time string contains invalid values.</exception>
        public TimePeriod(string time)
        {
            string[] timeParts = time.Split(':');
            if (timeParts.Length != 3)
                throw new FormatException("Invalid time record string");

            if (!long.TryParse(timeParts[0], out long hour) || !long.TryParse(timeParts[1], out long minute)
                || !long.TryParse(timeParts[2], out long seconds))
            {
                throw new ArgumentException("Invalid time string");
            }

            _totalSeconds = hour * SECOND_PER_HOUR + minute * SECOND_PER_MINUTE + seconds;
        }

        /// <summary>
        /// Returns a string representation of this TimePeriod in the format "hh:mm:ss".
        /// </summary>
        /// <returns>A string representation of this TimePeriod.</returns>
        public override string ToString() => $"{Hours}:{Minutes:D2}:{Seconds:D2}";

        #region Equals, GetHash, CompareTo

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="TimePeriod"/> object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj) => obj is TimePeriod other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="TimePeriod"/> object is equal to the current <see cref="TimePeriod"/> object.
        /// </summary>
        /// <param name="other">The <see cref="TimePeriod"/> object to compare with the current object.</param>
        /// <returns>true if the specified <see cref="TimePeriod"/> object is equal to the current object; otherwise, false.</returns>
        public bool Equals(TimePeriod other) => TotalSeconds == other.TotalSeconds;

        /// <summary>
        /// Returns a hash code for the current <see cref="TimePeriod"/> object.
        /// </summary>
        /// <returns>A hash code for the current <see cref="TimePeriod"/> object.</returns>
        public override int GetHashCode() => HashCode.Combine(TotalSeconds);

        /// <summary>
        /// Compares this <see cref="TimePeriod"/> instance to another instance.
        /// </summary>
        /// <param name="other">The <see cref="TimePeriod"/> instance to compare to.</param>
        /// <returns>A value indicating the relative order of the objects being compared.</returns>
        public int CompareTo(TimePeriod other) => TotalSeconds.CompareTo(other.TotalSeconds);
        #endregion

        #region operators ==, !=, <, =<, >, >=

        /// <summary>
        /// Determines whether two <see cref="TimePeriod"/> instances are equal.
        /// </summary>
        /// <param name="left">The first <see cref="TimePeriod"/> instance.</param>
        /// <param name="right">The second <see cref="TimePeriod"/> instance.</param>
        /// <returns>True if the two instances are equal otherwise, false.</returns>
        public static bool operator ==(TimePeriod left, TimePeriod right) => left.Equals(right);

        /// <summary>
        /// Determines whether two <see cref="TimePeriod"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first <see cref="TimePeriod"/> instance.</param>
        /// <param name="right">The second <see cref="TimePeriod"/> instance.</param>
        /// <returns>True if the two instances are not equal otherwise, false.</returns>
        public static bool operator !=(TimePeriod left, TimePeriod right) => !(left == right);

        /// <summary>
        /// Compares two TimePeriod objects and returns a value indicating whether one is less than the other.
        /// </summary>
        /// <param name="left">The first TimePeriod to compare.</param>
        /// <param name="right">The second TimePeriod to compare.</param>
        /// <returns>true if left is less than right otherwise, false.</returns>
        public static bool operator <(TimePeriod left, TimePeriod right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Compares two TimePeriod objects and returns a value indicating whether one is less than or equal to the other.
        /// </summary>
        /// <param name="left">The first TimePeriod to compare.</param>
        /// <param name="right">The second TimePeriod to compare.</param>
        /// <returns>true if left is less than or equal to right otherwise, false.</returns>
        public static bool operator <=(TimePeriod left, TimePeriod right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Compares two TimePeriod objects and returns a value indicating whether one is greater than the other.
        /// </summary>
        /// <param name="left">The first TimePeriod to compare.</param>
        /// <param name="right">The second TimePeriod to compare.</param>
        /// <returns>true if left is greater than right otherwise, false.</returns>
        public static bool operator >(TimePeriod left, TimePeriod right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Compares two TimePeriod objects and returns a value indicating whether one is greater than or equal to the other.
        /// </summary>
        /// <param name="left">The first TimePeriod to compare.</param>
        /// <param name="right">The second TimePeriod to compare.</param>
        /// <returns>true if left is greater than or equal to right otherwise, false.</returns>
        public static bool operator >=(TimePeriod left, TimePeriod right) => left.CompareTo(right) >= 0;
        #endregion

        /// <summary>
        /// Returns a new TimePeriod object that represents the sum of this TimePeriod and another TimePeriod.
        /// </summary>
        /// <param name="other">The TimePeriod to add to this one.</param>
        /// <returns>A new TimePeriod object that represents the sum of this TimePeriod and another TimePeriod.</returns>
        public TimePeriod Plus(TimePeriod other) => new TimePeriod(TotalSeconds + other.TotalSeconds);

        /// <summary>
        /// This is a static method called TimePeriodAddition, which takes two arguments: two TimePeriod objects.
        /// </summary>
        /// <param name="timePeriod">The first argument is a TimePeriod object, representing the initial time period.</param>
        /// <param name="timePeriod1">The second argument is a TimePeriod object, representing the time period to be added to the initial time period.</param>
        /// <returns>A new TimePeriod object representing the sum of the two given time periods.</returns>
        public static TimePeriod TimePeriodAddition(TimePeriod timePeriod, TimePeriod timePeriod1)
        {
            long totalSeconds = timePeriod.TotalSeconds + timePeriod1.TotalSeconds;
            return new TimePeriod(totalSeconds);
        }

        /// <summary>
        /// Returns a new TimePeriod object that represents the difference between this TimePeriod and another TimePeriod.
        /// </summary>
        /// <param name="other">The TimePeriod to subtract from this one.</param>
        /// <returns>A new TimePeriod object that represents the difference between this TimePeriod and another TimePeriod.</returns>
        /// <exception cref="ArgumentException">Thrown when the subtraction results in a negative time period.</exception>
        public TimePeriod Minus(TimePeriod other) => new(TotalSeconds - other.TotalSeconds < 0 ? throw new ArgumentException("You can't subtract more time from less time ") : TotalSeconds - other.TotalSeconds);

        /// <summary>
        /// Returns a new TimePeriod object that represents the sum of two TimePeriod objects.
        /// </summary>
        /// <param name="time">The first TimePeriod to add.</param>
        /// <param name="time2">The second TimePeriod to add.</param>
        /// <returns>A new TimePeriod object that represents the sum of two TimePeriod objects.</returns>
        public static TimePeriod operator +(TimePeriod time, TimePeriod time2) => time.Plus(time2);

        /// <summary>
        /// This is a static method called TimePeriodSubstrac, which takes two arguments: two TimePeriod objects.
        /// </summary>
        /// <param name="timePeriod">The first argument is a TimePeriod object, representing the initial time period.</param>
        /// <param name="timePeriod1">The second argument is a TimePeriod object, representing the time period to be subtracted from the initial time period.</param>
        /// <returns>A new TimePeriod object representing the difference between the two given time periods.</returns>
        /// <exception cref="ArgumentException">Thrown when the resulting time period is negative.</exception>
        public static TimePeriod TimePeriodSubstrac(TimePeriod timePeriod, TimePeriod timePeriod1)
        {
            long totalSeconds = timePeriod.TotalSeconds - timePeriod1.TotalSeconds;
            if (totalSeconds < 0)
                throw new ArgumentException("You can't subtract more time from less time ");

            return new TimePeriod(totalSeconds);
        }

        /// <summary>
        /// Returns a new TimePeriod object that represents the difference between two TimePeriod objects.
        /// </summary>
        /// <param name="time">The TimePeriod to subtract from.</param>
        /// <param name="time2">The TimePeriod to subtract.</param>
        /// <returns>A new TimePeriod object that represents the difference between two TimePeriod objects.</returns>
        public static TimePeriod operator -(TimePeriod time, TimePeriod time2) => time.Minus(time2);
    }
}
