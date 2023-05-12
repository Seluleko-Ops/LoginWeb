using ASTechLogin.Data;
using ASTechLogin.Helpers;
using ASTechWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ASTechWeb.Services
{
    public class AuthService
    {
        protected TechDbContext _dbContext;

        public AuthService()
        {
            _dbContext = new TechDbContext();
        }


        /// <summary>
        /// User Login Authentication
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResultM> Authenticate(LoginM model)
        {
            var users = await _dbContext.user.FirstOrDefaultAsync(i => i.IdNumber == model.IdNumber);

            if (users == null)
            {
                return new ResultM
                {
                    IsSuccessful = false,
                    Message = "Sorry! ID/Passport or Password Invalid",
                    Data = (int)HttpStatusCode.Unauthorized

                };
            }

            if (!HashManager.VerifyPassword(model.Password, users.Password))
            {
                return new ResultM
                {
                    IsSuccessful = false,
                    Message = "Sorry! ID/Passport or Password Invalid",
                    Data = (int)HttpStatusCode.Unauthorized

                };
            }

            return new ResultM
            {
                IsSuccessful = true,
                Message = "Succefully Logged In!",
                Data = (int)HttpStatusCode.OK

            };
        }
    }
}
