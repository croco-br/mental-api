﻿using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Repository.Interfaces
{
    public interface IHumorDataRepository
    {
        Task<bool> Save(HumorData entity);
        Task<IEnumerable<HumorData>> GetAll();
        Task<HumorData> GetById(int id);
    }
}
