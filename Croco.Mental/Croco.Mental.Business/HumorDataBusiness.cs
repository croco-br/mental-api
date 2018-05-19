using Croco.Mental.Business.Interfaces;
using Croco.Mental.Domain.Models;
using Croco.Mental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Business
{
    public sealed class HumorDataBusiness : IHumorDataBusiness
    {
        private readonly IHumorDataRepository _humorDataRepository;
        public HumorDataBusiness(IHumorDataRepository humorDataRepository)
        {
            _humorDataRepository = humorDataRepository;
        }

        public async Task<IEnumerable<HumorData>> GetAll()
        {
            return await _humorDataRepository.GetAll();
        }

        public async Task<HumorData> GetById(int id)
        {
            return await _humorDataRepository.GetById(id);
        }

        public async Task<bool> Save(HumorData data)
        {            
            return await _humorDataRepository.Save(data);
        }
    }
}
