using FuzzyStringMatching;
using RecordLinkageEngine.Core.Interfaces;
using RecordLinkageEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLinkageEngine.Core.AttributeComparers
{
    public class StringAttributeComparer : IAttributeComparer
    {
        private FuzzyStringMatchingService fuzzyStringMatcher;

        public StringAttributeComparer()
        {
            this.fuzzyStringMatcher = new FuzzyStringMatchingService();
        }

        public double CompareAttributes(DataAttribute attributeOne, DataAttribute attributeTwo)
        {
            string firstValue = attributeOne.DataValue;
            string secondValue = attributeTwo.DataValue;
            double levenshteinDistance = this.fuzzyStringMatcher.CompareStrings(FuzzyStringComparerType.LevenshteinDistance, attributeOne.DataValue, attributeTwo.DataValue);

            return 1 - ( levenshteinDistance / Math.Max(firstValue.Length, secondValue.Length));
        }
    }
}
