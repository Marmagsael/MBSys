using MBApiLibrary.DataAccess._90_Utils.Interface;

namespace MBApiLibrary.DataAccess._20_Pay;

public class _20_PayProcessDataAccess
{
    private readonly I_90_001_MySqlDataAccess _sql;

    public _20_PayProcessDataAccess(I_90_001_MySqlDataAccess sql)
    {
        _sql = sql;
    }



}
