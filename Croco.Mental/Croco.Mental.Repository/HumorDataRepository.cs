using Croco.Mental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Repository
{
    public sealed class HumorDataRepository : IHumorDataRepository
    {
        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}
