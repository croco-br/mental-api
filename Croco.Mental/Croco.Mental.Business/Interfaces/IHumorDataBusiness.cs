using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Business.Interfaces
{
    public interface IHumorDataBusiness
    {
        Task<IEnumerable<HumorData>> GetAll();
        Task<HumorData> GetById(int id);
        Task<bool> Save(HumorData data);
    }
}