using RecordLinkageEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Interfaces
{
    public interface IResultWriter
    {
        void WriteResult(ResultData resultData);
    }
}
