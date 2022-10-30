using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    class FunctionTemplate
    {
        public DataTypeCategory ReturnType { get; set; }
        public string TemplateSQL { get; set; }
        public string TemplateHun { get; set; }
        
        public FunctionTemplate(DataTypeCategory returnType, string templateSql, string templateHun)
        {
            this.ReturnType = returnType;
            this.TemplateSQL = templateSql;
            this.TemplateHun = templateHun;
        }
    }
}
