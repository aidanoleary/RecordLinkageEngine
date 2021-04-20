using RecordLinkageEngine.Core.Interfaces;
using RecordLinkageEngine.Core.Models.Format;
using System;
using System.IO;

namespace RecordLinkageEngine.Readers
{
    public class CsvFormatConfigurationReader : IFormatConfigurationReader
    {
        private string fileLocation;
        private string delimeter;

        public CsvFormatConfigurationReader(string fileLocation, string delimeter)
        {
            this.fileLocation = fileLocation;
            this.delimeter = delimeter;
        }

        public FormatConfiguration ReadFormatConfiguration()
        {
            string[] csvContentLines = File.ReadAllLines(this.fileLocation);

            FormatConfiguration configuration = new FormatConfiguration();
            foreach(string line in csvContentLines)
            {
                string[] configAttributes = line.Split(delimeter);

                string dataType = configAttributes[0];
                int index = int.Parse(configAttributes[1]);
                bool isUsed = bool.Parse(configAttributes[2]);

                configuration.DataColumns.Add(new FormatDataColumn(dataType, index, isUsed));
            }

            return configuration;
        }
    }
}
