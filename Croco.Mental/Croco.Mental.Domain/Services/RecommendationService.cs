using Croco.Mental.Domain.Interfaces.Services;
using Croco.Mental.Domain.Models;
using Croco.Mental.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Croco.Mental.Domain.Services
{
    public sealed class RecommendationService : IRecommendationService
    {
        private readonly IQuestionnaireRepository _humorDataRepository;
        private readonly IUserRepository _userRepository;

        public RecommendationService(IQuestionnaireRepository humorDataRepository, IUserRepository userRepository)
        {
            _humorDataRepository = humorDataRepository;
            _userRepository = userRepository;
        }

        public async Task<List<RecommendationResponse>> RecommendActions(int userId)
        {
            var questionnaires = await _humorDataRepository.GetByUser(userId);

            var masterAnswers = questionnaires.ToList<Questionnaire>();

            int badScore = 0;
            int goodScore = 0;

            var response = new List<RecommendationResponse>();

            //find good emotions
            foreach (var item in masterAnswers)
            {
                goodScore = 0;
                badScore = 0;

                foreach (var question in item.Questions)
                {
                    var result = EvaluateAnswer(question);
                    if (result <= 0)
                    {
                        badScore -= result;
                    }
                    else
                    {
                        goodScore += result;
                    }
                }

                response.Add(new RecommendationResponse()
                {
                    Timestamp = item.Timestamp,
                    GoodScore = goodScore,
                    BadScore = badScore,
                    Score = goodScore - badScore
                });
            }
           
            return response;
        }       

        private int EvaluateAnswer(MoodQuestion question)
        {
            switch (question.Emotion)
            {
                //bad emotions
                case Enums.MoodDefinition.Nervosx:
                case Enums.MoodDefinition.Assustadx:
                case Enums.MoodDefinition.Amedrontadx:
                case Enums.MoodDefinition.Culpadx:
                case Enums.MoodDefinition.Atormentadx:

                    switch (question.Level)
                    {
                        //good
                        case Enums.MoodLevel.Nada:
                            return 1;

                        //neutral
                        case Enums.MoodLevel.Pouco:
                            return 0;

                        //bad
                        case Enums.MoodLevel.Moderadamente:
                        case Enums.MoodLevel.Bastante:
                        case Enums.MoodLevel.Extremamente:
                            return -2;
                    }

                    break;

                //good emotions
                case Enums.MoodDefinition.Entusiasmadx:
                case Enums.MoodDefinition.Interessadx:
                case Enums.MoodDefinition.Inspiradx:
                case Enums.MoodDefinition.Ativx:
                case Enums.MoodDefinition.Determinadx:

                    switch (question.Level)
                    {
                        //bad
                        case Enums.MoodLevel.Nada:
                        case Enums.MoodLevel.Pouco:
                            return -1;

                        //neutral                
                        case Enums.MoodLevel.Moderadamente:
                            return 0;

                        //good
                        case Enums.MoodLevel.Bastante:
                        case Enums.MoodLevel.Extremamente:
                            return 2;
                    }

                    break;
            }

            throw new Exception("Invalid Mood Parameters");
        }
    }
}