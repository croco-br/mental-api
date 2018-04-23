using Croco.Mental.Domain.Models;
using Croco.Mental.Repository.Interfaces;
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
                //TODO: log
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

                    return col.FindOne(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                //TODO: log
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

                    col.EnsureIndex(x => x.Id, true);

                    col.Insert(entity);

                    return true;
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
