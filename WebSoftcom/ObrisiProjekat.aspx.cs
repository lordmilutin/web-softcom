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
    public partial class ObrisiProjekat : System.Web.UI.Page
    {
        public bool displayError = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(Request.QueryString["pid"]);
                ISession sesija = DataLayer.DataLayer.GetSession();
                Projekat proj = sesija.Load<Projekat>(pid);

                sesija.Delete(proj);
                sesija.Flush();
                sesija.Close();

                Response.Redirect("/SviProjekti");

            }
            catch (Exception ex)
            {
                displayError = true;
                this.error.Controls.Add(new LiteralControl(ex.Message));
            }
        }
    }
}