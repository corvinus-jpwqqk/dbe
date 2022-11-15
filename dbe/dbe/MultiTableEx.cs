using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    class MultiTableEx : Exercise
    {
        public MultiTableEx(ref List<Table> tables, ref SqlConnection con, ref List<FunctionTemplate> templates) : base(ref tables, ref con, ref templates) { }
        protected override void generateExercise()
        {
            clearFields();
            getSelectColumns(this.tables.Count);
            getFrom();
            whereBuilder(true, false);
            checkExercise();
        }
    }
}
