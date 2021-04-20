using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Models.InputData
{
    public class InputDataRow
    {
        public List<InputDataAttribute> DataAttributes { get; set; }

        public InputDataRow()
        {
            DataAttributes = new List<InputDataAttribute>();
        }
    }
}
