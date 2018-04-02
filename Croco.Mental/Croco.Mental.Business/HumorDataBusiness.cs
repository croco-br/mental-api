using Croco.Mental.Business.Interfaces;
using Croco.Mental.Domain.Models;
using Croco.Mental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croco.Mental.Business
{
    public sealed class HumorDataBusiness : IHumorDataBusiness
    {
        private readonly IHumorDataRepository _humorDataRepository;
        public HumorDataBusiness(IHumorDataRepository humorDataRepository)
        {
            _humorDataRepository = humorDataRepository;
        }

        public async Task<HumorData> GetById(string id)
        {
            return new HumorData()
            {
                Id = 1,
                Owner = new User()
                {
                    Id = 1,
                    Name = "Fulano da Silva"
                },
                Questions = new MoodQuestionnaire()
                {
                    Questions = new List<MoodQuestion>() {
                        new MoodQuestion(){
                            Emotion = MoodQuestion.MoodDefinition.Amedrontadx,
                            Level = MoodQuestion.MoodLevel.Extremamente
                        },
                        new MoodQuestion(){
                            Emotion = MoodQuestion.MoodDefinition.Determinadx,
                            Level = MoodQuestion.MoodLevel.Extremamente
                        },
                        new MoodQuestion(){
                            Emotion = MoodQuestion.MoodDefinition.Interessadx,
                            Level = MoodQuestion.MoodLevel.Nada                        },
                        new MoodQuestion(){
                            Emotion = MoodQuestion.MoodDefinition.Amedrontadx,
                            Level = MoodQuestion.MoodLevel.Pouco
                        }
                    }
                },
                Timestamp = DateTime.Now
            };
        }

        public async Task<bool> Save(HumorData data)
        {
            return await _humorDataRepository.Save(data);
        }
    }
}
