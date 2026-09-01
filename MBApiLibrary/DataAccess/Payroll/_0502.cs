using MBApiLibrary.DataAccess._90_Utils.Interface;
using Microsoft.Extensions.Configuration;

namespace MBApiLibrary.DataAccess.Payroll;

public class _0502
{
    private readonly I_90_001_MySqlDataAccess _sql;
    private readonly IConfiguration _config;

    public _0502(I_90_001_MySqlDataAccess sql, IConfiguration config)
    {
        _sql = sql;
        _config = config;
    }
    
    public async Task<List<ODeprecModel>?> _02ByFieldId(string? fieldName, int? fieldIdValue, string? schema, string? conn)
    {

        

        string? sql = $@"SELECT d.*,  s.Name EmpStatus, 
                                CONCAT(TRIM(COALESCE(e.EmpLastNm, '')), ', ',  
                                       TRIM(COALESCE(e.EmpFirstNm, '')), ' ', 
                                       TRIM(COALESCE(e.EmpMidNm, ''))) AS Empname
                            FROM {schema}.Deprec d 
                            LEFT JOIN {schema}.Empmas  e ON e.Empnumber = d.Empnumber 
                            LEFT JOIN {schema}.Empstat s ON e.Empstat_ = s.Code 
                            WHERE d.{fieldName} = @FieldIdValue ORDER BY EmpLastNm, EmpFirstNm, EmpMidNm ";

        var data = await _sql.FetchData<ODeprecModel?, dynamic>(sql, new { FieldIdValue = fieldIdValue }, conn);
        return data;
    }
}