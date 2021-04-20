using RecordLinkageEngine.Core.AttributeComparers;
using RecordLinkageEngine.Core.Interfaces;
using RecordLinkageEngine.Core.Models;
using RecordLinkageEngine.Core.Models.InputData;
using RecordLinkageEngine.Core.Models.OutputData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public ResultDataSet CompareData(InputDataSet dataSetOne, InputDataSet dataSetTwo)
        {
            ResultDataSet resultDataSet = new ResultDataSet();

            Parallel.ForEach(dataSetOne.DataRows, (dataSetOneRow) =>
            {
                foreach(InputDataRow dataSetTwoRow in dataSetTwo.DataRows)
                {
                    ResultData resultData = CompareAttributes(dataSetOneRow.DataAttributes, dataSetTwoRow.DataAttributes);
                    resultDataSet.ResultDataList.Add(resultData);
                }
            });

            return resultDataSet;
        }

        private ResultData CompareAttributes(List<InputDataAttribute> attributeSetOne, List<InputDataAttribute> attributeSetTwo)
        {
            ResultData resultData = new ResultData();

            foreach(InputDataAttribute firstAttribute in attributeSetOne)
            {
                foreach(InputDataAttribute secondAttribute in attributeSetTwo)
                {
                    if (firstAttribute.DataType != secondAttribute.DataType)
                    {
                        throw new Exception($"Attributes {firstAttribute.DataValue} and {secondAttribute.DataValue} do not have the same data types");
                    }

                    IAttributeComparer comparer = attributeComparers[firstAttribute.DataType];
                    double comparisonScore = comparer.CompareAttributes(firstAttribute, secondAttribute);

                    ResultDataAttribute attribute = new ResultDataAttribute()
                    {
                        DataSetOneAttribute = firstAttribute,
                        DataSetTwoAttribute = secondAttribute,
                        ComparisonScore = comparisonScore
                    };

                    resultData.ResultDataAttributes.Add(attribute);
                }
            }

            return resultData;
        }
    }
}
