using MBApiLibrary.Models._11_AMS;
using MBApiLibrary.Modules._11003O;

namespace MBApps.Applications.AMS.Vars;

public class V12002Model
{
    // --- Payroll Group ---
    public List<M11003_Payrollgrp> PayrollGrps         { get; set; } = [];
    public int? SelectedPayrollGrpId                   { get; set; }

    // --- BioManHourHdr (Coverage) ---
    public BioManHourHdrModel Hdr                      { get; set; } = new();

    // --- BioManHour Grid (upper) ---
    public List<BioManHourModel> ManHours              { get; set; } = [];

    // --- BioDailyPunches Grid (lower) ---
    public List<BioDailyPunchesModel> DailyPunches     { get; set; } = [];

    // --- Load Attendance Modal ---
    public bool IsLoadModalOpen                        { get; set; } = false;
    public string DeviceNo                             { get; set; } = "1";
    public string? AttlogContent                       { get; set; }
    public List<BiologModel> ParsedLogs                { get; set; } = [];
    public bool IsBusy                                 { get; set; } = false;

    // --- Notification ---
    public (string Type, string Message) Notification  { get; set; } = (string.Empty, string.Empty);
}
