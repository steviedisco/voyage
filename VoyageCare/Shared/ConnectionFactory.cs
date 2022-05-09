using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageCare.Shared
{
    internal class ConnectionFactory
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(@"Server = localhost\sqlexpress; Database = VoyageCare; Trusted_Connection = True;"); // TODO
        }
    }
}
