using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIS
{
    internal class DBUtilities
    {
        public static string Countrecords(string sql, SqlConnection cn)
        {
            cn.Open();
            SqlCommand cm = new SqlCommand(sql, cn);
            string _count = cm.ExecuteScalar().ToString();
            cn.Close();
            return _count;
        }
    }
}
