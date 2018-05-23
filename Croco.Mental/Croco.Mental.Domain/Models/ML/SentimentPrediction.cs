﻿using Microsoft.ML.Runtime.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Croco.Mental.Domain.Models.ML
{
    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Sentiment;
    }
}
