using RecordLinkageEngine.Core.Models.Format;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.Interfaces
{
    public interface IFormatConfigurationReader
    {
        FormatConfiguration ReadFormatConfiguration();
    }
}
