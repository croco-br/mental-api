using Croco.Mental.Domain.Models;
using Croco.Mental.Interfaces.Repositories;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Repository
{
    public sealed class UserRepository : IUserRepository
    {
        private const string COLLECTION_NAME = "Users";
        private readonly ILogRepository _logger;

        public UserRepository(ILogRepository logRepository)
        {
            _logger = logRepository;
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<User>(COLLECTION_NAME);

                    return new List<User>(col.FindAll());
                }
            }
            catch (Exception ex)
            {
                await _logger.Save(new LogEntry()
                {
                    Message = ex.Message,
                    Origin = "UserRepository.GetAll()"
                });
                throw;
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<User>(COLLECTION_NAME);

                    return col.FindOne(x => x.UserId == id);
                }
            }
            catch (Exception ex)
            {
                await _logger.Save(new LogEntry()
                {
                    Message = ex.Message,
                    Origin = "UserRepository.GetById()"
                });
                throw;
            }

        }

        public async Task<bool> Save(User entity)
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<User>(COLLECTION_NAME);

                    col.EnsureIndex(x => x.UserId, true);

                    col.Insert(entity);

                    return true;
                }
            }
            catch (Exception ex)
            {
                await _logger.Save(new LogEntry()
                {
                    Message = ex.Message,
                    Origin = "UserRepository.Save()"
                });
                throw;
            }

        }
    }
}
