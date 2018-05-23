using Croco.Mental.Domain.Interfaces.Services;
using Croco.Mental.Domain.Models;
using Croco.Mental.Domain.Models.ML;
using Croco.Mental.Interfaces.Repositories;
using Microsoft.ML;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public async Task<RecommendationResponse> RecommendActions(int userId)
        {
            var questionnaires = await _humorDataRepository.GetByUser(userId);

            var masterAnswers = questionnaires.ToList<Questionnaire>();

            int badScore = 0;
            int goodScore = 0;

            //find good emotions
            foreach (var item in masterAnswers)
            {
                foreach (var question in item.Questions)
                {
                    var result = await EvaluateAnswer(question);
                    if (result <= 0)
                    {
                        badScore -= result;
                    }
                    else
                    {
                        goodScore += result;
                    }
                }
            }

            return new RecommendationResponse()
            {
                GoodScore = goodScore,
                BadScore = badScore,
                Score = goodScore - badScore
            };
        }

        public async Task<SentimentPrediction> RecommendActionsUsingModel(int userId)
        {
            var pipeline = new LearningPipeline();

            //load test data                       
            pipeline.Add(new TextLoader<SentimentData>(@"C:\Users\adriano.croco\Source\repos\mental-api\Croco.Mental\Croco.Mental.Domain\Data.txt", useHeader: false, separator: ","));

            //configure output
            pipeline.Add(new TextFeaturizer("Features", "SentimentText"));

            //algorithm
            //TODO: test different algorithms
            pipeline.Add(new FastTreeBinaryClassifier() { NumLeaves = 5, NumTrees = 5, MinDocumentsInLeafs = 2 });
            //pipeline.Add(new FastForestBinaryClassifier() { NumLeaves = 5, NumTrees = 5, MinDocumentsInLeafs = 2 });


            //TODO: alter sentimentData format
            PredictionModel<SentimentData, SentimentPrediction> model = pipeline.Train<SentimentData, SentimentPrediction>();

            //TODO: uses
            return model.Predict(new SentimentData() { });
        }

        private async Task<int> EvaluateAnswer(MoodQuestion question)
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