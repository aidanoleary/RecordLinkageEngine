using RecordLinkageEngine.Core.DataSetComparers;
using RecordLinkageEngine.Core.Interfaces;
using RecordLinkageEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core
{
    public class RecordLinkageService
    {
        private IDataSetComparer dataComparer;
        private IDataSetReader dataSetOneReader;
        private IDataSetReader dataSetTwoReader;
        private IResultWriter resultWriter;

        public RecordLinkageService(IDataSetReader dataSetOneReader, IDataSetReader dataSetTwoReader, IResultWriter resultWriter)
            : this(new DataSetComparer(), dataSetOneReader, dataSetTwoReader, resultWriter)
        {
        }

        public RecordLinkageService(IDataSetComparer dataComparer, IDataSetReader dataSetOneReader, IDataSetReader dataSetTwoReader, IResultWriter resultWriter)
        {
            this.dataComparer = dataComparer;
            this.dataSetOneReader = dataSetOneReader;
            this.dataSetTwoReader = dataSetTwoReader;
            this.resultWriter = resultWriter;
        }

        public void CompareAndOutputResults()
        {
            InputDataSet dataSetOne = dataSetOneReader.ReadDataSet();
            InputDataSet dataSetTwo = dataSetTwoReader.ReadDataSet();
            ResultDataSet resultDataSet = dataComparer.CompareData(dataSetOne, dataSetTwo);
            resultWriter.WriteResult(resultDataSet);
        }

    }
}
