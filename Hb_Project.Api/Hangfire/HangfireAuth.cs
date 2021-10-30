using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hb_Project.Api.Hangfire
{
    public class HangfireAuth: IDashboardAuthorizationFilter 
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}
