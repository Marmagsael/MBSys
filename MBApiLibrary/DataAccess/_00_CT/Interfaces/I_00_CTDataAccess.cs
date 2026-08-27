using MBApiLibrary.Models._00_CT;

namespace MBApiLibrary.DataAccess._00_CT.Interfaces
{
    public interface I_00_CTDataAccess
    {
        Task<List<string?>?> _02Dbs(string? conn);
        Task<List<TableFieldsModel?>?> _02TblFields(string? tblName, string? schema, string? conn);
        Task<List<string?>?> _02Tbls(string? schema, string? conn);
    }
}