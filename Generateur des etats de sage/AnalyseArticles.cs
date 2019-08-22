using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur_des_etats_de_sage
{
    class AnalyseArticles
    {
        //class properties
        private SqlConnection cnnp;
        private SqlserverConnection server;
        private DateTime[] dates;
        private List<string> Months;
        private Dictionary<string, string> listArticles;
        // we create an array for articles that will hold the final result
        private node[] articles = null;
        private string computerName;
        private List<node> toDisplay = new List<node>();
        private int processus;
        private List<node> allArticles;

        private int choix;/*
            vaut 0 si l'operation est basee sur les factures, 1 si il s'agit des devis
         */

        public AnalyseArticles()
        {
            server = new SqlserverConnection();
            cnnp = server.getConnector();
        }

        public class node
        {
            public string reference { get; set; }
            public string designation { get; set; }
            public Dictionary<string, decimal> CumulMois = new Dictionary<string, decimal>();
            public decimal moyenne { get; set; }
            public decimal prixAchat { get; set; }
            public decimal prixVente { get; set; }
            public decimal QteSto { get; set; }
            public decimal QteCom { get; set; }
            public int cpt { get; set; }
            public bool created { get; set; }
            public decimal demandeMoy { get; set; }
        }

        public List<node> getAllArticles()
        {
            return allArticles;
        }

        /*get all articles*/
        private void initArticles()
        {
            listArticles = new Dictionary<string, string>();

            string sql;
            sql = @"
                    select F_ARTICLE.AR_Ref,
                    F_ARTICLE.AR_Design
                    from F_ARTICLE
                    where F_ARTICLE.AR_Sommeil=0
            ";

            using (SqlCommand sc = new SqlCommand(sql, cnnp))
            {
                using (SqlDataReader dr = sc.ExecuteReader())
                {
                    listArticles = new Dictionary<string, string>();
                    while (dr.Read())
                    {
                        listArticles[dr.GetString(0)] = dr.GetString(1);
                    }
                }
            }
        }

        public static DateTime[] allDates(DateTime d1, DateTime d2)
        {
            DateTime[] result;
            DateTime tmp;

            int numberOfMonth = datediff(d1, d2);
            result = new DateTime[numberOfMonth + 2];

            for (int i = 0; i < result.Length; i++)
            {
                if (i == 0)
                    result[i] = d1;
                else if (i == result.Length - 1)
                {
                    result[i] = d2;
                }
                else
                {
                    tmp = d1.AddMonths(i);
                    result[i] = toFirstDay(tmp);
                }


            }

            return result;
        }
        public static DateTime toFirstDay(DateTime d)
        {
            DateTime tmp = d;
            if (d.Day > 1)
                tmp = d.AddDays(-1 * (d.Day - 1));
            return tmp;
        }

        public static int datediff(DateTime d1, DateTime d2)
        {
            int result = 0;
            result = Math.Abs(d1.Year - d2.Year) * 12 + Math.Abs(d1.Month - d2.Month);

            return result;
        }

        public static DateTime toLastDay(DateTime d)
        {
            DateTime tmp = d;
            if (DateTime.DaysInMonth(d.Year, d.Month) != d.Day)
                tmp = (d.AddDays(-1 * (d.Day - 1))).AddDays(DateTime.DaysInMonth(d.Year, d.Month) - 1);
            return tmp;
        }

        public void initData(DateTime dat1, DateTime dat2, int choice)
        {
            //type de traitement
            setChoix(choice);

            //retrieving all the dates contained in the given period as well as all months
            initdate(dat1, dat2);
            initMonth();
        }

        public void setChoix(int num)
        {
            this.choix = num;
        }

        //initialize the dates
        private void initdate(DateTime d, DateTime f)
        {
            dates = allDates(d, f);
        }

        //initialize months
        private void initMonth()
        {
            Months = new List<string>();

            foreach (DateTime dt in dates)
            {
                if (!Months.Contains(dt.Date.ToString("MMMM")))
                {
                    Months.Add(dt.Date.ToString("MMMM"));
                }
            }
        }

        //format sql query
        private static string sqlFormat(string date1, string date2)
        {
            string sql = @"
                 SELECT sum(F_DOCLIGNE.DL_QteBL) as 'quantite total'
	                  ,F_ARTICLE.AR_Design,F_ARTICLE.AR_Ref
                FROM F_DOCLIGNE,F_DOCENTETE,F_ARTICLE
                where  F_DOCLIGNE.DO_Domaine = 0
	                and F_DOCLIGNE.DO_Type=F_DOCENTETE.DO_Type
	                and F_DOCLIGNE.DO_Piece = F_DOCENTETE.DO_Piece
	                and (F_DOCLIGNE.DO_Type=6 or F_DOCLIGNE.DO_Type=7)
	                and F_DOCLIGNE.AR_Ref=F_ARTICLE.AR_Ref
	                and F_DOCLIGNE.DO_Date between convert(datetime,'{0}') and convert(datetime,'{1}')
                group by F_DOCLIGNE.DL_Design,F_ARTICLE.AR_Ref,F_ARTICLE.AR_Design
            ";
            return string.Format(sql, date1, date2);
        }

        //pour les devis
        private static string sqlFormatDevis(string date1, string date2)
        {

            string sql = @"
                 SELECT sum(F_DOCLIGNE.DL_QteDE) as 'quantite total'
	                  ,F_ARTICLE.AR_Design,F_ARTICLE.AR_Ref
                FROM F_DOCLIGNE,F_DOCENTETE,F_ARTICLE
                where  F_DOCLIGNE.DO_Domaine = 0
	                and F_DOCLIGNE.DO_Type=F_DOCENTETE.DO_Type
	                and F_DOCLIGNE.DO_Piece = F_DOCENTETE.DO_Piece
	                and (F_DOCLIGNE.DO_Type=0)
	                and F_DOCLIGNE.AR_Ref=F_ARTICLE.AR_Ref
	                and F_DOCLIGNE.DO_Date between convert(datetime,'{0}') and convert(datetime,'{1}')
                group by F_DOCLIGNE.DL_Design,F_ARTICLE.AR_Ref,F_ARTICLE.AR_Design
            ";
            return string.Format(sql, date1, date2);
        }

        private string subquery(string referenceArticle)
        {
            string sql = @"
                        SELECT AR_PrixAch
                            ,AR_PrixVen
	                        ,sum(AS_QteSto) as 'quantiteStock'
	                        ,sum(AS_QteCom) as 'quantiteCom'
                        FROM F_ARTICLE, F_ARTSTOCK
                        where F_ARTICLE.AR_Ref = F_ARTSTOCK.AR_Ref AND F_ARTICLE.AR_Ref = '{0}'
                        group by  F_ARTICLE.AR_Ref,AR_Design,AR_PrixAch,AR_PrixVen
                    ";

            sql = string.Format(sql, referenceArticle);


            return sql;
        }

        public void insertArticle(DateTime d, decimal qte, string design, string reference)
        {

            foreach (node l in allArticles)
            {
                if (l.reference == reference)
                {
                    l.CumulMois[d.Date.ToString("MMMM")] = qte;
                    l.moyenne += qte;
                    l.cpt += 1;

                    if (d.Date.ToString("MMMM") == dates[dates.Length - 1].Date.ToString("MMMM"))
                    {
                        l.moyenne /= l.cpt;
                        l.moyenne = Math.Round(l.moyenne, 2);
                        l.created = true;
                    }
                    return;
                }
            }

            node nouveau = new node();
            nouveau.reference = reference;
            nouveau.designation = design;
            nouveau.created = false;
            nouveau.CumulMois = new Dictionary<string, decimal>();
            foreach (string s in Months)
            {
                nouveau.CumulMois[s] = 0;
            }

            string mois = d.Date.ToString("MMMM");
            nouveau.CumulMois[mois] = qte;
            nouveau.moyenne = qte;
            nouveau.cpt = 1;

            using (SqlCommand command2 = new SqlCommand(subquery(reference), cnnp))
            {
                //trying another way to execute the query
                using (SqlDataReader sd = command2.ExecuteReader())
                {
                    if (sd.Read())
                    {
                        nouveau.prixAchat = sd.GetDecimal(0);
                        nouveau.prixVente = sd.GetDecimal(1);
                        nouveau.QteSto = sd.GetDecimal(2);
                        nouveau.QteCom = sd.GetDecimal(3);
                    }
                }
            }
            allArticles.Add(nouveau);

            if (d.Date.ToString("MMMM") == dates[dates.Length - 1].Date.ToString("MMMM"))
            {
                nouveau.moyenne /= nouveau.cpt;
                nouveau.moyenne = Math.Round(nouveau.moyenne, 2);
                nouveau.created = true;

            }

        }

        public void processQuery()
        {
            allArticles = new List<node>();
            string sql, dd, df;

            if (dates.Length <= 2)
            {

                dd = dates[0].Date.ToString("yyyyMMdd");
                df = dates[1].Date.ToString("yyyyMMdd");

                if (choix == 0)
                {
                    sql = sqlFormat(dd, df);
                }
                else
                {
                    sql = sqlFormatDevis(dd, df);
                }

                //launch the query
                using (SqlCommand command2 = new SqlCommand(sql, cnnp))
                {
                    //trying another way to execute the query
                    using (SqlDataReader sd = command2.ExecuteReader())
                    {
                        while (sd.Read())
                        {
                            insertArticle(dates[1], sd.GetDecimal(0), sd.GetString(1), sd.GetString(2));
                        }
                    }
                }
            }
            else //more than a month
            {
                //we loop through the array of date (tmp)
                for (int i = 0; i < dates.Length; i++)
                {
                    //avoid repetion on the last date
                    if (i == dates.Length - 1)
                    {
                        break;
                    }
                    // because we are retrieve the last day of a month, 
                    //we can do that for the last date of our array
                    if (i < dates.Length - 1)
                    {

                        dd = dates[i].Date.ToString("yyyyMMdd");
                        df = toLastDay(dates[i]).Date.ToString("yyyyMMdd");
                    }
                    else
                    {

                        df = dates[i].Date.ToString("yyyyMMdd");
                        dd = toFirstDay(dates[i]).Date.ToString("yyyyMMdd");
                    }

                    if (choix == 0)
                    {
                        sql = sqlFormat(dd, df);
                    }
                    else
                    {
                        sql = sqlFormatDevis(dd, df);
                    }

                    //launch the query
                    using (SqlCommand command2 = new SqlCommand(sql, cnnp))
                    {
                        //trying another way to execute the query
                        using (SqlDataReader sd = command2.ExecuteReader())
                        {
                            while (sd.Read())
                            {
                                insertArticle(toFirstDay(dates[i]), sd.GetDecimal(0), sd.GetString(1), sd.GetString(2));
                            }
                        }
                    }

                }

            }

        }
    }
}
