using RecordLinkageEngine.Core.Models.InputData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Models.OutputData
{
    public class ResultDataAttribute
    {
        public InputDataAttribute DataSetOneAttribute { get; set; }
        
        public InputDataAttribute DataSetTwoAttribute { get; set; }
        
        public double ComparisonScore { get; set; }
    }
}
