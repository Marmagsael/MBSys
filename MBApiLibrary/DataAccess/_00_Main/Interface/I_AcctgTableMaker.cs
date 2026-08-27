namespace MBApiLibrary.DataAccess._00_Main.Interface
{
    public interface I_AcctgTableMaker
    {
        Task AccountingTableMaker(string? db, string? conn);
    }
}