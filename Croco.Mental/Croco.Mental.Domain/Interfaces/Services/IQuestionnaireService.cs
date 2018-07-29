using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Domain.Interfaces.Services
{
    public interface IQuestionnaireService
    {
        Task<IEnumerable<Questionnaire>> GetAll();
        Task<IEnumerable<Questionnaire>> GetByUser(int userId);
        Task<Questionnaire> GetById(int id);
        Task<bool> Save(Questionnaire data);
    }
}