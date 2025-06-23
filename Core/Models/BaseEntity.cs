using Core.Interfaces;

namespace Core.Models
{
    /// <summary>
    /// Base implementation for entities with composite keys
    /// </summary>
    /// <typeparam name="TKey">The type of the composite key components</typeparam>
    //[NotMapped]
    public abstract record BaseEntity<TKey> : IEntity<TKey>, IEntity
    {
        /// <summary>
        /// Gets the composite key components specific to the entity
        /// </summary>
        public abstract TKey[] GetKeys();

        /// <summary>
        /// Gets the composite key components as objects
        /// </summary>
        public object[] GetCompositeKeys() => GetKeys().Cast<object>().ToArray();

        /// <summary>
        /// Validates if all key components are properly set
        /// </summary>
        public virtual bool HasValidKeys()
        {
            var keys = GetKeys();
            return keys != null &&
                   keys.Length > 0 &&
                   keys.All(k => k != null && !k.Equals(default(TKey)));
        }

        public virtual bool Equals(BaseEntity<TKey>? other)
        {
            if (other is null)
                return false;

            return GetKeys().SequenceEqual(other.GetKeys());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetKeys());
        }
    }

    /// <summary>
    /// Example of AllEvent
    /// </summary>
    //public class AllEvent : BaseEntity<object>
    //{
    //    public int FacilNo { get; set; }
    //    public int LogTypeNo { get; set; }
    //    public string EventID { get; set; } = string.Empty;
    //    public int EventID_RevNo { get; set; }

    //    public override object[] GetKeys()
    //    {
    //        return new object[] { FacilNo, LogTypeNo, EventID, EventID_RevNo };
    //    }
    //}

    //public class AllEventEntityTypeConfiguration : IEntityTypeConfiguration<AllEvent>
    //{
    //    public void Configure(EntityTypeBuilder<AllEvent> builder)
    //    {
    //        builder.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo });
    //        // ... rest of configuration
    //    }
    //}
}