using Croco.Mental.Business.Interfaces;
using Croco.Mental.Domain.Models;
using Croco.Mental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Business
{
    public sealed class QuestionnaireBusiness : IQuestionnaireBusiness
    {
        private readonly IQuestionnaireRepository _humorDataRepository;
        public QuestionnaireBusiness(IQuestionnaireRepository humorDataRepository)
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
