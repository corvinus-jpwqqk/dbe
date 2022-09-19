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

        public Column(string name, int dataType, int maxLength)
        {
            this.name = name;
            this.dataType = dataType;
            this.maxLength = maxLength;
        }
        public int getDataType() { return this.dataType; }
        public void setDataTypeName(string dataTypeName) { this.dataTypeName = dataTypeName; } 
    }
}
