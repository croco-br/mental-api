using Croco.Mental.Domain.Interfaces.Services;
using Croco.Mental.Domain.Models;
using Croco.Mental.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Croco.Mental.Domain.Services
{
    public sealed class QuestionnaireService : IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _humorDataRepository;
        public QuestionnaireService(IQuestionnaireRepository humorDataRepository)
        {
            _humorDataRepository = humorDataRepository;
        }

        public async Task<IEnumerable<Questionnaire>> GetAll()
        {
            return await _humorDataRepository.GetAll();
        }

        public async Task<Questionnaire> GetById(int id)
        {
            return await _humorDataRepository.GetById(id);
        }

        public async Task<IEnumerable<Questionnaire>> GetByUser(int userId)
        {
            return await _humorDataRepository.GetByUser(userId);
        }

        public async Task<bool> Save(Questionnaire data)
        {
            var invalidLevels = data.Questions.FindAll(x => (int)x.Level <= 0 || (int)x.Level > 5);
            if (invalidLevels.Count > 0) {
                throw new InvalidOperationException("Invalid Emotion Level");
            }

            return await _humorDataRepository.Save(data);
        }
    }
}
