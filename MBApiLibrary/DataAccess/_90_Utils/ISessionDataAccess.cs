
using MBApiLibrary.Models;

namespace MBApiLibrary.DataAccess._90_Utils; 

public interface ISessionDataAccess
{
    Task<SessionInfo> _01Session_Schema_ByUsercompanyId(int? id);
    SessionInfo _02Schema();
}