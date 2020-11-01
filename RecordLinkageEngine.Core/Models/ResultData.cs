using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecordLinkageEngine.Core.Models
{
    public class ResultData
    {
        public List<ResultDataAttribute> ResultDataAttributes { get; set; }

        public ResultData()
        {
            this.ResultDataAttributes = new List<ResultDataAttribute>();
        }

        public double GetOverallScore()
        {
            int numberOfAttributes = this.ResultDataAttributes.Count;
            double totalScores = this.ResultDataAttributes.Sum(attribute => attribute.ComparisonScore);
            double meanScore = totalScores / numberOfAttributes;
            return meanScore;
        }
    }
}
