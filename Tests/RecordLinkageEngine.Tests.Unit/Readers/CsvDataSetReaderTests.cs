using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordLinkageEngine.Core.Models.InputData;
using RecordLinkageEngine.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecordLinkageEngine.Tests.Unit.Readers
{
    [TestClass]
    public class CsvDataSetReaderTests
    {
        private CsvDataSetReader csvDataSetReader;

        public CsvDataSetReaderTests()
        {
            string testDataLocation = $"{Directory.GetCurrentDirectory()}//TestData/csv_reader_test_data.csv";
            this.csvDataSetReader = new CsvDataSetReader(testDataLocation, ",");
        }

        [TestMethod]
        public void ReadDataSet_TestData_ReturnsDataSetWithTwoRowsWithFourAttributes()
        {
            // Act
            InputDataSet dataSet = csvDataSetReader.ReadDataSet();

            //Assert
            Assert.AreEqual(2, dataSet.DataRows.Count);
            Assert.AreEqual(4, dataSet.DataRows[0].DataAttributes.Count);
            Assert.AreEqual(4, dataSet.DataRows[1].DataAttributes.Count);
        }
    }
}
