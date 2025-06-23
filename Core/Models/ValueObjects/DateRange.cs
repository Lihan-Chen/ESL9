namespace Core.Models.ValueObjects
{
    public sealed record DateRange : IEquatable<DateRange>
    {
        //public DateOnly StartDate { get; }
        //public DateOnly EndDate { get; }

        public DateOnly StartDate { get; private set; } = DateOnly.FromDateTime(DateTime.Now).AddDays(-1);

        public DateOnly EndDate { get; private set; } = DateOnly.FromDateTime(DateTime.Now).AddDays(1);

        public DateRange(DateOnly startDate, DateOnly endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("End date must be after or equal to start date", nameof(endDate));
            }

            StartDate = startDate;
            EndDate = endDate;
        }

        public static DateRange CreateDefaultRange()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            return new DateRange(today.AddDays(-30), today);
        }

        public static DateRange? TryParse(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;

            var dates = value.Split('-', StringSplitOptions.TrimEntries);
            if (dates.Length != 2) return null;

            if (DateOnly.TryParse(dates[0], out var startDate) &&
                DateOnly.TryParse(dates[1], out var endDate))
            {
                return new DateRange(startDate, endDate);
            }

            return null;
        }

        public bool IsWithinRange(DateOnly date)
        {
            return date >= StartDate && date <= EndDate;
        }

        public bool Contains(DateOnly date)
        {
            return date >= StartDate && date <= EndDate;
        }

        public bool Overlaps(DateRange other)
        {
            return StartDate < other.EndDate && EndDate > other.StartDate;
        }

        public override string ToString()
        {
            return $"{StartDate:MM/dd/yyyy} - {EndDate:MM/dd/yyyy}";
        }

        public bool Equals(DateRange? other)
        {
            if (other is null) return false;
            return StartDate == other.StartDate && EndDate == other.EndDate;
        }

        //public override bool Equals(object? obj)
        //{
        //    return Equals(obj as DateRange);
        //}

        public override int GetHashCode()
        {
            return HashCode.Combine(StartDate, EndDate);
        }

        public TimeSpan GetDuration()
        {
            return EndDate.ToDateTime(TimeOnly.MinValue) - StartDate.ToDateTime(TimeOnly.MinValue);
        }
    }
}
