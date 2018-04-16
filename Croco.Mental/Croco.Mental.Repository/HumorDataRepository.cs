using Croco.Mental.Domain.Models;
using Croco.Mental.Repository.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Repository
{
    public sealed class HumorDataRepository : IHumorDataRepository
    {

        private const string COLLECTION_NAME = "HumorData";

        public Task<List<HumorData>> GetMoodQuestions()
        {
            throw new NotImplementedException();
        }

        public Task<List<HumorData>> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save(HumorData entity)
        {
            using (var db = new LiteDatabase(Configuration.Database))
            {           
                var col = db.GetCollection<HumorData>(COLLECTION_NAME);
     
                col.EnsureIndex(x => x.Id, true);
          
                col.Insert(entity);

                return true;
            }

        }


    }
}
