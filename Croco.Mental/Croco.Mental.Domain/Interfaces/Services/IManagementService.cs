using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Domain.Interfaces.Services
{
    public interface IManagementService
    {
        Task<bool> DeleteAll();
    }
}
