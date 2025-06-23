namespace Core.Models.ValueObjects
{
    public record Update
    {
        public string UPDATEDBY { get; set; } = null!;

        public DateTime UPDATEDATE { get; set; } = DateTime.UtcNow;
    }
}
