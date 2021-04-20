using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Models.Format
{
    public class FormatConfiguration
    {
        public List<FormatDataColumn> DataColumns { get; private set; }

        public FormatConfiguration(List<FormatDataColumn> dataColumns)
        {
            this.DataColumns = dataColumns;
        }

        public FormatConfiguration()
        {
            this.DataColumns = new List<FormatDataColumn>();
        }

    }
}
