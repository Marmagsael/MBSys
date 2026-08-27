namespace MBApiLibrary.Models._20_PayGeneric; 

public class GChartofacctModel
{
    public string?      AcctNumber          { get; set; }
    public string?      AcctName            { get; set; }
    public string?      AcctType            { get; set; }
    public int          Annualize           { get; set; }
    public int          DedSort             { get; set; }
    public int          Deferd              { get; set; }
    public string?      ExtLoanPercent      { get; set; }
    public int          MWE_Type            { get; set; }
    public double       OTRate              { get; set; }
    public double       TaxExptAmt          { get; set; }
    public int          Taxable_Type        { get; set; }
    public double       Ceiling             { get; set; }
    public double       CustomRate          { get; set; }
    public string?      Formula             { get; set; }
    public string?      HasRateOverBasic    { get; set; }
    public int          Is13thMoAcct        { get; set; }
    public int          IsDefered           { get; set; }
    public int          IsExtLoan           { get; set; }
    public string?      IsFixed             { get; set; }
    public int          IsGovAcct           { get; set; }
    public int          IsLegalHoliday      { get; set; }
    public int          IsMealAcct          { get; set; }
    public int          IsOT                { get; set; }
    public int          IsOthers            { get; set; }
    public int          IsShown             { get; set; }
    public int          IsTH                { get; set; }
    public string?      IsTaxExcl           { get; set; }
    public string?      IsTaxable           { get; set; }
    public string?      IsYTDAcct           { get; set; }
    public string?      IsChargeable        { get; set; }
    public string?      IsLock              { get; set; }
    public int          Pngpaar             { get; set; }
    public int          Pngpaallow          { get; set; }
    public int          Pngpamhap           { get; set; }
    public int          Pngpaot             { get; set; }
    public string?      ShortDesc           { get; set; }
    public int          Show01              { get; set; }
    public int          Show02              { get; set; }
    public int          Sort                { get; set; }
    public int          Special_            { get; set; }
    public int          Status_             { get; set; }
    public int          TimedMode           { get; set; }
    public int          WithPHIC            { get; set; }
    public int          WithPagibig         { get; set; }
    public int          WithSSS             { get; set; }

    //-------------------------------------
    public bool IsSelectedB         { get; set; }
    public bool IsYTDAcctB          { get => IsYTDAcct    == "1"; set => IsYTDAcct    = value ? "1" : "0"; }
    public bool IsTaxExclB          { get => IsTaxExcl    == "1"; set => IsTaxExcl    = value ? "1" : "0"; }
    public bool IsLockB             { get => IsLock       == "1"; set => IsLock       = value ? "1" : "0";  }
    public bool IsChargeableB       { get => IsChargeable == "1"; set => IsChargeable = value ? "1" : "0";  }


}
