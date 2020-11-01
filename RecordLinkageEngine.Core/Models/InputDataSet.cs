using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Models
{
    public class InputDataSet
    {
        public List<DataRow> DataRows { get; set; }

        public InputDataSet()
        {
            this.DataRows = new List<DataRow>();
        }
    }
}
