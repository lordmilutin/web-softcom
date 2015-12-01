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
    public partial class IzmeniSaradnika : System.Web.UI.Page
    {
        public Saradnik editSar;
        public bool displayError = false;
        public IList<Zaposleni> programeri;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ISession sesija = DataLayer.DataLayer.GetSession();

                int sarID = Convert.ToInt32(Request.QueryString["sid"]);
                this.editSar = sesija.Load<Saradnik>(sarID);

                IQuery sql = sesija.CreateQuery("FROM Zaposleni WHERE pozicija LIKE ?");
                sql.SetString(0,"%junior%");

                this.programeri = sql.List<Zaposleni>();

                // Ako je submitovana forma za unos
                if (Request.ServerVariables["REQUEST_METHOD"] == "POST")
                {
                    // Form validation

                    editSar.ime = Request.Form["ime"];
                    editSar.prezime = Request.Form["prezime"];
                    editSar.telefon = Request.Form["telefon"];

                    if (editSar.ime.Length < 3) throw new Exception("Ime je prekratko");
                    if (editSar.prezime.Length < 3) throw new Exception("Prezime je prekratko");


                    Zaposleni prog = sesija.Load<Zaposleni>(Convert.ToInt32(Request.Form["nadredjeni"]));
                    editSar.nadredjeni = prog;


                    sesija.Update(editSar);
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