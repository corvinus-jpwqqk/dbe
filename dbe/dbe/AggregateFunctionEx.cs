using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbe
{
    class AggregateFunctionEx : Exercise
    {
        public AggregateFunctionEx(ref List<Table> tables, ref SqlConnection con, ref List<FunctionTemplate> templates) : base(ref tables, ref con, ref templates) { }
        protected override void generateExercise()
        {
            clearFields();
            getSelectWithAggregateFunction();
            getFrom();
            whereBuilder(true, true);
            this.ExerciseTextSQL += groupBy;
            checkExercise();
        }
        private void getSelectWithAggregateFunction()
        {
            getSelectColumns(1);
            this.ExerciseTextHun += ", valamint a következőt: ";
            this.ExerciseTextSQL += ", ";
            Tuple<string, string> aggregateFunction = getAggregateFunction(ref usedColumns);
            this.ExerciseTextSQL += aggregateFunction.Item1;
            this.ExerciseTextHun += aggregateFunction.Item2 + ". ";
        }
    }
}
