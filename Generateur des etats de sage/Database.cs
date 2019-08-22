using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Generateur_des_etats_de_sage
{
    class Database
    {
        private SQLiteConnection conn = null;
        private Boolean dbCreated = false;
        public Database()
        {
            initDatabase();
        }

        ~Database()
        {
            
            try
            {
                if (this.conn != null)
                    this.conn.Close();
            }
            catch (System.ObjectDisposedException)
            {

            }
        }

        public void initDatabase()
        {
            try
            {
                if (File.Exists("approDatabase.sqlite"))
                {
                    //MessageBox.Show("Database already Exist", "Check database", MessageBoxButtons.OK);
                }
                else
                {
                    SQLiteConnection.CreateFile("approDatabase.sqlite");
                    this.dbCreated = true;
                }

                conn = new SQLiteConnection("Data Source=approDatabase.sqlite;Version=3;");
                conn.Open();

                //create tables if the databse is created for the first time
                if(this.dbCreated)
                {
                    createTables();
                    insertAllArticles();
                }

                //String massage = "connection to the database established";
                //MessageBox.Show(massage, "Database connection", MessageBoxButtons.OK);
            }
            catch (System.IO.IOException)
            {
                //String massage = "A connection to this database already exist";
                //MessageBox.Show(massage, "Database connection", MessageBoxButtons.OK);
            }
        }

        public void createTables()
        {
            String request = @"
                    CREATE TABLE IF NOT EXISTS colisageArticle
                    (AR_id INTEGER PRIMARY KEY AUTOINCREMENT,AR_Ref TEXT,AR_Design TEXT,AR_Coli INTEGER)
                ";
            SQLiteCommand cmd = new SQLiteCommand(request, this.conn);
            cmd.ExecuteNonQuery();
        }

        public void insertAllArticles()
        {
            String fileContent = File.ReadAllText("colisageArticles.txt");
            String[] rows = fileContent.Split(';');
            String[] items;
            String request;
            foreach (string row in rows)
            {
                if(row.Length > 0)
                {
                    items = row.Split('*');
                    request = @"
                        INSERT INTO colisageArticle (AR_Ref,AR_Design,AR_Coli) values('{0}','{1}',{2})          
                      ";
                    request = String.Format(request, items[0], escape(items[1]), items[2]);
                    using (SQLiteCommand cmd = new SQLiteCommand(request, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            //MessageBox.Show(rows[0], "reading text file", MessageBoxButtons.OK);
        }
        
        public String escape(String s)
        {
            String result = "",cote="'";
            foreach(Char c in s)
            {
                result += c;
                if (c == cote[0]) {
                    result += "'";
                }

            }
            return result;
        }

        public List<String[]> getAllArticles()
        {
            String request = "SELECT AR_Ref,AR_Design,AR_Coli FROM colisageArticle";
            List<String[]> result = null;
            using (SQLiteCommand cmd = new SQLiteCommand(request, this.conn))
            {
                using(SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    result = new List<string[]>();
                    String[] temp;
                    while (dr.Read())
                    {
                        temp = new String[3];
                        temp[0] = dr.GetString(0);
                        temp[1] = dr.GetString(1);
                        temp[2] = dr.GetInt32(2).ToString(CultureInfo.InvariantCulture);

                        result.Add(temp);
                    }
                }
            }
            return result;
        }

        public String[] getArticle(String ar_ref)
        {
            String request = "SELECT AR_Ref,AR_Design,AR_Coli FROM colisageArticle WHERE AR_Ref = '{0}'";
            request = String.Format(request, ar_ref);
            String[] result = null;
            using (SQLiteCommand cmd = new SQLiteCommand(request, this.conn))
            {
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        result = new String[3];
                        result[0] = dr.GetString(0);
                        result[1] = dr.GetString(1);
                        result[2] = dr.GetInt16(2).ToString();
                    }
                }
            }
            return result;
        }

        public void testAll()
        {
            DateTime d = DateTime.Now;
        }
    }
}
