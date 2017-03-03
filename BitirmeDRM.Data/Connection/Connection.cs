using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeDRM.Data.Connection
{
    public static class Connection
    {
        public static SqlConnection ConnectionString()
        {
            SqlConnection con = new SqlConnection("Data Source");
            return con;
        }

    }
}
