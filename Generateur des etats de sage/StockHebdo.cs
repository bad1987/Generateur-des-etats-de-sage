using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur_des_etats_de_sage
{
    class StockHebdo
    {
        //*******************************************proprietes********************************************************
        private SqlserverConnection sqlsrv;
        private int vendu;//vaut 1 si il s'agit des articles vendus
        private Node articles;
        private String dateDebut;
        private String dateFin;

        //********************************************methodes et sous-classes*********************************************************

        public class Node
        {
            public Node()
            {
                this.leftChild = null;
                this.rightChild = null;
            }

            public String ar_ref { get; set; }
            public String ar_design { get; set; }
            public Decimal qte_residuel { get; set; }
            public decimal qte_vendu { get; set; }

            public Node leftChild { get; set; }
            public Node rightChild { get; set; }
        }

        public StockHebdo(int vendu=1)
        {
            this.vendu = vendu;
            articles = null;
            sqlsrv = new SqlserverConnection();
        }

        public void enfiler(Node p)
        {
            if (this.articles == null)
            {
                articles = p;
            }
            else
            {
                Node q = articles;
                while (q.rightChild != null)
                {
                    q = q.rightChild;
                }
                q.rightChild = p;
            }
        }

        public String sqlvenduHebdo()
        {
            //dateDebut = DateTime.Now.Date.ToString("yyyyMMdd");
            //dateFin = DateTime.Now.AddDays(-1).Date.ToString("yyyyMMdd");
            String sql = @"
                SELECT distinct AR_Ref,DL_Design from F_DOCLIGNE
                where DL_DateBL between '{0}' and '{1}'
                and (DO_Type in  (3,6,7)) and DL_QteBL>0 and AR_Ref is not null
            ";
            return String.Format(sql, dateDebut, dateFin);
        }

        public void getRequiredArticles()
        {
            using (SqlCommand sc = new SqlCommand(sqlvenduHebdo(), sqlsrv.getConnector()))
            {
                using (SqlDataReader dr = sc.ExecuteReader())
                {
                    Node p;
                    while (dr.Read())
                    {
                        p = new Node();
                        p.ar_ref = dr.GetString(0);
                        p.ar_design = dr.GetString(1);

                        enfiler(p);
                    }
                }
            }
        }

        public String sqlCumulStock(string ar_ref)
        {
            String sql = @"
                select AR_Ref, sum(AS_QteSto) as 'qte vendue'
                from F_ARTSTOCK
                where AR_Ref='{0}'
                group by AR_Ref
            ";

            return string.Format(sql, ar_ref);
        }


        public void residuelDesVendus()
        {
            Node p = articles;

            while(p != null)
            {
                using (SqlCommand sc = new SqlCommand(sqlCumulStock(p.ar_ref), sqlsrv.getConnector()))
                {
                    using (SqlDataReader dr = sc.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            p.qte_residuel = dr.GetDecimal(1);
                            
                        }
                    }
                }

                p = p.rightChild;
            }
        }

        public string sqlcumulvendu(string ar_ref)
        {
            string sql = @"
                SELECT AR_Ref,DL_Design as 'Designation',SUM(DL_QteBL) as 'total vendu'
                FROM F_DOCLIGNE 
                where DO_Domaine=0 
	                AND DL_DateBL between '{0}' and '{1}'
	                and DO_Type in (3,6,7) and DL_QteBL>0
	                and AR_Ref = '{2}'
                group by DL_Design, AR_Ref
            ";
            return string.Format(sql, dateDebut, dateFin, ar_ref);
        }

        public void cumulVendus()
        {
            Node p = articles;

            while (p != null)
            {
                using (SqlCommand sc = new SqlCommand(sqlcumulvendu(p.ar_ref), sqlsrv.getConnector()))
                {
                    using (SqlDataReader dr = sc.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            p.qte_vendu = dr.GetDecimal(2);

                        }
                    }
                }

                p = p.rightChild;
            }
        }

        public void process()
        {
            getRequiredArticles();
            residuelDesVendus();
            cumulVendus();
        }

        public Node getArticles()
        {
            return articles;
        }

        public void setDates(String d1, String d2)
        {
            this.dateDebut = d1;
            this.dateFin = d2;
        }
    }
}
