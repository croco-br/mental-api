using System;
using System.Collections.Generic;
using System.Text;

namespace Croco.Mental.Domain.Models
{
    public sealed class RecommendationResponse
    {
        public long GoodScore { get; set; }
        public long BadScore { get; set; }
        public long Score { get; set; }
    }
}
