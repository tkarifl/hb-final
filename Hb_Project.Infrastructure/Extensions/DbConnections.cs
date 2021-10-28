using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Infrastructure.Extensions
{
    public static class DbConnections
    {
        public static string postreConnection= "Host=127.0.0.1;Database=hb_ecommerce;Username=postgres;Password=12345";
        public static string mongoConnection = "mongodb://mongouser:12345@localhost:27017/?authSource=admin&readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false";
    }
}
