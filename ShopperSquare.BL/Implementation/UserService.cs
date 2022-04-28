using AutoMapper;
using ShopperSquare.BL.Interface;
using ShopperSquare.DL;
using ShopperSquare.DL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopperSquare.BL.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepo _repo;

        public UserService(IRepo repo)
        {
            _repo = repo;
        }

        public Task<bool> GenerateResetPasswordCode(string emailId)
        {
            return _repo.GenerateResetPasswordCode(emailId);
        }

        public Task<bool> ResetPasswordByCode(string emailId, string resetCode, string newPassword)
        {
            return _repo.ResetPasswordByCode(emailId, resetCode, newPassword);
        }

        public async Task<bool> RegisterUser(UserBL newUser)
        {
            var newEntity = new User
            {
                Name = newUser.Name,
                Age = newUser.Age,
                DateOfBirth = newUser.DateOfBirth,
                Password = newUser.Password,
                EmailId=newUser.EmailId
            };
            //var newEntity = _mapper.Map<User>(newUser);

            return await _repo.RegisterUser(newEntity);
        }

        public async Task<bool> ValidLogin(UserLoginBL loginBL)
        {
            return await _repo.ValidLogin(loginBL.EmailId, loginBL.Password);
        }
    }
}
