using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Save(User entity);
        Task<User> GetById(int id);
        Task<List<User>> GetAll();
    }
}
