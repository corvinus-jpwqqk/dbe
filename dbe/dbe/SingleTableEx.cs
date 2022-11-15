using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    class SingleTableEx : Exercise
    {
        public SingleTableEx(ref List<Table> tables, ref SqlConnection con, ref List<FunctionTemplate> templates) : base(ref tables, ref con, ref templates) { }
        protected override void generateExercise()
        {
            clearFields();
            getSelectColumns(1);
            getFrom();
            whereBuilder(true, true);
            checkExercise();
        }
    }
}
