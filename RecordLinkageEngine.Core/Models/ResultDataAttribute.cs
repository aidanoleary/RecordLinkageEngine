using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Models
{
    public class ResultDataAttribute
    {
        public DataAttribute DataSetOneAttribute { get; set; }
        
        public DataAttribute DataSetTwoAttribute { get; set; }
        
        public double ComparisonScore { get; set; }
    }
}
