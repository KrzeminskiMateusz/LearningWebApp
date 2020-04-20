using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSignalRApp.Client.Classes
{
    public class NotifierService
    {
        public event Func<string, int, Task> Notify;

        public async Task Update(string key, int value)
        {
            if (Notify != null)
            {
                await Notify.Invoke(key, value);
            }
        }

    }
}
