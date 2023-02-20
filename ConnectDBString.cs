using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPhanQuyen2
{
    class ConnectDBString
    {
        internal static string connectionString()
        {
            string connectionString = @"Data Source=DESKTOP-H8M37V7\SQLEXPRESS;Initial Catalog=DemoUserPermission;User ID=sa;Password=123";
            return connectionString;
        }
    }
}
