namespace Core.Interfaces
{
    /// <summary>
    /// This is the base interface for composite key (FacilNo + IEntity) mainly for ESL parameters such as Meters.
    /// </summary>
    public interface IEventEntity : IEntity
    {
        public int FacilNo { get; set; }

        public int LogTypeNo { get; set; }

        public string EventID { get; set; }

        public int EventID_RevNo { get; set; }
    }
}
