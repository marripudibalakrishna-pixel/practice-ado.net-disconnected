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

        #region Logging Parameters

        public static string Logging_UserName = "@username";
        public static string Logging_LogLevel = "@LogLevel";
        public static string Logging_MessageTemplate = "@MessageTemplate";
        #endregion

        #region ErrorLog Parameters
        public static string ErrorLog_StatusCode = "@StatusCode";
        public static string ErrorLog_ErrorMessage = "@ErrorMessage";
        public static string ErrorLog_StackTraceError = "@StackTraceError";
        public static string ErrorLog_InnerExceptionError = "@InnerExceptionError";
    }
}
        #endregion

