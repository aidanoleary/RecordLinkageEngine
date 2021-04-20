using RecordLinkageEngine.Core.Models.InputData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Interfaces
{
    public interface IDataSetReader
    {
        InputDataSet ReadDataSet();
    }
}
