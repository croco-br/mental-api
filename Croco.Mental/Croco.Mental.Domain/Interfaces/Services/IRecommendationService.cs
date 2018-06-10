using Croco.Mental.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Croco.Mental.Domain.Interfaces.Services
{
    public interface IRecommendationService
    {
        Task<List<RecommendationResponse>> RecommendActions(int userId);        
    }
}
