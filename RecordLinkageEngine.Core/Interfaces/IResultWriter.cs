using RecordLinkageEngine.Core.Models;
using RecordLinkageEngine.Core.Models.OutputData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Interfaces
{
    public interface IResultWriter
    {
        void WriteResult(ResultDataSet resultData);
    }
}
