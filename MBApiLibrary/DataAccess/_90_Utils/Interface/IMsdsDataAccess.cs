using MBApiLibrary.Models._90_Utils;

namespace MBApiLibrary.DataAccess._90_Utils.Interface
{
    public interface IMsdsDataAccess
    {
        object ObjectMapper(object src, object des);
    }
}
