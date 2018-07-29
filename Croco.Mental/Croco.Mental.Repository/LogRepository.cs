using Croco.Mental.Domain.Models;
using Croco.Mental.Interfaces.Repositories;
using LiteDB;
using System;
using System.Threading.Tasks;

namespace Croco.Mental.Repository
{
    public sealed class LogRepository : ILogRepository
    {
        private const string COLLECTION_NAME = "Log";

        public async Task<bool> Save(LogEntry entity)
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var col = db.GetCollection<LogEntry>(COLLECTION_NAME);

                    col.Insert(entity);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error Logging {0}", ex.Message));
                return false;
            }
        }
    }
}
