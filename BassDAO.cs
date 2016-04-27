using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace DAO
{
    public abstract class BaseDAO
    {
        SqlConnection connection;
        String defaultCon = "Data Source=.\\SQLExpress;Integrated Security=true";

        public SqlConnection connect(String database)
        {
            return connect(defaultCon, database);
        }

        public SqlConnection connect(String connectionStr, String dbName)
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();
            connection.ChangeDatabase(dbName);
            return connection;
        }

        public void close()
        {
            if (connection != null)
                connection.Close();
        }
    }
}