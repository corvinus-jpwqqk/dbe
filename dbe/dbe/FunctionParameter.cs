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
        private ParamType paramType;

        public FunctionParameter(DataTypeCategory dataType, string name, ParamType pt)
        {
            this.dataType = dataType;
            this.name = name;
            this.paramType = pt;
        }
        public string Name
        {
            get { return this.name; }
        }
        public DataTypeCategory DataType
        {
            get { return this.dataType; }
        }
        public ParamType ParamType
        {
            get { return this.paramType; }
        }
    }
}
