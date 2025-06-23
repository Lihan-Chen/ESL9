namespace Core.Interfaces;

public interface IEventIDentity
{
    public int FacilNo {  get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; }

    public int EventID_RevNo { get; set; }
}
