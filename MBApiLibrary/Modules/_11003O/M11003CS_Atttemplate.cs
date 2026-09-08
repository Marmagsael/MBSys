namespace MBApiLibrary.Modules._11003O;

public class M11003CS_Atttemplate
{
    public int      Attendancetypeid                { get; set; }
    public int      Attschedweeklyhdrid             { get; set; }
    public int      Attschedweeklyhdridadv          { get; set; }
    public DateTime Changeschedeffectivity          { get; set; }
    public int      Empmasid                        { get; set; }

    //--- Others -------------------------------------------------
    public bool     IsSelected                      { get; set; } = false; 
    public string? CurrentScheduleName              { get; set; }
    public string? AdvanceScheduleName              { get; set; }
    public string? EmpName                          { get; set; }
    
}

