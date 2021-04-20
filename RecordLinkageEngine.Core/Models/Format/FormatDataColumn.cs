namespace RecordLinkageEngine.Core.Models.Format
{
    public class FormatDataColumn
    {
        string DataType { get; set; }
        int ColumnIndex { get; set; }
        bool IsUsed { get; set; }

        public FormatDataColumn(string dataType, int columnIndex, bool isUsed)
        {
            this.DataType = dataType;
            this.ColumnIndex = columnIndex;
            this.IsUsed = isUsed;
        }
    }
}