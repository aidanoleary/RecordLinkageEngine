using RecordLinkageEngine.Core.AttributeComparers;
using RecordLinkageEngine.Core.Interfaces;
using RecordLinkageEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.DataSetComparers
{
    public class DataSetComparer : IDataSetComparer
    {
        private Dictionary<Type, IAttributeComparer> attributeComparers;

        public DataSetComparer()
        {
            this.attributeComparers = new Dictionary<Type, IAttributeComparer>();
            InitAttributeComparers();
        }

        private void InitAttributeComparers()
        {
            this.attributeComparers.Add(typeof(string), new StringAttributeComparer());
        }

        public ResultData CompareData(InputDataSet dataSetOne, InputDataSet dataSetTwo)
        {
            throw new NotImplementedException();
        }
    }
}
