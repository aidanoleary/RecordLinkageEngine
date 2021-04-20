using RecordLinkageEngine.Core.Models.InputData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Interfaces
{
    public interface IAttributeComparer
    {
        double CompareAttributes(InputDataAttribute attributeOne, InputDataAttribute attributeTwo);
    }
}
