using Croco.Mental.Business.Interfaces;
using Croco.Mental.Domain.Models;
using Croco.Mental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Business
{
    public sealed class ManagementBusiness : IManagementBusiness
    {
        public readonly IManagementRepository _repo;

        public ManagementBusiness(IManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> DeleteAll()
        {
            return await _repo.Delete();
        }
    }
}