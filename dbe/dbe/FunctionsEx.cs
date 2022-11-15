using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    class FunctionsEx : Exercise
    {
        public FunctionsEx(ref List<Table> tables, ref SqlConnection con, ref List<FunctionTemplate> templates) : base(ref tables, ref con, ref templates) { }
        protected override void generateExercise()
        {
            clearFields();
            getSelectWithFunction();
            getFrom();
            whereBuilder(true, true);
            checkExercise();
        }
        private void getSelectWithFunction()
        {
            getSelectColumns(1);
            this.ExerciseTextHun += ", valamint a következőt: ";
            this.ExerciseTextSQL += ", ";
            var f = functionBuilder(DataTypeCategory.String, 2);
            this.ExerciseTextSQL += f.FunctionTextSQL;
            this.ExerciseTextHun += f.FunctionTextHun + ". ";
        }
    }
}
