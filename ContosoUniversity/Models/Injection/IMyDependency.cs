using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models.Injection
{
    public interface IMyDependency
    {
        Task<string> WriteMessage(string message);
    }
}
