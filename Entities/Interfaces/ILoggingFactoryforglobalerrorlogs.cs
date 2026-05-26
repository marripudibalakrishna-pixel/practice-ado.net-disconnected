using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace DapperWith4DatabaseCommunication.Interfaces
    {
        public interface ILoggingFactory
        {
            Task<bool> AddLoggingMessages(string userName, string logLevel, string messageTemplate);
            Task<bool> AddProjectLevelErrorlogAsync(string statusCode, string ErrorMessage, string StackTraceError, string InnerExceptionError);
        }
    }


