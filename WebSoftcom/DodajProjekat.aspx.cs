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
    public partial class DodajProjekat : System.Web.UI.Page
    {
        public bool displayError = false;
        public IList<Zaposleni> sefovi;
        public IList<Zaposleni> zaposleni;

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


                // Ako je submitovana forma za unos
                if ( Request.ServerVariables["REQUEST_METHOD"] == "POST")
                {
                    // Form validation

                    var naziv = Request.Form["nazivProjekta"];
                    var izrada = Request.Form["izrada"];
                    DateTime datumPocetka = Convert.ToDateTime(Request.Form["datumPocetka"]);
                    DateTime datumZavrsetka = Convert.ToDateTime(Request.Form["datumZavrsetka"]);

                    Projekat proj = new Projekat() { ime = naziv, izrada = izrada, datumPocetka = datumPocetka, datumZavrsetka = datumZavrsetka  };

                    if (naziv.Length < 3) throw new Exception("Naziv projekta isuviše kratak");

                    // Dodavanje selektovanih radnika na projekat
                    var selRad = Request.Form["radniciProjekta"];

                    char[] delimiters = { ',' };
                    string[] selektovaniRadnici = selRad.Split(delimiters);

                    foreach (var radnikID in selektovaniRadnici)
                    {
                        var radnik = sesija.Load<Zaposleni>(Convert.ToInt32(radnikID));
                        // Po defaultu svi radnici pri kreiranju projekta dobijaju da rade od pocetka do kraja na njemu
                        var radi = new RadiNa { projekat = proj, radnik = radnik, datum_pocetka = datumPocetka, datum_zavrsetka = datumZavrsetka };
                        proj.radnici.Add(radi);
                    }

                    if (izrada == "insource")
                    {
                        var sefID = Convert.ToInt32(Request.Form["sef"]);
                        Zaposleni sef = sesija.Load<Zaposleni>(sefID);
                        DateTime vodiOd = Convert.ToDateTime(Request.Form["vodiOd"]);
                        DateTime vodiDo = Convert.ToDateTime(Request.Form["vodiDo"]);

                        Vodi vodi = new Vodi() { sef = sef, projekat = proj, vodiOd = vodiOd, vodiDo = vodiDo };
                        proj.vodi.Add(vodi);
                    }
                    else if (izrada == "outsource")
                    {
                        var nazivFirme = Request.Form["nazivFirme"];
                        var adresaFirme = Request.Form["adresaFirme"];
                        proj.nazivFirme = nazivFirme;
                        proj.adresaFirme = adresaFirme;
                    }
                    else
                    {
                        throw new Exception("Greška pri izboru tipa izrade");
                    }

                    sesija.Save(proj);
                    sesija.Flush();
                    sesija.Close();

                    Response.Redirect("/SviProjekti");
                }
                // Ako nije submitovana forma, prikazujemo formu
                else
                {
                    

                }

                

                sesija.Flush();
                sesija.Close();
 

            }
            catch (Exception ex)
            {
                displayError = true;
                this.error.Controls.Add(new LiteralControl(ex.Message));
            }
        }
    }
}