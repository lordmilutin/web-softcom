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
    public partial class ObrisiSaradnika : System.Web.UI.Page
    {
        public bool displayError = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int sid = Convert.ToInt32(Request.QueryString["sid"]);
                ISession sesija = DataLayer.DataLayer.GetSession();
                Saradnik sar = sesija.Load<Saradnik>(sid);

                sesija.Delete(sar);
                sesija.Flush();
                sesija.Close();

                Response.Redirect("/SviSaradnici");

            }
            catch (Exception ex)
            {
                displayError = true;
                this.error.Controls.Add(new LiteralControl(ex.Message));
            }
        }
    }
}