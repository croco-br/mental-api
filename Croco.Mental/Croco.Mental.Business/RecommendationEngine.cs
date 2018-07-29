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
using System;
using Microsoft.ML.Models;
using Microsoft.ML.Runtime;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML;
using System.Reflection;

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

            await Evaluate();

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

        public async Task<RecommendationResponse> Evaluate()
        {
            var pipeline = new LearningPipeline();

            //load test data

            //TODO: get from embedded resource
            var l = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Croco.Mental.Domain.Data.txt");

            pipeline.Add(new TextLoader<SentimentData>(@"C:\Users\adriano.croco\Source\repos\mental-api\Croco.Mental\Croco.Mental.Domain\Data.txt", useHeader: false, separator: ","));

            //configure output
            pipeline.Add(new TextFeaturizer("Features", "SentimentText"));

            //algorithm
            //TODO: test different algorithms
            pipeline.Add(new FastTreeBinaryClassifier() { NumLeaves = 5, NumTrees = 5, MinDocumentsInLeafs = 2 });

            //TODO: alter sentimentData format
            PredictionModel<SentimentData, SentimentPrediction> model = pipeline.Train<SentimentData, SentimentPrediction>();


            //TODO: persit model
            //model.WriteAsync(@"C:\Users\adriano.croco\Desktop\model.txt");

            //TODO: uses
            model.Predict(new SentimentData() { });

            return null;
        }
    }

    public class SentimentData
    {
        [Column(ordinal: "0")]
        public string SentimentText;
        [Column(ordinal: "1", name: "Label")]
        public float Sentiment;
    }

    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Sentiment;
    }
}
