using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Models
{
    public class DataRow
    {
        public List<DataAttribute> DataAttributes { get; set; }

        public DataRow()
        {
            this.DataAttributes = new List<DataAttribute>();
        }
    }
}
