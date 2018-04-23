using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Croco.Mental.Domain.Models;

namespace Croco.Mental.Business.Interfaces
{
   public interface IEngine
    {
        Task<bool> RecommendActions(int userId);
    }
}
