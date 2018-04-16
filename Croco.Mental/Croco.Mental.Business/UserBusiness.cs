using Croco.Mental.Business.Interfaces;
using Croco.Mental.Domain.Models;
using Croco.Mental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Business
{
    public sealed class UserBusiness : IUserBusiness
    {
        public readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<bool> Save(User entity)
        {
            return await _userRepository.Save(entity);
        }
    }
}