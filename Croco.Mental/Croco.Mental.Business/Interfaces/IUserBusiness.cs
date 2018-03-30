using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Business.Interfaces
{
   public interface IUserBusiness
    {
        Task<User> GetUserById(string id);  
    }
}
