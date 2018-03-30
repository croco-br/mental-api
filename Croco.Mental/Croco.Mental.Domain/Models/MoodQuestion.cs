using System;
using System.Collections.Generic;
using System.Text;

namespace Croco.Mental.Domain.Models
{
    /// <summary>
    /// Individual item from PANAS-VRP methodology.
    /// Original study can be found here: http://www.scielo.mec.pt/scielo.php?script=sci_abstract&pid=S0874-20492014000100005&lng=pt&nrm=i
    /// </summary>
    public sealed class MoodQuestion
    {
        /// <summary>
        /// Gender neutral emotion definition.
        /// </summary>
        public enum MoodDefinition
        {
            Interessadx,
            Nervosx,
            Entusiasmadx,
            Amedrontadx,
            Inspiradx,
            Ativx,
            Assustadx,
            Culpadx,
            Determinadx,
            Atormentadx
        }

        /// <summary>
        /// Level of emotions.
        /// </summary>
        public enum MoodLevel
        {
            Nada = 1,
            Pouco = 2,
            Moderadamente = 3,
            Bastante = 4,
            Extremamente = 5
        }

        public MoodDefinition Emotion { get; set; }
        public MoodLevel Level { get; set; }
    }


}
