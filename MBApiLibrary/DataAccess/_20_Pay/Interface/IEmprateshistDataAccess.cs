using MBApiLibrary.Models._20_Pay;

namespace MBApiLibrary.DataAccess._20_Pay.Interface
{
    public interface IEmprateshistDataAccess
    {
        Task<EmprateshistModel?> _01(EmprateshistModel emprateshist, string? schema, string? conn);
        Task<EmprateshistModel?> _02(int? id, string? schema, string? conn);
    }
}