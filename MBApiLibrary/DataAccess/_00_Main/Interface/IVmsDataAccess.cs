namespace MBApiLibrary.DataAccess._00_Main;

public interface IVmsDataAccess
{
    Task _01SchemaMaker(string? db, string? conn);
}