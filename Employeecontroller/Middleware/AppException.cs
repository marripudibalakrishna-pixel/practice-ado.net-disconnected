using System.Globalization;

namespace Employeecontroller.Middleware
{
    public class AppException: Exception
    {
        public AppException():base()
        {
        }
        public AppException(string message):base(message)
        {
        }
        protected AppException(string message, params object[] args)
         : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
