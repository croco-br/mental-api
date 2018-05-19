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
        private readonly ILogRepository _logger;

        public HumorDataRepository(ILogRepository logRepository)
        {
            _logger = logRepository;
        }

        private const string COLLECTION_NAME = "HumorData";

        public async Task<IEnumerable<HumorData>> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<HumorData>(COLLECTION_NAME);

                    return col.FindAll();

                }
            }
            catch (Exception ex)
            {
               await _logger.Save(new LogEntry() {
                    Message = ex.Message,
                    Origin = "HumorDataRepository.GetAll()"
                });
                throw;
            }
        }

        public async Task<bool> Save(HumorData entity)
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<HumorData>(COLLECTION_NAME);

                    col.EnsureIndex(x => x.Id, true);

                    col.Insert(entity);

                    return true;
                }
            }
            catch (Exception ex)
            {
                await _logger.Save(new LogEntry()
                {
                    Message = ex.Message,
                    Origin = "HumorDataRepository.Save()"
                });
                throw;
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
                await _logger.Save(new LogEntry()
                {
                    Message = ex.Message,
                    Origin = "HumorDataRepository.GetById()"
                });
                throw;
            }
        }

        public async Task<IEnumerable<HumorData>> GetByUser(User user)
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<HumorData>(COLLECTION_NAME);

                    return col.Find(x => x.Owner.Id == user.Id);
                }
            }
            catch (Exception ex)
            {
                await _logger.Save(new LogEntry()
                {
                    Message = ex.Message,
                    Origin = "HumorDataRepository.GetByUser()"
                });
                throw;
            }
        }
    }
}
