using Croco.Mental.Domain.Enums;
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
        public MoodDefinition Emotion { get; set; }
        public MoodLevel Level { get; set; }
    }


}
