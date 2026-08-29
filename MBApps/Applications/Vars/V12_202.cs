using System;
using MBApiLibrary.Models._00_Main;
using MBApiLibrary.Models._10_Pis.OPis;
using MBApiLibrary.Models._20_Pay;
using MBApiLibrary.Models._20_PayGeneric;
using MBApiLibrary.Models._90_Utils;

namespace MBApps.Applications.Vars;

public class V12_202
{
    public string?                   TRN             { get; set; } = string.Empty;
    public string?                   SSS             { get; set; } = string.Empty;
    public string?                   TIN             { get; set; } = string.Empty;  
    public string?                   Payrollgrp      { get; set; } = string.Empty;  
    public string?                   AttCoverage     { get; set; } = string.Empty;  
    public double                   Rate            { get; set; } = 0.0;  
    public UserClaimsModel          UserClaims      { get; set; } = new(); 
    public List<GTbltranModel?>?    Tbltrans        { get; set; } = [];
    public List<GTbltrandtlModel?>? Tbltrandtls     { get; set; } = [];
    public GPaymainhdrModel?        Paymainhdr      { get; set; } = new();
    public List<GPaymainhdrModel?>? Paymainhdrs     { get; set; } = [];
    public List<OEmpmasModel?>?     OEmpmas         { get; set; } = [];   
    public int?                      Yr              { get; set; } = DateTime.Now.Year;
    public int?                      Mo              { get; set; } = DateTime.Now.Month;   
    public int?                      Prd             { get; set; } = 1;


    ///------------------------------------------------------------------------
    public string initialmsg = "No payslip records yet. Select year, month, and period, then click \"Load Payslip\"";
    public string loadingmsg = string.Empty;
    public string nodatamsg = string.Empty;
}