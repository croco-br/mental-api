using Croco.Mental.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Croco.Mental.Repository;
using Croco.Mental.Repository.Interfaces;
using Microsoft.ML;
using System.Linq;
using Croco.Mental.Domain.Models;

namespace Croco.Mental.Business
{
    public sealed class RecommendationEngine : IRecommendationEngine
    {
        private readonly IQuestionnaireRepository _humorDataRepository;
        private readonly IUserRepository _userRepository;

        public RecommendationEngine(IQuestionnaireRepository humorDataRepository, IUserRepository userRepository)
        {
            _humorDataRepository = humorDataRepository;
            _userRepository = userRepository;
        }

        public async Task<RecommendationResponse> RecommendActions(int userId)
        {
            var questionnaires = await _humorDataRepository.GetByUser(userId);

            var masterAnswers = questionnaires.ToList<Questionnaire>();


            long goodScore = 0;
            long badScore = 0;

            //find good emotions
            foreach (var item in masterAnswers)
            {
                var good = item.Questions.Where(x => x.Emotion == Domain.Enums.MoodDefinition.Ativx ||
                x.Emotion == Domain.Enums.MoodDefinition.Determinadx ||
                x.Emotion == Domain.Enums.MoodDefinition.Entusiasmadx ||
                x.Emotion == Domain.Enums.MoodDefinition.Inspiradx ||
                x.Emotion == Domain.Enums.MoodDefinition.Interessadx);

                goodScore += good.Sum(x => (long)x.Level);


                //find bad emotions
                var bad = item.Questions.Where(x => x.Emotion == Domain.Enums.MoodDefinition.Amedrontadx ||
                 x.Emotion == Domain.Enums.MoodDefinition.Assustadx ||
                 x.Emotion == Domain.Enums.MoodDefinition.Atormentadx ||
                 x.Emotion == Domain.Enums.MoodDefinition.Culpadx ||
                 x.Emotion == Domain.Enums.MoodDefinition.Nervosx);

                badScore += bad.Sum(x => (long)x.Level);
            }

            return new RecommendationResponse()
            {
                GoodScore = goodScore,
                BadScore = badScore,
                Score = goodScore - badScore
            };
        }
    }
}
