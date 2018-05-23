using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetById(int id);
        Task<List<Questionnaire>> GetQuestionnairesByUser(int id);
        Task<List<User>> GetAll();
        Task<bool> Save(User entity);
    }
}
