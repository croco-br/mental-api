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
        private readonly IHumorDataRepository _humorDataRepository;
        private readonly IUserRepository _userRepository;

        public RecommendationEngine(IHumorDataRepository humorDataRepository, IUserRepository userRepository)
        {
            _humorDataRepository = humorDataRepository;
            _userRepository = userRepository;
        }

        public async Task<List<string>> RecommendActions(int userId)
        {
            var user = await _userRepository.GetById(userId);
            var questionnaires = await _humorDataRepository.GetByUser(user);

            var questions = questionnaires.ToList<HumorData>();
            foreach (var q in questions)
            {
                //TODO: do somethingl
            }

            return null;


        }
    }
}
