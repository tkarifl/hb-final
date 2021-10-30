using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hb_Project.Api.Hangfire
{
    public class HangfireAuth: IDashboardAuthorizationFilter 
    {
        // add hangfire dashboard to production, so in container, we can access hangfire dashboard
        // normally, hangfire dashboard shouldn't be exposed without authentication but this is a homework project
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}
