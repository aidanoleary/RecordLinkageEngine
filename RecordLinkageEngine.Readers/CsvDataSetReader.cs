using RecordLinkageEngine.Core.Interfaces;
using RecordLinkageEngine.Core.Models.InputData;
using System;
using System.Collections.Generic;
using System.IO;

namespace RecordLinkageEngine.Readers
{
    public class CsvDataSetReader : IDataSetReader
    {
        private string fileLocation;
        private string delimiter;

        public CsvDataSetReader(string fileLocation, string delimiter)
        {
            this.fileLocation = fileLocation;
            this.delimiter = delimiter;
        }

        public InputDataSet ReadDataSet()
        {
            string[] csvContentLines = File.ReadAllLines(this.fileLocation);
            InputDataSet dataSet = new InputDataSet();

            dataSet.DataRows = AddRows(csvContentLines);

            return dataSet;
        }

        private List<InputDataRow> AddRows(string[] csvLines)
        {
            List<InputDataRow> dataRows = new List<InputDataRow>();

            foreach (string csvRow in csvLines)
            {
                InputDataRow currentRow = new InputDataRow();

                currentRow.DataAttributes = AddAttributes(csvRow);
                dataRows.Add(currentRow);
            }

            return dataRows;
        }

        private List<InputDataAttribute> AddAttributes(string csvRow)
        {
            List<InputDataAttribute> attributes = new List<InputDataAttribute>();

            string[] columns = csvRow.Split(delimiter);
            foreach (string column in columns)
            {
                InputDataAttribute currentAttribute = new InputDataAttribute()
                {
                    DataType = typeof(string),
                    DataValue = column
                };
                attributes.Add(currentAttribute);
            }

            return attributes;
        }
    }
}
