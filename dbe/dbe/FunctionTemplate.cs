using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    class FunctionTemplate
    {
        public DataTypeCategory returnType;
        private string templateSql;
        private string templateHun;
        
        public FunctionTemplate(DataTypeCategory returnType, string templateSql, string templateHun)
        {
            this.returnType = returnType;
            this.templateSql = templateSql;
            this.templateHun = templateHun;
        }
        public DataTypeCategory ReturnType
        {
            get { return this.returnType; }
        }
        public string TemplateHun
        {
            get { return this.templateHun; }
        }
        public string TemplateSql
        {
            get { return this.templateSql; }
        }
    }
}
