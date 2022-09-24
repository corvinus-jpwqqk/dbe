using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    internal class Column
    {
        private string name;
        private int dataType;
        private int maxLength;
        private string dataTypeName;
        private DataTypeCategory dtCategory;

        public Column()
        {

        }
        public Column(string name, int dataType, int maxLength)
        {
            this.name = name;
            this.dataType = dataType;
            this.maxLength = maxLength;
            if(dataType == 40
            || dataType == 42)
            {
                this.dtCategory = DataTypeCategory.Date;
            }
            else if(dataType == 35
                 || dataType == 167
                 || dataType == 231
                 || dataType == 239)
            {
                this.dtCategory = DataTypeCategory.String;
            }
            else if (dataType == 48
                 || dataType == 52
                 || dataType == 56
                 || dataType == 62
                 || dataType == 106
                 || dataType == 108)
            {
                this.dtCategory = DataTypeCategory.Numeric;
            }
            else
            {
                this.dtCategory = DataTypeCategory.Unhandled;
            }
        }
        public int getDataType() { return this.dataType; }
        public void setDataTypeName(string dataTypeName) { this.dataTypeName = dataTypeName; }
        public string Name
        {
            get { return this.name; }
        }
        public DataTypeCategory DtCat
        {
            get { return this.dtCategory;  }
        }
    }
}
