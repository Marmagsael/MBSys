namespace MBApiLibrary.Models._11_AMS;

public class BioManHourHdrModel
{
    public long     Id             { get; set; }
    public int      PayrollGrpId   { get; set; }
    public DateOnly CoverageStart  { get; set; }
    public DateOnly CoverageEnd    { get; set; }
    public string?  Remarks        { get; set; }

    // --- Not in table ---
    public string   PayrollGrpName { get; set; } = string.Empty;
}
