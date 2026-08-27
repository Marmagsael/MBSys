using MBApiLibrary.DataAccess._10_Pis.Interface;
using MBApiLibrary.DataAccess._90_Utils.Interface;
using MBApiLibrary.Models._10_Pis;
using MBApiLibrary.Models._20_Pay;
using MBApiLibrary.Models._20_Pay.M0605;
using MBApiLibrary.Models._90_Utils;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using MBApiLibrary.Models._00_Main;
using System.Runtime.ExceptionServices;


namespace MBApiLibrary.DataAccess._90_Utils;


public class MsdsDataAccess : IMsdsDataAccess
{

    public Object ObjectMapper(Object src, Object des)
    {

        Type typeScr = src.GetType();
        PropertyInfo[] propertiesScr = typeScr.GetProperties();

        Type typeDes = des.GetType();
        PropertyInfo[] propertiesDes = typeDes.GetProperties();

        for (int? i = 0; i < propertiesScr.Count(); i++)
        {
            for (int? j = 0; j < propertiesDes.Count(); j++)
            {
                if (propertiesScr[i??0].Name.Equals(propertiesDes[j??0].Name))
                {
                    var valScr = propertiesScr[i??0].GetValue(src, null);
                    propertiesDes[j??0].SetValue(des, valScr, null);
                }
            }
        }
        return des;
    }

    public static bool IsObjectEqual(Object obj1, Object obj2)
    {
        bool isEqual = true;

        Type typeO1 = obj1.GetType();
        PropertyInfo[] propertiesO1 = typeO1.GetProperties();

        Type typeO2 = obj2.GetType();
        PropertyInfo[] propertiesO2 = typeO2.GetProperties();

        for (int? i = 0; i < propertiesO1.Count(); i++)
        {
            for (int? j = 0; j < propertiesO2.Count(); j++)
            {
                if (propertiesO1[i??0].Name.Equals(propertiesO2[j??0].Name))
                {
                    var val1 = propertiesO1[i??0].GetValue(obj1, null)?.ToString(); 
                    var val2 = propertiesO2[j??0].GetValue(obj2, null)?.ToString();

                    if (val1 != val2 ) {
                        isEqual = false;
                    }
                }
            }
        }

        return isEqual; 
    }
    
    public static string? GetMacAddress()
    {
        
        var macAddress = string.Empty;
        
        // Get all network interfaces
        var nics = NetworkInterface.GetAllNetworkInterfaces();
        
        foreach (NetworkInterface nic in nics)
        {
            // Get the MAC address
            var address = nic.GetPhysicalAddress();
            var bytes = address.GetAddressBytes();
            
            // Convert the byte array to a string
            macAddress = string.Join(":", bytes.Select(b => b.ToString("X2")));
            if (macAddress.ToString().Length > 1) return macAddress; 
        }

        return macAddress; 
    }

    public static string? GetIPAddress()
    {
        string? hostName = Dns.GetHostName();
        IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
        foreach (IPAddress ip in hostEntry.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "No IPv4";
    }

    public static int? Get_TimeZone_Id(string? timeZoneId)
    {
        int? id = 0; 
        var ctr = 0; 
        foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
        {
            ctr++;
            if(timeZone.Id.Equals(timeZoneId)) return ctr;
        }
        return id;
    }

    public static int? GetDayNo(string? dayName)
    {
        switch (dayName)
        {
            case "Sunday"       : return 1; 
            case "Monday"       : return 2; 
            case "Tuesday"      : return 3; 
            case "Wednesday"    : return 4; 
            case "Thursday"     : return 5; 
            case "Friday"       : return 6; 
            case "Saturday"     : return 7; 
            
            default: return 0;

        }
    }

    public static List<YearsModel?> GetYears(int? totYrs)
    {
        var yrs = new List<YearsModel?>();

        var yr = new YearsModel();
        yr.Year = DateTime.Now.Year;
        yr.Name = yr.Year.ToString();
        yrs.Add(yr);

        for (int? i = 1; i < totYrs; i++)
        {
            yr = new YearsModel();
            yr.Year = DateTime.Now.Year - i;
            yr.Name = yr.Year.ToString();
            yrs.Add(yr);
        }

        return yrs;
    }

    public static List<MonthsModel?> GetMonths()
    {
        var mos = new List<MonthsModel?>();
        mos.Add(new MonthsModel() { Month=1,    Name = "January",   SName = "Jan" });
        mos.Add(new MonthsModel() { Month=2,    Name = "February",  SName = "Feb" });
        mos.Add(new MonthsModel() { Month=3,    Name = "March",     SName = "Mar" });
        mos.Add(new MonthsModel() { Month=4,    Name = "April",     SName = "Apr" });
        mos.Add(new MonthsModel() { Month=5,    Name = "May",       SName = "May" });
        mos.Add(new MonthsModel() { Month=6,    Name = "June",      SName = "Jun" });
        mos.Add(new MonthsModel() { Month=7,    Name = "July",      SName = "Jul" });
        mos.Add(new MonthsModel() { Month=8,    Name = "August",    SName = "Aug" });
        mos.Add(new MonthsModel() { Month=9,    Name = "September", SName = "Sep" });
        mos.Add(new MonthsModel() { Month=10,   Name = "October",   SName = "Oct" });
        mos.Add(new MonthsModel() { Month=11,   Name = "November",  SName = "Nov" });
        mos.Add(new MonthsModel() { Month=12,   Name = "December",  SName = "Dec" });
        return mos;
    }
    
    public static MonthsModel GetMonth(string? moNo)
    {
        var mo = moNo switch
        {
            "02" => new MonthsModel() { Month = 2,  Name = "February",  SName = "Feb" },
            "03" => new MonthsModel() { Month = 3,  Name = "March",     SName = "Mar" },
            "04" => new MonthsModel() { Month = 4,  Name = "April",     SName = "Apr" },
            "05" => new MonthsModel() { Month = 5,  Name = "May",       SName = "May" },
            "06" => new MonthsModel() { Month = 6,  Name = "June",      SName = "Jun" },
            "07" => new MonthsModel() { Month = 7,  Name = "July",      SName = "Jul" },
            "08" => new MonthsModel() { Month = 8,  Name = "August",    SName = "Aug" },
            "09" => new MonthsModel() { Month = 9,  Name = "September", SName = "Sep" },
            "10" => new MonthsModel() { Month = 10, Name = "October",   SName = "Oct" },
            "11" => new MonthsModel() { Month = 11, Name = "November",  SName = "Nov" },
            "12" => new MonthsModel() { Month = 12, Name = "December",  SName = "Dec" },
            _ => new    MonthsModel() { Month = 1,  Name = "January",   SName = "Jan" }
        };
        return mo;
    }
    
    public static List<MyDTRModel?> GetMonthlyDTR(int? yr, int? mo)
    {
        var myDTR = new List<MyDTRModel?>();

        var date    = new DateTime(yr??0, mo??0, 1);
        var nxt_mo  = date.AddMonths(1);

        for (int? i = 0; i < 31; i++)
        {
            var xdate = date.AddDays(i??0);
            if (xdate < nxt_mo)
            {
                var ad = new MyDTRModel() { Date = xdate, DayName=xdate.DayOfWeek.ToString() };
                myDTR.Add(ad);
            }   
        }
        return myDTR; 
    }

    public static string? Extract_FieldPrd(string? trn)
    {
        var p = string.Empty;
        if (trn.Length < 6) return p;
        var fldName = trn.Substring(4, 2);
        
        var fld = fldName switch
        {
            "02" => "P2",
            "03" => "P3",
            "04" => "P4",
            "05" => "P5",
            _ => "P1"
        };
        return fld;
    }
    
    public static async Task<string> GenerateTrnNumber(string? mode, IParaDataAccess _para, string? schema, string? conn)
    {
        // Format: "XXXYY-MM9999"
        var yy           = string.Empty;
        var mm           = string.Empty;
        var ctrStr       = string.Empty;
        var trnNumber    = string.Empty;


        // 1. Retrieve the last saved TRN record
        ParaModel? para = await _para._02(mode, schema, conn);

        int? mo = Convert.ToInt32(para?.Month);

        if (para != null)
        {
            yy          = para?.Year!;
            mm          = (mo)?.ToString("D2");
            ctrStr      = para?.CtrName?.ToString("D4")!;
            trnNumber   = $"{mode.ToUpper()}{yy}-{mm}{ctrStr}";
        }

     

        return trnNumber;
    }

    public static double Compute_PayCal_TotalHrs_perEmpamsId(int? empmasId, List<TbltranModel?>? tbltrans, List<DutyrenderedModel?>? rdlst, SettingsModel s )
    {
        
        var hrs = 0.00; 
        foreach (var tran in tbltrans??[])
        {
            var acctNumber = tran?.AcctNumber??"---";
            var rds = rdlst?.Where(x => x?.AcctNumber == acctNumber).ToList();
            if (rds == null) continue;
            if (rds.Count < 1) continue;
            if (tran?.EmpmasId != empmasId) continue;
            var conv = tran.RateTypeId switch
            {
                2 => s.Daytohours,
                3 => s.SemiMonthtodays  * s.Daytohours,
                4 => s.Monthtodays      * s.Daytohours,
                5 => s.Semiannualtodays * s.Daytohours,
                6 => s.Yeartodays       * s.Daytohours,
                _ => 1
            };

            var res = (tran?.Qty ?? 0) * (conv);  
            if (tran?.AcctNumber == "E000") hrs -= res??0;
            else hrs += res??0;
        }

        return hrs; 
    }
    
    public static double Compute_PayCal_Footer_TotalHrs(List<TbltranModel?>? tbltrans, List<DutyrenderedModel?>? rdlst, SettingsModel s )
    {
        
        double? hrs = 0.00; 
        foreach (var tran in tbltrans??[])
        {
            var acctNumber = tran?.AcctNumber??"---";
            var rds = rdlst?.Where(x => x?.AcctNumber == acctNumber).ToList();
            if (rds == null) continue;
            if (rds.Count < 1) continue;
            
            var conv = tran!.RateTypeId switch
            {
                2 => s.Daytohours,
                3 => s.SemiMonthtodays  * s.Daytohours,
                4 => s.Monthtodays      * s.Daytohours,
                5 => s.Semiannualtodays * s.Daytohours,
                6 => s.Yeartodays       * s.Daytohours,
                _ => 1
            };

            var res = (tran?.Qty ?? 0) * (conv);  
            if (tran?.AcctNumber == "E000") hrs -= res;
            else hrs += res;
            
        }
        
        return hrs??0;
    }

    public static Model605 Compute_NetPay(List<TmptbltranemplistModel>? els, List<TbltranModel?>? tbltrans, TmptbltranemplistModel?  footerTotal)
    {
        Model605 m605 = new();
        if (els == null) return m605;
        if (tbltrans == null) return m605;
        
        //---  Compute for the Amount ------------------------------------------------------------------------
        foreach (var tran in tbltrans ?? [])
        {
            tran!.Amount = 0;
            if ((tran.Qty   != 0 || tran?.Qty  != null) && 
                (tran?.Rate != 0 || tran?.Rate != null))
            {
                tran!.Amount = tran.Qty * tran.Rate;
            } 
            
            
        }
        //=================================================================================================

        //---  Compute NetPay [ NP = Earnings - Deductions ] for every Employee ---------------------------
        foreach (var el in els ?? [])
        {
            var empmasId = el?.EmpmasId;
            var trans = tbltrans?.Where(t=>t?.EmpmasId==empmasId).ToList(); 
            var earnings = trans?.Where(t=> (t?.AcctNumber)?[..1] =="E")
                                        .Sum(t=> t?.Amount??0);
            var deductions = trans?.Where(t=> (t?.AcctNumber)?[..1] =="D")
                .Sum(t=> t?.Amount??0);
            
            el!.TotEarnings      = earnings??0;
            el!.TotDeductions    = deductions??0;
            el!.NetPay           = el.TotEarnings - el.TotDeductions;
            
            
        }
        
        //=================================================================================================

        //---  Footer Total  ------------------------------------------------------------------------------
        var totEarnings = tbltrans?.Where(t=> (t?.AcctNumber)?[..1] =="E")
            .Sum(t=> t?.Amount??0);
        var totDeductions = tbltrans?.Where(t=> (t?.AcctNumber)?[..1] =="D")
            .Sum(t=> t?.Amount??0);
        
        footerTotal!.TotEarnings     = totEarnings??0;
        footerTotal!.TotDeductions   = totDeductions??0;
        footerTotal!.NetPay          = totEarnings??0 + totDeductions??0; 
        //=================================================================================================
        
        m605.TmptbltranEmpLists = els!; 
        m605.FooterTotal     = footerTotal;
        return m605; 
    }

    public static Task<Model605?> Compute_NoOfHrs(List<TmptbltranemplistModel>? els, 
                                       List<TbltranModel?>? tbltrans, 
                                       TmptbltranemplistModel?  footerTotal, 
                                       List<DutyrenderedModel?>? rdlst, 
                                       SettingsModel s )
    {
        Model605? m605 = new(); 
        
        //--- Individual duty ------------------------------------------------------------------------------------------
        foreach (var el in els ?? [])
        {
            var hrs = 0.00; 
            
            foreach (var tran in tbltrans??[])
            {
                var acctNumber = tran?.AcctNumber??"---";
                var rds = rdlst?.Where(x => x?.AcctNumber == acctNumber).ToList();
                if (rds == null) continue;
                if (rds.Count < 1) continue;
                if (tran?.EmpmasId != el.EmpmasId) continue;
                var conv = tran.RateTypeId switch
                {
                    2 => s.Daytohours,
                    3 => s.SemiMonthtodays  * s.Daytohours,
                    4 => s.Monthtodays      * s.Daytohours,
                    5 => s.Semiannualtodays * s.Daytohours,
                    6 => s.Yeartodays       * s.Daytohours,
                    _ => 1
                };

                var res = (tran?.Qty ?? 0) * (conv);  
                if (tran?.AcctNumber == "E000") hrs -= res??0;
                else hrs += res??0;
            }
            
            
            el!.TotHours = hrs; 
        }
        //==============================================================================================================
        var totHrs = els?.Sum(t=> t!.TotHours);
        footerTotal!.TotHours = totHrs??0;

        m605.TmptbltranEmpLists = []; 
        if(m605.TmptbltranEmpLists!=null)  m605.TmptbltranEmpLists = els!; 
        m605.FooterTotal = footerTotal;
        
        return Task.FromResult(m605)!;
    }

    public static List<TimeoptionModel> _02Hours(int? intervalMinutes = 30)
    {
        List<TimeoptionModel> tos = new();

        for (int? ctr = 0; ctr < 24; ctr++)
        {
            int? basePin = ctr * 100;

            if (intervalMinutes > 0)
            {
                for (int? i = 0; i < 60; i += intervalMinutes)
                {
                    int? pin = basePin + i;

                    int? hr  = pin / 100;
                    int? min = pin % 100;

                    string? ampm = hr >= 12 ? " pm" : " am";

                    int? displayHr = hr % 12;
                    if (displayHr == 0) displayHr = 12;

                    TimeoptionModel to = new()
                    {
                        Value = pin,
                        Text = $"{displayHr.ToString().PadLeft(2,'0')}:{min.ToString().PadLeft(2,'0')}{ampm}"
                    };

                    tos.Add(to);
                }
            }
            else
            {
                int? hr  = basePin / 100;
                int? min = basePin % 100;

                string? ampm = hr >= 12 ? " pm" : " am";

                int? displayHr = hr % 12;
                if (displayHr == 0) displayHr = 12;

                tos.Add(new TimeoptionModel
                {
                    Value = basePin,
                    Text = $"{displayHr.ToString().PadLeft(2,'0')}:{min.ToString().PadLeft(2,'0')}{ampm}"
                });
            }
        }

        return tos;
    }

    public static List<TimedurationModel> _02HourDurations(int? interval = 50)
    {

        List<TimedurationModel> tds = []; 
        for(int? ctr = interval; ctr < 2400; ctr += interval)
        {
            int? val = ctr; 
            int? hr  = val / 100;
            int? dec = val % 100;

            string? text = $"{hr}.{dec.ToString().PadRight(2,'0')}"; 
            TimedurationModel td = new() {Value=val, Text=text}; 
            tds.Add(td); 
        }

        return tds; 
    }




}




