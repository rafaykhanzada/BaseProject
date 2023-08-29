using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IAuditLoggerService
    {
        void onTransaction(string? LogType, string? InFunction, string? onTask, string Data, string UserId);
        string ExtractJWT(string jwtToken);
        void LogTransactionStatus<T>(string user,string task, object resultModel, string logLevel);
    }
}
