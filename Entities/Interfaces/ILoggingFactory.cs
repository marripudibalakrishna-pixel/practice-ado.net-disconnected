using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface ILoggingFactory
    {
        Task<bool> IlogMessages(string name, string loglevel, string messagetemplate);
    }
}
