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
    public partial class IzmeniZaposlenog : System.Web.UI.Page
    {
        public Zaposleni editZap;
        public bool displayError = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ISession sesija = DataLayer.DataLayer.GetSession();

                int zapID = Convert.ToInt32(Request.QueryString["zid"]);
                this.editZap = sesija.Load<Zaposleni>(zapID);

                // Ako je submitovana forma za unos
                if (Request.ServerVariables["REQUEST_METHOD"] == "POST")
                {
                    // Form validation

                    editZap.ime = Request.Form["ime"];
                    editZap.prezime = Request.Form["prezime"];
                    editZap.jmbg = Convert.ToInt64(Request.Form["jmbg"]);
                    editZap.adresa = Request.Form["adresa"];
                    editZap.telefon = Request.Form["telefon"];
                    editZap.pozicija = Request.Form["pozicija"];

                    if (editZap.ime.Length < 3) throw new Exception("Ime je prekratko");
                    if (editZap.prezime.Length < 3) throw new Exception("Prezime je prekratko");

                    if (Request.Form["cpp"] == "1") editZap.F_CPP = 1;
                    else editZap.F_CPP = 0;
                    if (Request.Form["cs"] == "1") editZap.F_CS = 1;
                    else editZap.F_CS = 0;
                    if (Request.Form["php"] == "1") editZap.F_PHP = 1;
                    else editZap.F_PHP = 0;
                    if (Request.Form["java"] == "1") editZap.F_Java = 1;
                    else editZap.F_Java = 0;


                    sesija.Update(editZap);
                    sesija.Flush();
                    sesija.Close();

                    Response.Redirect("/SviZaposleni");
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