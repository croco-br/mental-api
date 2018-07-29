using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Business.Interfaces
{
    public interface IQuestionnaireBusiness
    {
        Task<IEnumerable<Questionnaire>> GetAll();
        Task<IEnumerable<Questionnaire>> GetByUser(int userId);
        Task<Questionnaire> GetById(int id);
        Task<bool> Save(Questionnaire data);
    }
}