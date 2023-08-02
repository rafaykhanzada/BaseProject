using Core.Data.DTOs;
using Core.Data.Entities;
using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IAuthService
    {
        public Task<ResultModel> Login([FromBody] LoginVM model);
        public Task<ResultModel> Register([FromBody] UserVM model);
        public Task<ResultModel> RefreshToken([FromBody] TokenRequestVM model);
    }
}
