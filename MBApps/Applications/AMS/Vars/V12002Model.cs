using MBApiLibrary.Models._00_Main;
using MBApiLibrary.Models._11_AMS;
using MBApiLibrary.Modules._11003O;

namespace MBApps.Applications.AMS.Vars;

public class V12002Model
{
    // --- Payroll Group ---
    public List<M11003_Payrollgrp> PayrollGrps { get; set; } = [];
    public int? SelectedPayrollGrpId { get; set; }

    // --- Coverage Date Range ---
    public DateTime? CoverageStart { get; set; } = DateTime.Today.AddDays(-15);
    public DateTime? CoverageEnd { get; set; } = DateTime.Today;

    // --- Load Attendance Modal ---
    public bool IsLoadModalOpen { get; set; } = false;
    public string DeviceNo { get; set; } = "1";
    public string? AttlogContent { get; set; }
    public List<BiologModel> ParsedLogs { get; set; } = [];
    public bool IsBusy { get; set; } = false;

    // --- Notification ---
    public (string Type, string Message) Notification { get; set; } = (string.Empty, string.Empty);
}
