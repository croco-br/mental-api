﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Repository.Interfaces
{
    public interface IHumorDataRepository
    {
        Task<bool> Save();
    }
}