using Croco.Mental.Domain.Interfaces.Services;
using Croco.Mental.Domain.Models;
using Croco.Mental.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Croco.Mental.Domain.Services
{
    public sealed class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IQuestionnaireRepository _questionnaireRepository;

        public UserService(IUserRepository userRepository, IQuestionnaireRepository questionnaireRepository)
        {
            _userRepository = userRepository;
            _questionnaireRepository = questionnaireRepository;
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<List<Questionnaire>> GetQuestionnairesByUser(int id)
        {
            return await _questionnaireRepository.GetByUser(id);
        }

        public async Task<bool> Save(User entity)
        {
            return await _userRepository.Save(entity);
        }
    }
}