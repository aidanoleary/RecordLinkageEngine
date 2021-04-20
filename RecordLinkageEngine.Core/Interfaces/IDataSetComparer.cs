using RecordLinkageEngine.Core.Models;
using RecordLinkageEngine.Core.Models.InputData;
using RecordLinkageEngine.Core.Models.OutputData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Interfaces
{
    public interface IDataSetComparer
    {
        ResultDataSet CompareData(InputDataSet dataSetOne, InputDataSet dataSetTwo);
    }
}
