using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Repository.Interfaces
{
    public interface IQuestionnaireRepository
    {
        Task<bool> Save(Questionnaire entity);
        Task<List<Questionnaire>> GetAll();
        Task<Questionnaire> GetById(int id);
        Task<List<Questionnaire>> GetByUser(int userId);
    }
}
