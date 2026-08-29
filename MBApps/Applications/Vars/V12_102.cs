using System;
using MBApiLibrary.Models._10_Pis;

namespace MBApps.Applications.Vars;

public class V12_102
{
    public List<AtttemplateModel?>?     Atttemplates            { get; set; } = [];
    public List<Attpunches1Model?>?     Attpunches1_7days       { get; set; } = [];
    public List<Attpunches1Model?>?     Attpunches1_Wo_Out      { get; set; } = [];
    public Attpunches1Model?            Attpunches1_Current     { get; set; } = new();


}
