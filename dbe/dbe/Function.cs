using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    class Function
    {
        private string name;
        private DataTypeCategory returnType;
        private List<FunctionParameter> parameters;
        private int maxLength;
        private string functionTextHun;
        private string functionTextSql;


        public Function(string value)
        {
            this.functionTextSql = value;
            this.functionTextHun = value;
        }
        public Function(FunctionTemplate ft)
        {
            this.name = ft.TemplateSql.Substring(0, ft.TemplateSql.IndexOf('('));
            parameters = new List<FunctionParameter>();
            parseParams(ft.TemplateSql);
            this.functionTextHun = ft.TemplateHun;
            this.functionTextSql = ft.TemplateSql;
        }

        public string Name
        {
            get { return this.name; }
        }
        public DataTypeCategory ReturnType
        {
            get { return this.returnType; }
        }
        public List<FunctionParameter> Parameters
        {
            get { return this.parameters; }
        }
        public int MaxLength
        {
            get { return this.maxLength; }
        }
        public string FunctionTextHun
        {
            get { return this.functionTextHun; }
        }
        public string FunctionTextSql
        {
            get { return this.functionTextSql; }
        }
        private void parseParams(string defSql)
        {
            while (defSql.IndexOf('[') != -1)
            {
                int open = defSql.IndexOf('[');
                int close = defSql.IndexOf(']');
                string param = defSql.Substring(open + 1, close - open - 1);
                string[] paramA = param.Split(' ');
                DataTypeCategory dataType;
                try
                {
                    Enum.TryParse<DataTypeCategory>(paramA[0], out dataType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error when parsing parameters for SqlTemplate: " + this.name + "\n" + ex.Message);
                    return;
                }
                ParamType pt;
                if(paramA[2] == "col")
                {
                    pt = ParamType.Column;
                }
                else if(paramA[2] == "rnd")
                {
                    pt = ParamType.Random;
                }
                else
                {
                    Console.WriteLine("Error when parsing parameters for SqlTemplate: parameter type is not recognized");
                    return;
                }
                this.parameters.Add(new FunctionParameter(dataType, paramA[1], pt)); ;
                int newLength = defSql.Length - close - 1;
                defSql = defSql.Substring(close + 1, newLength);
            }
        }
        public void buildParam(FunctionParameter param, Function p)
        {
            var opens = AllIndexesOf(this.functionTextSql, "[");
            var closes = AllIndexesOf(this.functionTextSql, "]");
            for(int i = 0; i < opens.Count; i++)
            {
                if(this.functionTextSql.Substring(opens[i], closes[i] - opens[i]).Split(' ')[1] == param.Name)
                {
                    string begin = this.functionTextSql.Substring(0, opens[i]);
                    string end = this.functionTextSql.Substring(closes[i] + 1, this.functionTextSql.Length - closes[i] - 1);
                    this.functionTextSql = begin +  p.functionTextSql + end;
                    break;
                }
            }

            opens = AllIndexesOf(this.functionTextHun, "[");
            closes = AllIndexesOf(this.functionTextHun, "]");
            for (int i = 0; i < opens.Count; i++)
            {
                // Console.WriteLine("Param name found: " + this.functionTextHun.Substring(opens[i] + 1, closes[i] - opens[i] - 1));
                if (this.functionTextHun.Substring(opens[i] + 1, closes[i] - opens[i] - 1) == param.Name)
                {
                    string begin = this.functionTextHun.Substring(0, opens[i]);
                    string end = this.functionTextHun.Substring(closes[i] + 1, this.functionTextHun.Length - closes[i] - 1);
                    this.functionTextHun = begin + p.functionTextHun + end;
                    // Console.WriteLine("Swapped parameter for: " + this.functionTextHun);
                    break;
                }
            }
        }
        public List<int> AllIndexesOf(string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("The string to find cannot be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}
