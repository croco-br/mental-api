using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Interfaces.Repositories
{
    public interface IManagementRepository
    {
        Task<bool> Delete();  
    }
}
