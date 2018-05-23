using Croco.Mental.Domain.Interfaces.Services;
using Croco.Mental.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Croco.Mental.Domain.Services
{
    public sealed class ManagementService : IManagementService
    {
        public readonly IManagementRepository _repo;

        public ManagementService(IManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> DeleteAll()
        {
            return await _repo.Delete();
        }
    }
}