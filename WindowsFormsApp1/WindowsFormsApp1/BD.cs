using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class BD
    {
        MySqlConnection mySqlConnection = new MySqlConnection("server = localhost; port=3307; username = root; password = root; database = clients");
        
        public void openConnection()
        {
            if(mySqlConnection.State == System.Data.ConnectionState.Closed)
            {
                mySqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (mySqlConnection.State == System.Data.ConnectionState.Open)
            {
                mySqlConnection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return mySqlConnection;
        }
    }
}
