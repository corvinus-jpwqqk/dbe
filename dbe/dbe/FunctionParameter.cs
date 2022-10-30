using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    class FunctionParameter
    {
        public string Name { get; set; }
        public DataTypeCategory DataType { get; set; }
        public ParamType ParamType { get; set; }
        public FunctionParameter(DataTypeCategory dataType, string name, ParamType pt)
        {
            this.DataType = dataType;
            this.Name = name;
            this.ParamType = pt;
        }
    }
}
