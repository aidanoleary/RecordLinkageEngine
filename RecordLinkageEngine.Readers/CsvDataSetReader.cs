using RecordLinkageEngine.Core.Interfaces;
using RecordLinkageEngine.Core.Models;
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

        private List<DataRow> AddRows(string[] csvLines)
        {
            List<DataRow> dataRows = new List<DataRow>();

            foreach (string csvRow in csvLines)
            {
                DataRow currentRow = new DataRow();

                currentRow.DataAttributes = AddAttributes(csvRow);
                dataRows.Add(currentRow);
            }

            return dataRows;
        }

        private List<DataAttribute> AddAttributes(string csvRow)
        {
            List<DataAttribute> attributes = new List<DataAttribute>();

            string[] columns = csvRow.Split(delimiter);
            foreach (string column in columns)
            {
                DataAttribute currentAttribute = new DataAttribute()
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
