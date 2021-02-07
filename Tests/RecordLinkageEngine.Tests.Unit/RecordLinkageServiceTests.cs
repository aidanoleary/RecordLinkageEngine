using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecordLinkageEngine.Core;
using RecordLinkageEngine.Core.Interfaces;
using RecordLinkageEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Tests.Unit
{
    [TestClass]
    public class RecordLinkageServiceTests
    {
        private Mock<IDataSetReader> mockDataSetReaderOne;
        private Mock<IDataSetReader> mockDataSetReaderTwo;
        private Mock<IDataSetComparer> mockDataSetComparer;
        private Mock<IResultWriter> mockResultWriter;
        private RecordLinkageService recordLinkageService;

        public RecordLinkageServiceTests()
        {
            this.mockDataSetReaderOne = new Mock<IDataSetReader>();
            this.mockDataSetReaderTwo = new Mock<IDataSetReader>();
            this.mockDataSetComparer = new Mock<IDataSetComparer>();
            this.mockResultWriter = new Mock<IResultWriter>();

            this.recordLinkageService = new RecordLinkageService(mockDataSetComparer.Object, mockDataSetReaderOne.Object, mockDataSetReaderTwo.Object, mockResultWriter.Object);
        }

        [TestMethod]
        public void CompareAndOutputResults_ShouldReadDataFromReaders()
        {
            // Act
            this.recordLinkageService.CompareAndOutputResults();

            // Assert
            this.mockDataSetReaderOne.Verify(x => x.ReadDataSet(), Times.Once);
            this.mockDataSetReaderTwo.Verify(x => x.ReadDataSet(), Times.Once);
        }

        [TestMethod]
        public void CompareAndOutputResults_ShouldCompareDataReadFromReaders()
        {
            // Arrange
            InputDataSet dataSetOneData = new InputDataSet();
            this.mockDataSetReaderOne.Setup(x => x.ReadDataSet()).Returns(dataSetOneData);

            InputDataSet dataSetTwoData = new InputDataSet();
            this.mockDataSetReaderTwo.Setup(x => x.ReadDataSet()).Returns(dataSetTwoData);

            // Act
            this.recordLinkageService.CompareAndOutputResults();

            // Assert
            this.mockDataSetComparer.Verify(x => x.CompareData(dataSetOneData, dataSetTwoData), Times.Once);
        }

        [TestMethod]
        public void CompareAndOutputResults_ShouldWriteResultsFromTheDataComparer()
        {
            // Arrange
            ResultDataSet resultData = new ResultDataSet();
            this.mockDataSetComparer.Setup(x => x.CompareData(It.IsAny<InputDataSet>(), It.IsAny<InputDataSet>())).Returns(resultData);

            // Act
            this.recordLinkageService.CompareAndOutputResults();

            // Assert
            this.mockResultWriter.Verify(x => x.WriteResult(resultData));
        }
    }
}
