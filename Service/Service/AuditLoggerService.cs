using AutoMapper;
using Core.Data.Entities;
using Newtonsoft.Json;
using Repository.IRepository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UnitofWork;

namespace Service.Service
{
    public class AuditLoggerService : IAuditLoggerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuditLoggerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void onTransaction(string? LogType, string? InFunction, string? onTask, string Data, string UserId)
        {
            var auditLog = new Logger
            {
                LogType = LogType,
                InFunction = InFunction,
                OnTask = onTask,
                ObjectData = Data,
                DateTime = DateTime.UtcNow,
                UserId = UserId,
            };
            _unitOfWork.AuditLoggerRepository.Insert(auditLog);
            //_unitOfWork.Commit();
        }
        public void onTransactionSuccess( string? InFunction, string? onTask, string Data, string UserId)
        {
            var auditLog = new Logger
            {
                LogType = "I",
                InFunction = InFunction,
                OnTask = onTask,
                ObjectData = Data,
                DateTime = DateTime.UtcNow,
                UserId = UserId,
            };
            _unitOfWork.AuditLoggerRepository.Insert(auditLog);
            //_unitOfWork.Commit();
        }
        public void onTransactionWarning(string? InFunction, string? onTask, string Data, string UserId)
        {
            var auditLog = new Logger
            {
                LogType = "O",
                InFunction = InFunction,
                OnTask = onTask,
                ObjectData = Data,
                DateTime = DateTime.UtcNow,
                UserId = UserId,
            };
            _unitOfWork.AuditLoggerRepository.Insert(auditLog);
            //_unitOfWork.Commit();
        }
        public void onTransactionFail(string? InFunction, string? onTask, string Data, string UserId)
        {
            var auditLog = new Logger
            {
                LogType = "X",
                InFunction = InFunction,
                OnTask = onTask,
                ObjectData = Data,
                DateTime = DateTime.UtcNow,
                UserId = UserId,
            };
            _unitOfWork.AuditLoggerRepository.Insert(auditLog);
            //_unitOfWork.Commit();
        }
        public void LogTransactionStatus<T>(string user,
           string task, object resultModel, string logLevel)
        {
            var callingMethodName = new StackTrace().GetFrame(1).GetMethod().Name;

           onTransaction(logLevel, callingMethodName, task,JsonConvert.SerializeObject(resultModel), user);
        }

        public string ExtractJWT(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }
    }
}
