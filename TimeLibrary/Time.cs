using System.Diagnostics.CodeAnalysis;

namespace TimeLibrary
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte _hour;
        private readonly byte _minute;
        private readonly byte _second;

        /// <summary>
        /// Gets the hours of time
        /// </summary>
        public byte Hour => _hour;

        /// <summary>
        /// Gets the minutes of time
        /// </summary>
        public byte Minute => _minute;

        /// <summary>
        /// Gets the seconds of time
        /// </summary>
        public byte Second => _second;

        /// <summary>
        /// Gets the total number of seconds represented by this time.
        /// </summary>
        public long TimeInSeconds => Hour * 3600 + Minute * 60 + Second;

        /// <summary>
        /// Initializes a new instance of the Time struct with the specified hours, minutes, and seconds.
        /// </summary>
        /// <param name="hour">The hours of time</param>
        /// <param name="minute">The minutes of time</param>
        /// <param name="second">The seconds of time</param>
        /// <exception cref="ArgumentException">Thrown if any argument is out of time range.</exception>
        public Time(byte hour, byte minute = 0, byte second = 0)
        {
            if (hour > 23 || minute > 59 || second > 59)
                throw new ArgumentException("Invalid time values!");

            _hour = hour;
            _minute = minute;
            _second = second;
        }

        /// <summary>
        /// Initializes a new instance of the Time struct from a string in the format "hh:mm:ss".
        /// </summary>
        /// <param name="time">The time string to parse</param>
        /// <exception cref="FormatException">Thrown if the time string is not in the correct format.</exception>
        /// <exception cref="ArgumentException">Thrown if the time values are out of time range.</exception>
        public Time(string time)
        {
            string[] timeParts = time.Split(':');

            if (timeParts.Length != 3)
                throw new FormatException("Invalid time record string");

            if (!byte.TryParse(timeParts[0], out byte hour) || !byte.TryParse(timeParts[1], out byte minute)
                || !byte.TryParse(timeParts[2], out byte second) || (hour > 23 || minute > 59 || second > 59))
            {
                throw new ArgumentException("Invalid time string");
            }

            _hour = hour;
            _minute = minute;
            _second = second;
        }

        /// <summary>
        /// Returns a string that represents the current Time object in the format "hh:mm:ss".
        /// </summary>
        /// <returns>A string representation of the time.</returns>
        public override string ToString()
        {
            return $"{Hour:D2}:{Minute:D2}:{Second:D2}";
        }
        #region Equals, GetHash, CompareTo

        /// <summary>
        /// Determines whether this instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>true if the specified object is equal to this instance; otherwise, false.</returns>
        public override bool Equals(object? obj) => obj is Time other && Equals(other);

        /// <summary>
        /// Determines whether the specified Time object is equal to the current Time object.
        /// </summary>
        /// <param name="obj">The Time object to compare with the current object.</param>
        /// <returns>True if the specified Time object is equal to the current object; otherwise, false.</returns>
        public bool Equals(Time other) => Hour == other.Hour && Minute == other.Minute && Second == other.Second;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() => HashCode.Combine(Hour, Minute, Second);

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that 
        /// indicates whether the current instance precedes, follows, or occurs in the same position in the 
        /// sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(Time other)
        {
            if (Hour != other.Hour) return Hour.CompareTo(other.Hour);
            if (Minute != other.Minute) return Minute.CompareTo(other.Minute);
            return Second.CompareTo(other.Second);
        }
        #endregion

        #region operators ==, !=, <, =<, >, >=
        /// <summary>
        /// Determines whether two specified Time objects have the same value.
        /// </summary>
        /// <param name="left">The first Time to compare.</param>
        /// <param name="right">The second Time to compare.</param>
        /// <returns>true if the value of left is equal to the value of right; otherwise, false.</returns>
        public static bool operator ==(Time left, Time right) => left.Equals(right);

        /// <summary>
        /// Determines whether two specified Time objects have different values.
        /// </summary>
        /// <param name="left">The first Time to compare.</param>
        /// <param name="right">The second Time to compare.</param>
        /// <returns>true if <paramref name="left"/> is different from the
        /// value of <paramref name="right"/> otherwise, false.</returns>
        public static bool operator !=(Time left, Time right) => !(left == right);

        /// <summary>
        /// Determines whether the value of one specified Time object is less than the value of another specified Time object.
        /// </summary>
        /// <param name="left">The first Time to compare.</param>
        /// <param name="right">The second Time to compare.</param>
        /// <returns>true if <paramref name="left"/> is less than <paramref name="right"/> otherwise, false.</returns>
        public static bool operator <(Time left, Time right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines whether one specified object is less than or equal to another specified object.
        /// </summary>
        /// <param name="left">The first object.</param>
        /// <param name="right">The second object.</param>
        /// <returns>true if <paramref name="left"/> is less than or equal to <paramref name="right"/> otherwise, false.</returns>
        public static bool operator <=(Time left, Time right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Determines whether one specified object is greater than another specified object.
        /// </summary>
        /// <param name="left">The first object.</param>
        /// <param name="right">The second object.</param>
        /// <returns>true if <paramref name="left"/> is greater than <paramref name="right"/> otherwise, false.</returns>
        public static bool operator >(Time left, Time right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines whether one specified object is greater than or equal to another specified <see cref="Time"/> object.
        /// </summary>
        /// <param name="left">The first object.</param>
        /// <param name="right">The second object.</param>
        /// <returns>true if <paramref name="left"/> is greater than or equal to <paramref name="right"/> otherwise, false.</returns>
        public static bool operator >=(Time left, Time right) => left.CompareTo(right) >= 0;
        #endregion

        /// <summary>
        /// Adds a specified to the current object and returns a new object.
        /// </summary>
        /// <param name="timePeriod">The <see cref="TimePeriod"/> to add.</param>
        /// <returns>A new <see cref="Time"/> object that represents the result of the addition.</returns>
        public Time Plus(TimePeriod timePeriod)
        {
            long totalSeconds = TimeInSeconds + timePeriod.TotalSeconds;
            return new Time(SecondToHours(totalSeconds), SecondsToMinutes(totalSeconds), Seconds(totalSeconds));
        }

        /// <summary>
        /// This is a static method called TimeAddition, which takes two arguments: a Time object and a TimePeriod object.
        /// </summary>
        /// <param name="time">The first argument is a Time object, representing the initial time.</param>
        /// <param name="timePeriod">The second argument is a TimePeriod object, representing the amount of time to be added to the initial time.</param>
        /// <returns>A new Time object representing the sum of the initial time and the added time.</returns>
        public static Time TimeAddition(Time time, TimePeriod timePeriod)
        {
            long totalSeconds = time.TimeInSeconds + timePeriod.TotalSeconds;
            return new Time((byte)(totalSeconds / 3600 % 24), (byte)(totalSeconds / 60 % 60), (byte)(totalSeconds % 60));
        }

        /// <summary>
        /// Subtracts a specified from the current object and returns a new object.
        /// </summary>
        /// <param name="timePeriod">The <see cref="TimePeriod"/> to subtract.</param>
        /// <returns>A new object that represents the result of the subtraction.</returns>
        /// <exception cref="ArgumentException">Thrown when the result of the subtraction is a negative value.</exception>
        public Time Minus(TimePeriod timePeriod)
        {
            long totalSeconds = TimeInSeconds - timePeriod.TotalSeconds;
            if (totalSeconds < 0)
                throw new ArgumentException("You can't subtract more time from less time ");

            return new Time(SecondToHours(totalSeconds), SecondsToMinutes(totalSeconds), Seconds(totalSeconds));
        }

        /// <summary>
        /// This is a static method called TimeSubstrackt, which takes two arguments: a Time object and a TimePeriod object.
        /// </summary>
        /// <param name="time">The first argument is a Time object, representing the initial time.</param>
        /// <param name="timePeriod">The second argument is a TimePeriod object, representing the amount of time to be subtracted from the initial time.</param>
        /// <returns>A new Time object representing the result of subtracting the given time period from the initial time.</returns>
        /// <exception cref="ArgumentException">Thrown when the resulting time is negative.</exception>
        public static Time TimeSubstrackt(Time time, TimePeriod timePeriod)
        {
            long totalSeconds = time.TimeInSeconds - timePeriod.TotalSeconds;
            if (totalSeconds < 0)
                throw new ArgumentException("You can't subtract more time from less time ");

            return new Time((byte)(totalSeconds / 3600 % 24), (byte)(totalSeconds / 60 % 60), (byte)(totalSeconds % 60));
        }

        /// <summary>
        /// Adds a <see cref="TimePeriod"/> to a object and returns the result as a new object.
        /// </summary>
        /// <param name="time">The object to which the will be added.</param>
        /// <param name="timePeriod">The to add to the object.</param>
        /// <returns>A new object that represents the sum of the original object.</returns>
        public static Time operator +(Time time, TimePeriod timePeriod) => time.Plus(timePeriod);

        /// <summary>
        /// Subtracts a from a object and returns the result as a new object.
        /// </summary>
        /// <param name="time">The object from which the will be subtracted.</param>
        /// <param name="timePeriod">The to subtract from the object.</param>
        /// <returns>A new <see cref="Time"/> object that represents the difference between the original object.</returns>
        public static Time operator -(Time time, TimePeriod timePeriod) => time.Minus(timePeriod);

        /// <summary>
        /// Converts the specified number of seconds to hours.
        /// </summary>
        /// <param name="seconds">The number of seconds to convert.</param>
        /// <returns>The equivalent number of hours.</returns>
        private byte SecondToHours(long seconds) => (byte)(seconds / 3600 % 24);

        /// <summary>
        /// Converts the specified number of seconds to minutes.
        /// </summary>
        /// <param name="seconds">The number of seconds to convert.</param>
        /// <returns>The equivalent number of minutes.</returns>
        private byte SecondsToMinutes(long seconds) => (byte)(seconds / 60 % 60);

        /// <summary>
        /// Gets the remaining number of seconds after converting the specified number of seconds to minutes and hours.
        /// </summary>
        /// <param name="seconds">The number of seconds to convert.</param>
        /// <returns>The remaining number of seconds after converting to minutes and hours.</returns>
        private byte Seconds(long seconds) => (byte)(seconds % 60);
    }
}