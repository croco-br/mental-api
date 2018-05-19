using System;
using System.Collections.Generic;
using System.Text;

namespace Croco.Mental.Domain.Models
{
    public sealed class HumorData
    {
        public HumorData()
        {

        }

        public int Id { get; set; }
        public User Owner { get; set; }
        public MoodQuestionnaire Questions { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
