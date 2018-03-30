using Croco.Mental.Domain.Models;
using Croco.Mental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Repository
{
    public sealed class HumorDataRepository : IHumorDataRepository
    {
        public Task<List<HumorData>> GetMoodQuestions()
        {
            throw new NotImplementedException();
        }

        public Task<List<HumorData>> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(HumorData entity)
        {
           var list = new MoodQuestionnaire()
            {

            };

            return Task.FromResult(true);
        }

      
    }
}
