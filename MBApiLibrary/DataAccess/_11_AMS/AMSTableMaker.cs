using MBApiLibrary.DataAccess._90_Utils.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBApiLibrary.DataAccess._11_AMS;

public class AMSTableMaker : IAMSTableMaker
{
    private readonly I_90_001_MySqlDataAccess _sql;

    public AMSTableMaker(I_90_001_MySqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task _01AMSTable(string schema, string connName = "MySqlConn")
    {
        try
        {
            await _01AttSchedDefault(schema, connName);
            await _01AttSchedWeeklyHdr(schema, connName);
            await _01AttSchedWeeklyDtl(schema, connName);
        }

        catch (Exception ex)    {   Console.WriteLine($"Error in _01AttSchedDefault: {ex}"); }

    }

    private async Task _01AttSchedDefault(string schema, string connName)
    {
        var sql = $@"CREATE TABLE if not exists {schema}.AttSchedDefault (
                          Id                    INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
                          D1_In                 int             DEFAULT 0,
                          D1_HrsLength          int             DEFAULT 0,
                          D1_DutyType           char(2)         DEFAULT 'RD',
                          D2_In                 int             DEFAULT 800,
                          D2_HrsLength          int             DEFAULT 9,
                          D2_DutyType           char(2)         DEFAULT 'R',
                          D3_In                 int             DEFAULT 800,
                          D3_HrsLength          int             DEFAULT 9,
                          D3_DutyType           char(2)         DEFAULT 'R',
                          D4_In                 int             DEFAULT 800,
                          D4_HrsLength          int             DEFAULT 9,
                          D4_DutyType           char(2)         DEFAULT 'R',
                          D5_In                 int             DEFAULT 800,
                          D5_HrsLength          int             DEFAULT 9,
                          D5_DutyType           char(2)         DEFAULT 'R',
                          D6_In                 int             DEFAULT 800,
                          D6_HrsLength          int             DEFAULT 9,
                          D6_DutyType           char(2)         DEFAULT 'R',
                          D7_In                 int             DEFAULT 0,
                          D7_HrsLength          int             DEFAULT 0,
                          D7_DutyType           char(2)         DEFAULT 'RN',
                          PRIMARY KEY(`Id`)
                        ) ENGINE = InnoDB DEFAULT CHARSET = latin1;";
        await _sql.ExecuteCmd(sql, new { }, connName);
    }
    
    private async Task _01AttSchedWeeklyHdr(string schema, string connName)
    {
        var sql = $@"CREATE TABLE if not exists {schema}.AttSchedWeeklyHdr (
                          Id                    INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
                          Code                  char(15)         DEFAULT '-',
                          Description           char(60)         DEFAULT 'R',
                          PRIMARY KEY(`Id`)
                        ) ENGINE = InnoDB DEFAULT CHARSET = latin1;";
        await _sql.ExecuteCmd(sql, new { }, connName);
    }
    private async Task _01AttSchedWeeklyDtl(string schema, string connName)
    {
        var sql = $@"CREATE TABLE if not exists {schema}.AttSchedWeeklyDtl (
                          Id                    INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
                          D1_In                 int             DEFAULT 0,
                          D1_HrsLength          int             DEFAULT 0,
                          D1_DutyType           char(2)         DEFAULT 'RD',
                          D2_In                 int             DEFAULT 800,
                          D2_HrsLength          int             DEFAULT 9,
                          D2_DutyType           char(2)         DEFAULT 'R',
                          D3_In                 int             DEFAULT 800,
                          D3_HrsLength          int             DEFAULT 9,
                          D3_DutyType           char(2)         DEFAULT 'R',
                          D4_In                 int             DEFAULT 800,
                          D4_HrsLength          int             DEFAULT 9,
                          D4_DutyType           char(2)         DEFAULT 'R',
                          D5_In                 int             DEFAULT 800,
                          D5_HrsLength          int             DEFAULT 9,
                          D5_DutyType           char(2)         DEFAULT 'R',
                          D6_In                 int             DEFAULT 800,
                          D6_HrsLength          int             DEFAULT 9,
                          D6_DutyType           char(2)         DEFAULT 'R',
                          D7_In                 int             DEFAULT 0,
                          D7_HrsLength          int             DEFAULT 0,
                          D7_DutyType           char(2)         DEFAULT 'RN',
                          PRIMARY KEY(`Id`)
                        ) ENGINE = InnoDB DEFAULT CHARSET = latin1;";
        await _sql.ExecuteCmd(sql, new { }, connName);
    }


}

public interface IAMSTableMaker
{
    Task _01AMSTable(string schema, string connName = "MySqlConn");
}
