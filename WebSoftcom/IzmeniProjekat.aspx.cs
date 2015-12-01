using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer.Entiteti;
using DataLayer;
using NHibernate;
using System.Web.UI.HtmlControls;

namespace WebSoftcom
{
    public partial class IzmeniProjekat : System.Web.UI.Page
    {
        public bool displayError = false;
        public IList<Zaposleni> sefovi;
        public IList<Zaposleni> zaposleni;
        public Projekat editProj;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ISession sesija = DataLayer.DataLayer.GetSession();

                IQuery sql = sesija.CreateQuery("FROM Zaposleni as z WHERE z.pozicija LIKE ? ");
                sql.SetString(0, "%senior%");
                this.sefovi = sql.List<Zaposleni>();

                IQuery sql2 = sesija.CreateQuery("From Zaposleni");
                this.zaposleni = sql.List<Zaposleni>();


                int projID = Convert.ToInt32(Request.QueryString["pid"]);
                this.editProj = sesija.Load<Projekat>(projID);
                
                // Ako je submitovana forma za unos
                if ( Request.ServerVariables["REQUEST_METHOD"] == "POST")
                {
                    // Form validation

                    var naziv = Request.Form["nazivProjekta"];
                    var izrada = Request.Form["izrada"];
                    DateTime datumPocetka = Convert.ToDateTime(Request.Form["datumPocetka"]);
                    DateTime datumZavrsetka = Convert.ToDateTime(Request.Form["datumZavrsetka"]);

                    editProj.ime = naziv; 
                    editProj.izrada = izrada; 
                    editProj.datumPocetka = datumPocetka;
                    editProj.datumZavrsetka = datumZavrsetka;

                    if (naziv.Length < 3) throw new Exception("Naziv projekta isuviše kratak");

                    // Dodavanje selektovanih radnika na projekat
                   
                    if (izrada == "insource")
                    {
                        var sefID = Convert.ToInt32(Request.Form["sef"]);
                        Zaposleni sef = sesija.Load<Zaposleni>(sefID);
                        DateTime vodiOd = Convert.ToDateTime(Request.Form["vodiOd"]);
                        DateTime vodiDo = Convert.ToDateTime(Request.Form["vodiDo"]);

                        Vodi vodi = new Vodi() { sef = sef, projekat = editProj, vodiOd = vodiOd, vodiDo = vodiDo };
                        editProj.vodi.Add(vodi);
                    }
                    else if (izrada == "outsource")
                    {
                        var nazivFirme = Request.Form["nazivFirme"];
                        var adresaFirme = Request.Form["adresaFirme"];
                        editProj.nazivFirme = nazivFirme;
                        editProj.adresaFirme = adresaFirme;
                    }
                    else
                    {
                        throw new Exception("Greška pri izboru tipa izrade");
                    }

                    sesija.Update(editProj);
                    sesija.Flush();
                    sesija.Close();

                    Response.Redirect("/SviProjekti");
                }
                // Ako nije submitovana forma, prikazujemo formu
                else
                {
                    

                }

                

                
 

            }
            catch (Exception ex)
            {
                displayError = true;
                this.error.Controls.Add(new LiteralControl(ex.Message));
            }
        }
    }
}