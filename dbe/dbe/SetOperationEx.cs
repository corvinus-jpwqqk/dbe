using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    class SetOperationEx : Exercise
    {
        public SetOperationEx(ref List<Table> tables, ref SqlConnection con, ref List<FunctionTemplate> templates) : base(ref tables, ref con, ref templates) { }
        protected override void generateExercise()
        {
            clearFields();
            buildSetOperation();
            checkExercise();
        }
    }
}
