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
    public partial class DodajZaposlenog : System.Web.UI.Page
    {
        public bool displayError = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ISession sesija = DataLayer.DataLayer.GetSession();
                
                // Ako je submitovana forma za unos
                if (Request.ServerVariables["REQUEST_METHOD"] == "POST")
                {
                    // Form validation

                    var ime = Request.Form["ime"];
                    var prezime = Request.Form["prezime"];
                    var jmbg = Convert.ToInt64(Request.Form["jmbg"]);
                    var telefon = Request.Form["telefon"];
                    var adresa = Request.Form["adresa"];
                    var pozicja = Request.Form["pozicija"];

                    if (ime.Length < 3) throw new Exception("Ime je isuviše kratko");
                    if (prezime.Length < 3) throw new Exception("Prezime je isuviše kratko");
                    if (jmbg.ToString().Length < 10) throw new Exception("Unesite ispravan JMBG");
                    if (!(pozicja == "senior" || pozicja == "junior")) throw new Exception("Greška u vezi pozicije");


                    Zaposleni zap = new Zaposleni() { ime = ime, prezime = prezime, jmbg = jmbg, telefon = telefon, adresa = adresa, pozicija = pozicja };

                    if (Request.Form["cpp"] == "1") zap.F_CPP = 1;
                    if (Request.Form["cs"] == "1") zap.F_CS = 1;
                    if (Request.Form["php"] == "1") zap.F_PHP = 1;
                    if (Request.Form["java"] == "1") zap.F_Java = 1;

                    sesija.Save(zap);
                    sesija.Flush();
                    sesija.Close();

                    Response.Redirect("/SviZaposleni");
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