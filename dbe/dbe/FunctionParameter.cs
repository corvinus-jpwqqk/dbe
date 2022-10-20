using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    class FunctionParameter
    {
        private string name;
        private DataTypeCategory dataType;
        public FunctionParameter(DataTypeCategory dataType, string name)
        {
            this.dataType = dataType;
            this.name = name;
        }
        public string Name
        {
            get { return this.name; }
        }
        public DataTypeCategory DataType
        {
            get { return this.dataType; }
        }
    }
}
