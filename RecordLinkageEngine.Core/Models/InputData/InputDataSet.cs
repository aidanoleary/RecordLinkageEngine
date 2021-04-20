using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Models.InputData
{
    public class InputDataSet
    {
        public List<InputDataRow> DataRows { get; set; }

        public InputDataSet()
        {
            DataRows = new List<InputDataRow>();
        }
    }
}
