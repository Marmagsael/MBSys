using MBApiLibrary.Models._10_Pis;

namespace MBApiLibrary.DataAccess._10_Pis.Interface
{
    public interface IInvDataAccess
    {
        Task<InvModel?> _01(InvModel inv, string? schema, string? conn);
        Task<InvModel?> _02(int? id, string? schema, string? conn);
        Task<InvModel?> _03(int? id, InvModel inv, string? schema, string? conn);
        Task<InvModel?> _04(int? id, string? schema, string? conn);
    }
}