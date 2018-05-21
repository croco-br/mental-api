using Croco.Mental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Business.Interfaces
{
    public interface IManagementBusiness
    {
        Task<bool> DeleteAll();
    }
}
