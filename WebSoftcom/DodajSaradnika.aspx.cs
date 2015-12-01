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
    public partial class DodajSaradnika : System.Web.UI.Page
    {
        public bool displayError = false;
        public IList<Zaposleni> programeri;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ISession sesija = DataLayer.DataLayer.GetSession();
                IQuery sql = sesija.CreateQuery("FROM Zaposleni as z WHERE z.pozicija LIKE ? ");
                sql.SetString(0, "%junior%");
                this.programeri = sql.List<Zaposleni>();

                // Ako je submitovana forma za unos
                if (Request.ServerVariables["REQUEST_METHOD"] == "POST")
                {
                    // Form validation

                    var ime = Request.Form["ime"];
                    var prezime = Request.Form["prezime"];
                    var telefon = Request.Form["telefon"];
                    var adresa = Request.Form["adresa"];
                    var programer = Request.Form["programer"];

                    if (ime.Length < 3) throw new Exception("Ime je isuviše kratko");
                    if (prezime.Length < 3) throw new Exception("Prezime je isuviše kratko");

                    Zaposleni nadredjeni = sesija.Load<Zaposleni>(Convert.ToInt32(programer));

                    Saradnik sar = new Saradnik() { ime = ime, prezime = prezime, telefon = telefon, nadredjeni = nadredjeni };

                    sesija.Save(sar);
                    sesija.Flush();
                    sesija.Close();

                    Response.Redirect("/SviSaradnici");
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