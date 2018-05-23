using Croco.Mental.Domain.Models;
using Croco.Mental.Interfaces.Repositories;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Repository
{
    public sealed class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly ILogRepository _logger;

        public QuestionnaireRepository(ILogRepository logRepository)
        {
            _logger = logRepository;
        }

        private const string COLLECTION_NAME = "Questionnaire";

        public async Task<List<Questionnaire>> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<Questionnaire>(COLLECTION_NAME);

                    return col.FindAll().ToList();

                }
            }
            catch (Exception ex)
            {
               await _logger.Save(new LogEntry() {
                    Message = ex.Message,
                    Origin = "QuestionnaireRepository.GetAll()"
                });
                throw;
            }
        }

        public async Task<bool> Save(Questionnaire entity)
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<Questionnaire>(COLLECTION_NAME);

                    col.EnsureIndex(x => x.QuestionnaireId, true);

                    col.Insert(entity);

                    return true;
                }
            }
            catch (Exception ex)
            {
                await _logger.Save(new LogEntry()
                {
                    Message = ex.Message,
                    Origin = "QuestionnaireRepository.Save()"
                });
                throw;
            }           
        }

        public async Task<Questionnaire> GetById(int id)
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<Questionnaire>(COLLECTION_NAME);

                    return col.FindOne(x => x.QuestionnaireId == id);
                }
            }
            catch (Exception ex)
            {
                await _logger.Save(new LogEntry()
                {
                    Message = ex.Message,
                    Origin = "QuestionnaireRepository.GetById()"
                });
                throw;
            }
        }

        public async Task<List<Questionnaire>> GetByUser(int userId)
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<Questionnaire>(COLLECTION_NAME);

                    return col.Find(x => x.OwnerId == userId).ToList();
                }
            }
            catch (Exception ex)
            {
                await _logger.Save(new LogEntry()
                {
                    Message = ex.Message,
                    Origin = "QuestionnaireRepository.GetByUser()"
                });
                throw;
            }
        }
    }
}
