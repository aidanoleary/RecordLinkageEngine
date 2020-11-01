using RecordLinkageEngine.Core.Models;
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
