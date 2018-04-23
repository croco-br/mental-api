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

        public Task<IEnumerable<HumorData>> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<HumorData>(COLLECTION_NAME);

                    var list = col.FindAll();
                    return Task.FromResult(list);
                }
            }
            catch (Exception ex)
            {
                //TODO: log
                throw;
            }
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

        public async Task<HumorData> GetById(int id)
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<HumorData>(COLLECTION_NAME);

                    return col.FindOne(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                //TODO: log
                throw;
            }
        }
    }
}
