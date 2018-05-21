using Croco.Mental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Croco.Mental.Domain.Models
{
    /// <summary>
    /// Individual item from PANAS-VRP methodology.
    /// Original study can be found here: http://www.scielo.mec.pt/scielo.php?script=sci_abstract&pid=S0874-20492014000100005&lng=pt&nrm=i
    /// </summary>
    public sealed class MoodQuestion
    {    
        [Range(0, 9, ErrorMessage = "Invalid Emotion")]
        public MoodDefinition Emotion { get; set; }

        [Range(1, 5, ErrorMessage = "Invalid Emotion Level")]
        public MoodLevel Level { get; set; }
    }


}
