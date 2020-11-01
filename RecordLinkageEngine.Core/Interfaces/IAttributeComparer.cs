using RecordLinkageEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Interfaces
{
    public interface IAttributeComparer
    {
        double CompareAttributes(DataAttribute attributeOne, DataAttribute attributeTwo);
    }
}
