namespace Core.Interfaces
{
    /// <summary>
    /// Represents an entity with a composite key
    /// </summary>
    /// <typeparam name="TKey">The type of the composite key components</typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Gets the composite key components of the entity
        /// </summary>
        /// <returns>Array of key components</returns>
        TKey[] GetKeys();

        /// <summary>
        /// Checks if the entity has valid keys
        /// </summary>
        bool HasValidKeys();
    }

    /// <summary>
    /// Non-generic interface for entities with mixed key types
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets the composite key components of the entity as objects
        /// </summary>
        /// <returns>Array of key components as objects</returns>
        object[] GetCompositeKeys();
    }
}
