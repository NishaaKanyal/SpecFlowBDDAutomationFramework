using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProjectDemo.Hooks
{
    public class SQLConstants
    {
        static string sqlQueryToRun;
        public static  string SQLQuery(string sqlQueryName)
        {
            switch (sqlQueryName)
            {              
                case "fetchMaxIDAircraftTypeTable":
                    sqlQueryToRun = "select max(Id+1) as Id from resources.AircraftType";
                    break;
                case "fetchNameFromABCTable":
                    sqlQueryToRun = "select top 1 name from resources.ABC";
                    break;

                default:
                    break;
            }
            return sqlQueryToRun;
       }
     }
}
