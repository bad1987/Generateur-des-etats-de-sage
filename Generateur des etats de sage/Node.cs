using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur_des_etats_de_sage
{
    class Node
    {
        //node properties
        private Node value;
        private Decimal DL_Qte;
        private Node leftChild;
        private Node rightChild;
        private String AR_Ref;
        private String AR_Design;
        private Decimal QteMoyJour;
        private int annee;
        private int mois;
        private List<String[]> cumulDonnees;
        private Decimal stockDP;
        private Boolean appro;
        private int categorie;
        private List<String[]> lotsRetenus;
        private List<String[]> lotSerie;
        private int dureeStock;
        

        public Node(Node value=null)
        {
            this.value = value;
            this.DL_Qte = Decimal.Zero;
            this.leftChild = null;
            this.rightChild = null;
            this.AR_Ref = null;
            this.AR_Design = null;
            this.QteMoyJour = Decimal.Zero;
            this.annee = 0;
            this.mois = -1;
            this.cumulDonnees = null;
            this.stockDP = Decimal.Zero;
            this.appro = false;
            this.categorie = -1;
            this.lotsRetenus = null;
            this.lotSerie = null;
            this.dureeStock = 4;

        }
        

        public Node getLeftChild()
        {
            return this.leftChild;
        }

        public void setLeftChild(Node l)
        {
            this.leftChild = l;
        }

        public Node getRightChild()
        {
            return this.rightChild;
        }

        public void setRightChild(Node l)
        {
            this.rightChild = l;
        }

        public Node getValue()
        {
            return this.value;
        }

        public void setValue(Node value)
        {
            this.value = value;
        }

        public String getRef()
        {
            return this.AR_Ref;
        }

        public void setRef(String value)
        {
            this.AR_Ref = value;
        }

        public String getDesign()
        {
            return this.AR_Design;
        }

        public void setDesign(String value)
        {
            this.AR_Design = value;
        }

        public Decimal getQte()
        {
            return this.DL_Qte;
        }

        public void setQte(Decimal value)
        {
            this.DL_Qte = Decimal.Parse(DecimalToString(value));
        }

        public List<String[]> getCumulDonnees()
        {
            return this.cumulDonnees;
        }

        public void setCumulDonnees(List<String[]> value)
        {
            this.cumulDonnees = value;
        }

        public Decimal getQteMoyJour()
        {
            return this.QteMoyJour;
        }

        public void setQteMoyJour(Decimal value)
        {
            this.QteMoyJour = value;
        }

        public int getAnnee()
        {
            return this.annee;
        }

        public void setAnnee(int value)
        {
            this.annee = value;
        }

        public int getMois()
        {
            return this.mois;
        }

        public void setMois(int value)
        {
            this.mois = value;
        }

        public Decimal getStockDP()
        {
            return this.stockDP;
        }

        public void setStockDP(Decimal value)
        {
            this.stockDP = Decimal.Parse(DecimalToString(value));
        }

        public Boolean getAppro()
        {
            return this.appro;
        }

        public void setAppro(Boolean value)
        {
            this.appro = value;
        }

        public int getCategorie()
        {
            return this.categorie;
        }

        public void setCategorie(int value)
        {
            this.categorie = value;
        }

        public List<String[]> getLotsRetenus()
        {
            return this.lotsRetenus;
        }

        public void setLotsRetenus(List<String[]> value)
        {
            this.lotsRetenus = value;
        }

        public List<String[]> getLotSerie()
        {
            return this.lotSerie;
        }

        public void setLotSerie(List<String[]> value)
        {
            this.lotSerie = value;
        }

        public int getDureeStock()
        {
            return this.dureeStock;
        }

        public void setRef(int value)
        {
            this.dureeStock = value;
        }

        public string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }
    }
}
