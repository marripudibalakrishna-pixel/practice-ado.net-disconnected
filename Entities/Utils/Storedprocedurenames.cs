using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Utils
{
    public static class Storedprocedurenames
    {
        public static string AddEmployee = "Usp_AddEmployeeReturn";
        public static string UpdateEmployee = "Usp_UpdateEmployee";
        public static string DeleteEmployee = "Usp_DeleteEmployee";
        public static string GetEmployee = "Usp_GetEmployee";
        public static string GetEmployeeByEmpid = "Usp_GetEmployeeId";

        #region loggingfactory parameters
        public static string projectlevellogdb = "Usp_ProjectLevellog";
        public static string projecterrorlevellogdb = "ProjectLevelErrorlog";

        #endregion

    }
}
