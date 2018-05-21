using System;
using System.Collections.Generic;
using System.Text;

namespace Croco.Mental.Domain.Models
{
    public sealed class Questionnaire
    {
        public int OwnerId { get; set; }
        public int QuestionnaireId { get; set; }      
        public List<MoodQuestion> Questions { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
