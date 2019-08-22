using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur_des_etats_de_sage
{
    class SqlserverConnection
    {
        private SqlConnection cnn;

        public SqlserverConnection()
        {
            dbcon();
        }

        ~SqlserverConnection()
        {
            /*try
            {
                this.cnn.Close();
            }
            catch
            {
                Console.WriteLine("l'object n'existe plus en memoire");
            }*/
        }

        private void dbcon()
        {
            /*database setup*/
            string connectionString;

            //connectionString = @"Data Source={0};Initial Catalog=SIAP COMPTA SQL 1;User ID=bad1987;Password=bad1987";
            connectionString = "Data Source=SIAP-SERVER;Initial Catalog=SIAP COMPTA SQL 1;Integrated Security = SSPI;MultipleActiveResultSets=True;";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("délai d'attente"))
                {
                    cnn.Open();
                }
            }
        }

        public SqlConnection getConnector()
        {
            return this.cnn;
        }
    }
}
