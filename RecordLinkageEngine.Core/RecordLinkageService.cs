using RecordLinkageEngine.Core.DataSetComparers;
using RecordLinkageEngine.Core.Interfaces;
using RecordLinkageEngine.Core.Models;
using RecordLinkageEngine.Core.Models.Format;
using RecordLinkageEngine.Core.Models.InputData;
using RecordLinkageEngine.Core.Models.OutputData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core
{
    public class RecordLinkageService
    {
        private IDataSetComparer dataComparer;
        private IFormatConfigurationReader formatConfigReader;
        private IDataSetReader dataSetOneReader;
        private IDataSetReader dataSetTwoReader;
        private IResultWriter resultWriter;

        public RecordLinkageService(IFormatConfigurationReader formatConfigReader, IDataSetReader dataSetOneReader, IDataSetReader dataSetTwoReader, IResultWriter resultWriter)
            : this(new DataSetComparer(), formatConfigReader, dataSetOneReader, dataSetTwoReader, resultWriter)
        {
        }

        public RecordLinkageService(IDataSetComparer dataComparer, IFormatConfigurationReader formatConfigReader, IDataSetReader dataSetOneReader, IDataSetReader dataSetTwoReader, IResultWriter resultWriter)
        {
            this.dataComparer = dataComparer;
            this.formatConfigReader = formatConfigReader;
            this.dataSetOneReader = dataSetOneReader;
            this.dataSetTwoReader = dataSetTwoReader;
            this.resultWriter = resultWriter;
        }

        public void CompareAndOutputResults()
        {
            FormatConfiguration formatConfiguration = formatConfigReader.ReadFormatConfiguration(); 
            InputDataSet dataSetOne = dataSetOneReader.ReadDataSet();
            InputDataSet dataSetTwo = dataSetTwoReader.ReadDataSet();
            ResultDataSet resultDataSet = dataComparer.CompareData(dataSetOne, dataSetTwo);
            resultWriter.WriteResult(resultDataSet);
        }

    }
}
