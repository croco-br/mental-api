using Croco.Mental.Business.Interfaces;
using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Business
{
    public sealed class HumorDataBusiness : IHumorDataBusiness
    {
        public async Task<HumorData> GetById(string id)
        {
            return new HumorData()
            {
                Id = 1,
                Owner = new User()
                {
                    Id = 1,
                    Name = "Fulano da Silva"
                },
                Question = "Are You Feeling Bad?",
                Value = null,
                Answer = "Yes",
                Timestamp = DateTime.Now
            };
        }

        public Task<bool> Save(HumorData data)
        {
            throw new NotImplementedException();
        }
    }
}
