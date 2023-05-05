using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowProjectDemo.Utility;
using SpecFlowProjectDemo.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectDemo.StepDefinitions
{
    [Binding]
    public class DatabaseTestingStepDefinitions
    {
        public static List<object> sqlResponseList;
        [Given(@"Create a sql connection and Execute SQL Query ""([^""]*)""")]
        public void GivenCreateASqlConnectionAndExecuteSQLQuery(string sqlQuery)
        {
            sqlResponseList = CommonOperationUtils.OpenSqlConnection(SQLConstants.SQLQuery(sqlQuery));
            if (sqlResponseList == null)
            {
                Assert.IsFalse(false, "Failed_To_Fetch_DB_Record");
            }
        }


        //[When(@"SQL query is executed")]
        //public void WhenSQLQueryIsExecuted()
        //{
        //    throw new PendingStepException();
        //}

        //[Then(@"Results should be displayed")]
        //public void ThenResultsShouldBeDisplayed()
        //{
        //    throw new PendingStepException();
        //}

    }
}
