using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Models
{
    public class ResultDataSet
    {
        public List<ResultData> ResultDataList { get; set; }

        public ResultDataSet()
        {
            this.ResultDataList = new List<ResultData>();
        }
    }
}
