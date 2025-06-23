namespace Core.Models.BusinessEntities.ValueObjects
{
    // Learn more: https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects
    // https://www.milanjovanovic.tech/blog/value-objects-in-dotnet-ddd-fundamentals
    public abstract record ValueObject : IEquatable<ValueObject>
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }

            return left?.Equals(right!) != false;
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public virtual bool Equals(ValueObject? other) // Marked as virtual to allow overriding
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();

            foreach (var component in GetEqualityComponents())
            {
                hash.Add(component);
            }

            return hash.ToHashCode();
        }
    }
}
