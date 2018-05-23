using System;
using System.Collections.Generic;
using System.Text;

namespace Croco.Mental.Domain.Models
{
    public sealed class RecommendationResponse
    {
        public int GoodScore { get; set; }
        public int BadScore { get; set; }
        public int Score { get; set; }
    }
}
