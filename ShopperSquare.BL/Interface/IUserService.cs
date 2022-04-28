using ShopperSquare.DL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopperSquare.BL.Interface
{
    public interface IUserService
    {
        public Task<bool> RegisterUser(UserBL newUser);
        public Task<bool> ValidLogin(UserLoginBL loginBL);
        public Task<bool> GenerateResetPasswordCode(string emailId);
        public Task<bool> ResetPasswordByCode(string emailId, string resetCode, string newPassword);
    }
}
