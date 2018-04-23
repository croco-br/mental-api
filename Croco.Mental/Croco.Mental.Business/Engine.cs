using Croco.Mental.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Croco.Mental.Repository;
using Croco.Mental.Repository.Interfaces;

namespace Croco.Mental.Business
{
    public sealed class Engine : IEngine
    {
        private readonly IHumorDataRepository _humorDataRepository;
        private readonly IUserRepository _userRepository;

        public Engine(IHumorDataRepository humorDataRepository, IUserRepository userRepository)
        {
            _humorDataRepository = humorDataRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> RecommendActions(int userId)
        {
            var user = _userRepository.GetById(userId);
            _humorDataRepository.GetById(userId);

            return true;
        }
    }
}
