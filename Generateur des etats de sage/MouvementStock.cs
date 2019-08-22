using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur_des_etats_de_sage
{
    class MouvementStock
    {
        private SqlConnection sqlservercon;
        private Database sqlitecon;
        private int[] lastthreemonths;
        private Queue listeArticles;
        private Queue articleDisponible;

        public MouvementStock()
        {
            this.sqlservercon = (new SqlserverConnection()).getConnector();
            this.sqlitecon = new Database();
            this.lastthreemonths = getLastThreeMonths();
            this.listeArticles = new Queue();
            this.articleDisponible = new Queue();
        }

        ~MouvementStock()
        {
            
        }

        private int[] getLastThreeMonths()
        {
            DateTime d = DateTime.Now;
            int[] temp = new int[3];
            temp[0] = d.Date.Month;
            temp[1] = d.AddMonths(-1).Date.Month;
            temp[2] = d.AddMonths(-2).Date.Month;

            return temp;
        }

        /*
            cette fonction renvois les information du depot principal pour un article donnee concernant
            les mouvements de transfert(entree en DP) sur une periode donnee
        */
        public String[] index(String ar_ref, String dateDebut, String  dateFin)
        {
            String request = @"
                SELECT F_DOCENTETE.DO_Type,
                    F_DOCENTETE.DE_No,
                    F_DOCLIGNE.DO_Date,
                    AR_Ref,
                    DL_Design,
                    DL_Qte,
                    DL_MvtStock,
                    F_DOCLIGNE.DE_No
                FROM F_DOCENTETE,F_DOCLIGNE
                WHERE F_DOCENTETE.DO_Domaine = F_DOCLIGNE.DO_Domaine
                    AND F_DOCENTETE.DO_Piece = F_DOCLIGNE.DO_Piece
                    AND F_DOCENTETE.DO_Type = F_DOCLIGNE.DO_Type
                    AND F_DOCENTETE.DO_Type = 23
                    AND F_DOCENTETE.DO_Date >= '{1}'
                    AND F_DOCENTETE.DO_Date <= '{2}'
                    AND F_DOCLIGNE.DE_No = 1
                    AND DL_MvtStock = 1
                    AND AR_Ref = '{0}'
            ";

            request = String.Format(request, ar_ref, dateDebut, dateFin);
            
            String[] temp = null;
            using(SqlCommand cmd = new SqlCommand(request, this.sqlservercon))
            {
                using(SqlDataReader sd = cmd.ExecuteReader())
                {

                    if(sd.Read())
                    {
                        temp = new string[8];
                        temp[0] = sd.GetInt16(0).ToString();
                        temp[1] = sd.GetInt32(1).ToString();
                        temp[2] = sd.GetDateTime(2).ToString();
                        temp[3] = sd.GetString(3);
                        temp[4] = sd.GetString(4);
                        temp[5] = sd.GetDecimal(5).ToString();
                        temp[6] = sd.GetInt16(6).ToString();
                        temp[7] = sd.GetInt32(7).ToString();
                    }
                }
            }

            return temp;
        }

        public void articlesEnStock()
        {
            String request = @"
                SELECT F_ARTSTOCK.AR_Ref, AR_Design, SUM(AS_QteSto)
                FROM F_ARTICLE, F_ARTSTOCK
                WHERE F_ARTICLE.AR_Ref = F_ARTSTOCK.AR_Ref
                GROUP BY F_ARTSTOCK.AR_Ref, AR_Design
                HAVING SUM(AS_QteSto) > 0
                ORDER BY F_ARTSTOCK.AR_Ref
            ";

            using(SqlCommand cmd = new SqlCommand(request, this.sqlservercon))
            {
                using(SqlDataReader sd = cmd.ExecuteReader())
                {
                    while (sd.Read())
                    {
                        Node p = new Node();
                        p.setRef(sd.GetString(0));
                        p.setDesign(sd.GetString(1));
                        p.setStockDP(sd.GetDecimal(2));
                        this.articleDisponible.enqueue(p);
                    }
                }
            }
        }

        public void processAvailableArt()
        {
            Queue p = this.articleDisponible;
            Node temp = p.dequeue();
            int coef = 26,tqte=0,tcoef=0,day;
            DateTime[] date;
            String[] res,tmp;
            int[] qte;

            while (temp != null)
            {
                List<String[]> cumulDonnees = new List<string[]>();

                tqte = 0;
                tcoef = 0;
                for(int i = 0; i < 7; i++)//etude des transferts sur les 'x' dernier mois
                {
                    if (i == 0)//nombre de jours commerciaux pour le mois courant
                    {
                        day = DateTime.Today.Day;
                        if (day >= 28)
                            day -= 4;
                        else if (day >= 21)
                            day -= 3;
                        else if (day >= 14)
                            day -= 2;
                        else if (day >= 7)
                            day -= 1;
                        coef = day;
                    }
                    else
                    {//26 jours pour le mois commercial
                        coef = 26;
                    }
                    date = makeDate(i);
                    res = index(temp.getRef(), formatDate(date[0]), formatDate(date[1]));
                    qte = extractQte(res, coef);

                    tmp = new String[4];
                    tmp[0] = date[0].Date.Year.ToString();
                    tmp[1] = date[0].Date.Month.ToString();
                    tmp[2] = qte[0].ToString();//quantite totale
                    tmp[3] = qte[1].ToString();//moyenne journaliere
                    cumulDonnees.Add(tmp);
                    tqte += qte[0]; //quantite permetant de determiner une moyenne generale
                    tcoef = coef;
                }
                inserQueue(temp.getRef(), temp.getDesign(), cumulDonnees, (int)Math.Round((float)tqte / tcoef));
                temp = p.dequeue();
            }
        }

        private String formatDate(DateTime date)
        {
            String d = "";
            d += date.Date.Year.ToString();
            if (date.Date.Month < 10)
                d += "0" + date.Date.Month;
            else
                d += date.Date.Month.ToString();
            if (date.Date.Day < 10)
                d += "0" + date.Date.Day;
            else
                d += date.Date.Day.ToString();

            return d;
        }

        public DateTime[] makeDate(int subtract = 0)
        {
            DateTime date = DateTime.Now;
            DateTime[] resultList = new DateTime[2];
            date = date.AddMonths(subtract * -1);
            DateTime temp = new DateTime(date.Date.Year, date.Date.Month, 1);//date du premier jour du mois
            resultList[0] = temp;
            resultList[1] = temp.AddMonths(1).AddDays(-1);//date du dernier jour du mois

            return resultList;
        }

        /*
            cette fonction prend en entree les informations sur les transferts, calcule la quantite totale transferee
            et la moyenne journaliere de transfert. le resultat est retournee sous forme de tableau de deux entiers
        */
        public int[] extractQte(String[] liste, int coef)
        {
            int sum = 0;
            if(liste !=null && liste.Length > 0)
            {
                for(int i = 0; i < liste.Length; i++)
                {
                    sum += Decimal.ToInt32(Decimal.Parse(liste[5]));
                }
            }
            int[] result = new int[2];
            result[0] = sum;
            result[1] = (int)Math.Round((double)sum / coef);
            return result;
        }

        public void inserQueue(String ar_ref,String ar_design,List<String[]> cumulDonnees, int qteMoyJourGlob)
        {
            Node noeud = new Node();
            noeud.setRef(ar_ref);
            noeud.setDesign(ar_design);
            noeud.setQteMoyJour(qteMoyJourGlob);
            noeud.setStockDP(stockDP(ar_ref));
            noeud.setCumulDonnees(cumulDonnees);
            noeud.setLotSerie(lotSerie(ar_ref));
            this.listeArticles.enqueue(noeud);
        }

        public Decimal stockDP(String ar_ref)
        {
            String request = "SELECT AS_QteSto FROM F_ARTSTOCK WHERE AR_Ref = '{0}' AND DE_No = 1";
            request = String.Format(request, ar_ref);
            Decimal result = Decimal.Zero;
            using(SqlCommand cmd = new SqlCommand(request, this.sqlservercon))
            {
                using(SqlDataReader sd = cmd.ExecuteReader())
                {
                    if (sd.Read())
                    {
                        result = sd.GetDecimal(0);
                    }
                }
            }

            return result;
        }

        public List<String[]> lotSerie(String ar_ref)
        {
            String request = @"
                SELECT LS_QteRestant,LS_Peremption,LS_NoSerie,DE_No
                FROM F_LOTSERIE
                WHERE AR_Ref = '{0}'
                    AND (DE_No=5 or DE_No=6)
                    AND LS_LotEpuise = 0
                ORDER BY LS_Peremption,LS_QteRestant asc
            ";
            request = String.Format(request, ar_ref);
            String[] result=null;
            List<String[]> temp = new List<string[]>();
            using (SqlCommand cmd = new SqlCommand(request, this.sqlservercon))
            {
                using (SqlDataReader sd = cmd.ExecuteReader())
                {
                    while (sd.Read())
                    {
                        result = new string[4];
                        result[0] = sd.GetDecimal(0).ToString();
                        result[1] = sd.GetDateTime(1).ToString();
                        result[2] = sd.GetString(2);
                        result[3] = sd.GetInt32(3).ToString();
                        temp.Add(result);
                    }
                }
            }

            return temp;
        }

        public int findCategory(Node noeud)
        {
            int cpt = 0;
            foreach(String[] row in noeud.getCumulDonnees())
            {
                if (int.Parse(row[3]) == 0)
                    cpt += 1;
            }

            if (cpt <= 1)
                return 1;
            else if (cpt <= 2)
                return 2;
            else
                return 3;
        }

        public int isValid(int m)
        {
            int j = 0;
            foreach(int i in this.lastthreemonths)
            {
                if (i == m)
                    j += 1;
            }
            return j;
        }

        public void makeProposition()
        {
            Queue p = this.listeArticles;
            Node q = this.listeArticles.getHead();
            int validMonth, nummonth;
            while(q != null)
            {
                validMonth = 0;
                nummonth = 0;

                foreach (String[] row in q.getValue().getCumulDonnees())
                {
                    if(int.Parse(row[3]) > 0)
                    {
                        nummonth += 1;
                        if (isCorrectMonth(int.Parse(row[1]))) //on verifie si le mois appartient aux trois dernier, le mois courant inclus
                            validMonth += 1;
                    }
                }
                q.getValue().setCategorie(findCategory(q.getValue()));

                /*
                     on ne retient que des articles donc le nombre de mouvements est d'au moins
                     3 mois dont 2 au moins sont recents et que la quantite en DP est inferieure
                     a la quantite reguliere d'approvisionnement
                 */
                if ( nummonth >= 3 && validMonth >= 2) 
                {
                    if(q.getValue().getStockDP() < q.getValue().getQteMoyJour() * q.getValue().getDureeStock())
                    {
                        q.getValue().setAppro(true);
                        selectionnerLot(q.getValue());
                    }
                }

                q = q.getLeftChild();
            }
        }

        private void selectionnerLot(Node q)//not finished yet
        {
            Decimal dp = q.getStockDP();
            Decimal qmjg = q.getQteMoyJour() * q.getDureeStock();
            Decimal commande =  qmjg - dp;// pour l'instant, on ne tient pas compte des quantites standards
            int temp = Decimal.ToInt32(commande),con;
            List<String[]> retenir = new List<string[]>();
            foreach(String[] row in q.getLotSerie())
            {
                con = (int)double.Parse(row[0], CultureInfo.InvariantCulture);
                if (con >= temp)
                {
                    temp = 0;
                }
                else
                {
                    temp -= con;
                }
                retenir.Add(row);
                if(temp == 0)
                {
                    break;
                }
            }
            q.setLotsRetenus(formatLots(retenir));
        }

        private List<String[]> formatLots(List<String[]> lots)
        {
            List<String[]> temp = new List<string[]>();
            int con;
            foreach(String[] row in lots)
            {
                con = (int)double.Parse(row[3], CultureInfo.InvariantCulture);
                if (con == 5)
                    temp.Add(row);
            }
            foreach (String[] row in lots)
            {
                con = (int)double.Parse(row[3], CultureInfo.InvariantCulture);
                if (con == 6)
                    temp.Add(row);
            }
            return temp;
        }

        public Boolean isCorrectMonth(int m)
        {
            foreach(int i in this.lastthreemonths)
            {
                if (i == m)
                    return true;
            }
            return false;
        }

        public List<String[]> displayAppro()
        {
            Node p = this.listeArticles.getHead(),q;
            String[] row;
            List<String[]> result = new List<string[]>();
            while (p != null)
            {
                q = p.getValue();
                row = new string[6];
                row[0] = q.getRef();
                row[1] = q.getDesign();
                row[2] = q.getStockDP().ToString();
                row[3] = (q.getQteMoyJour() * q.getDureeStock()).ToString();
                row[4] = q.getCategorie().ToString();
                row[5] = q.getAppro().ToString();
                result.Add(row);

                p = p.getLeftChild();
            }

            return result;
        }
    }
}
