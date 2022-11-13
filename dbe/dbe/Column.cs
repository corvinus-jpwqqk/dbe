using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    internal class Column
    {
        public string Name { get; set; }
        public int DataTypeID { get; set; }
        public int MaxLength { get; set; }
        public DataTypeCategory DataType { get; set; }
        public string TableName { get; set; }
        public int TableID { get; set; }
        public int ColID { get; set; }
        public string Description { get; set; }

        public Column()
        {

        }
        public Column(string name, int dataTypeId, int maxLength, string tableName, int tableId, int colId)
        {
            this.Name = name;
            this.DataTypeID = dataTypeId;
            this.MaxLength = maxLength;
            this.TableName = tableName;
            this.TableID = tableId;
            this.ColID = colId;
            this.Description = "";
            if (dataTypeId == 40
            || dataTypeId == 42)
            {
                this.DataType = DataTypeCategory.Date;
            }
            else if(dataTypeId == 35
                 || dataTypeId == 167
                 || dataTypeId == 231
                 || dataTypeId == 239)
            {
                this.DataType = DataTypeCategory.String;
            }
            else if (dataTypeId == 48
                 || dataTypeId == 52
                 || dataTypeId == 56
                 || dataTypeId == 62
                 || dataTypeId == 106
                 || dataTypeId == 108)
            {
                this.DataType = DataTypeCategory.Numeric;
            }
            else
            {
                this.DataType = DataTypeCategory.Unhandled;
            }
        }
        
        public string fullName()
        {
            return this.TableName + "." + this.Name;
        }
    }
}
