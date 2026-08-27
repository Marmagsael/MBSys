using MBApiLibrary.Models._10_Pis;

namespace MBApiLibrary.DataAccess._10_Pis.Interface
{
    public interface ITrandeviationotherDataAccess
    {
        Task<TrandeviationotherModel?> _01(TrandeviationotherModel Trandeviationother, string? schema, string? conn);
        Task<TrandeviationotherModel?> _02ByTrn(string? trnNumber, string? schema, string? conn);
        Task<TrandeviationotherModel?> _03(string? trnNumber, TrandeviationotherModel Trandeviationother, string? schema, string? conn);
        Task<TrandeviationotherModel?> _04(int? id, string? schema, string? conn);
    }
}