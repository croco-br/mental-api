using System;
using System.Collections.Generic;
using System.Text;

namespace Croco.Mental.Domain.Models
{
    /// <summary>
    /// A questionnaire representing a PANAS-VRP.
    /// Original study can be found here: http://www.scielo.mec.pt/scielo.php?script=sci_abstract&pid=S0874-20492014000100005&lng=pt&nrm=i
    /// </summary>
    public sealed class MoodQuestionnaire
    {
        public MoodQuestionnaire() => this.Questions = new List<MoodQuestion>();
        public int QuestionnaireId { get; set; }
        public List<MoodQuestion> Questions { get; set; }
    }
}
