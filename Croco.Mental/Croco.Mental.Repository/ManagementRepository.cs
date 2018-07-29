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
    public sealed class ManagementRepository : IManagementRepository
    {
        public async Task<bool> Delete()
        {
            try
            {
                using (var db = new LiteDatabase(Configuration.Database))
                {
                    var tables = db.GetCollectionNames().ToList();
                    foreach (var table in tables)
                    {
                        db.DropCollection(table);
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error Deleting {0}", ex.Message));
                return false;
            }
        }


    }
}
