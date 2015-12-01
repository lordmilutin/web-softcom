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
    public partial class ZaposleniProfile : System.Web.UI.Page
    {
        public Zaposleni zaposleni;
        public bool displayError = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ISession sesija = DataLayer.DataLayer.GetSession();
                int zid = Convert.ToInt32(Request.QueryString["zid"]);
                this.zaposleni = sesija.Load<Zaposleni>(zid);
            }
            catch (Exception ex)
            {
                displayError = true;
                this.error.Controls.Add(new LiteralControl(ex.Message));
            }
        }
    }
}