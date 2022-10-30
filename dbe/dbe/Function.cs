using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    class Function
    {
        public string Name { get; set; }
        public DataTypeCategory ReturnType { get; set; }

        public List<FunctionParameter> Parameters { get; set; }
        public string FunctionTextHun { get; set; }
        public string FunctionTextSQL { get; set; }

        public Function(string value)
        {
            this.FunctionTextSQL = value;
            this.FunctionTextHun = value;
        }
        public Function(FunctionTemplate ft)
        {
            this.Name = ft.TemplateSQL.Substring(0, ft.TemplateSQL.IndexOf('('));
            Parameters = new List<FunctionParameter>();
            parseParams(ft.TemplateSQL);
            this.FunctionTextHun = ft.TemplateHun;
            this.FunctionTextSQL = ft.TemplateSQL;
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
                    Console.WriteLine("Error when parsing parameters for SqlTemplate: " + this.Name + "\n" + ex.Message);
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
                this.Parameters.Add(new FunctionParameter(dataType, paramA[1], pt)); ;
                int newLength = defSql.Length - close - 1;
                defSql = defSql.Substring(close + 1, newLength);
            }
        }
        public void buildParam(FunctionParameter param, Function p)
        {
            var opens = AllIndexesOf(this.FunctionTextSQL, "[");
            var closes = AllIndexesOf(this.FunctionTextSQL, "]");
            for(int i = 0; i < opens.Count; i++)
            {
                if(this.FunctionTextSQL.Substring(opens[i], closes[i] - opens[i]).Split(' ')[1] == param.Name)
                {
                    string begin = this.FunctionTextSQL.Substring(0, opens[i]);
                    string end = this.FunctionTextSQL.Substring(closes[i] + 1, this.FunctionTextSQL.Length - closes[i] - 1);
                    this.FunctionTextSQL = begin +  p.FunctionTextSQL + end;
                    break;
                }
            }

            opens = AllIndexesOf(this.FunctionTextHun, "[");
            closes = AllIndexesOf(this.FunctionTextHun, "]");
            for (int i = 0; i < opens.Count; i++)
            {
                // Console.WriteLine("Param name found: " + this.functionTextHun.Substring(opens[i] + 1, closes[i] - opens[i] - 1));
                if (this.FunctionTextHun.Substring(opens[i] + 1, closes[i] - opens[i] - 1) == param.Name)
                {
                    string begin = this.FunctionTextHun.Substring(0, opens[i]);
                    string end = this.FunctionTextHun.Substring(closes[i] + 1, this.FunctionTextHun.Length - closes[i] - 1);
                    this.FunctionTextHun = begin + p.FunctionTextHun + end;
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
