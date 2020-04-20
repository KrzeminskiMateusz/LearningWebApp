using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models.Injection
{
    public class MyDependency : IMyDependency, IDisposable
    {
        //private readonly ILogger<MyDependency> logger;

        private readonly string message;

        //public MyDependency(ILogger<MyDependency> logger, string message)
        //{
        //    this.logger = logger;
        //    this.message = message;
        //}

        public MyDependency(string message)
        {
            this.message = message;
        }

        public void Dispose()
        {          
        }

        public Task<string> WriteMessage(string message)
        {
            //logger.LogInformation(
            //"MyDependency.WriteMessage called. Message: {MESSAGE}",
            //message);

            //return Task.FromResult(0);

            return Task.FromResult($"MyDependency.WriteMessage called. Message: {message} arguments: {this.message}");
        }
    }
}
