using Croco.Mental.Domain.Interfaces;
using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Domain.Business
{
    public sealed class UserBusiness : IUserBusiness
    {
        public async Task<User> GetUserById(string id)
        {
            return new User()
            {
                Id = 1,
                Name = "Fulano da Silva",               
            };
        }
    }
}