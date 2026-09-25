using HRApiLibrary.Models._90_Utils;

namespace HRApiLibrary.DataAccess._90_Utils.Interface
{
    public interface IMsdsDataAccess
    {
        object ObjectMapper(object src, object des);
    }
}
