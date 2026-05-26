using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Utils
{
    public class StoredProcedureparameters
    {
        public static string EmployeeID = "@empid";
        public static string EmployeeName = "@empname";
        public static string EmployeeSalary = "@empsalary";
        public static string Insertedvariable = "@insertvalue";

        #region IloggingFactoryparameters
        public static string username = "@username";
        public static string loglevel = "@LogLevel";
        public static string messagetemplate = "@MessageTemplate";

        #endregion

    }

    #region IloggingFactoryparameters

    #endregion
}
