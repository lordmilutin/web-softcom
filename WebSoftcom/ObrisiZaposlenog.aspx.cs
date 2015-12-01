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
    public partial class ObrisiZaposlenog : System.Web.UI.Page
    {
        public bool displayError = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int zid = Convert.ToInt32(Request.QueryString["zid"]);
                ISession sesija = DataLayer.DataLayer.GetSession();
                Zaposleni zap = sesija.Load<Zaposleni>(zid);

                sesija.Delete(zap);
                sesija.Flush();
                sesija.Close();

                Response.Redirect("/SviZaposleni");

            }
            catch (Exception ex)
            {
                displayError = true;
                this.error.Controls.Add(new LiteralControl(ex.Message));
            }
        }
    }
}