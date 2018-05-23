using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Croco.Mental.Domain.Models;

namespace Croco.Mental.Domain.Interfaces.Services
{
   public interface IRecommendationService
    {
        Task<RecommendationResponse> RecommendActions(int userId);
    }
}
