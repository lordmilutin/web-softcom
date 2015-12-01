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
    public partial class RadnikProjekat : System.Web.UI.Page
    {
        public bool displayError = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ISession sesija = DataLayer.DataLayer.GetSession();
                int pid = Convert.ToInt32(Request.QueryString["pid"]);
                int zid = Convert.ToInt32(Request.QueryString["zid"]);
                string action = Request.QueryString["a"];

                Projekat proj = sesija.Load<Projekat>(pid);
                Zaposleni zap = sesija.Load<Zaposleni>(zid);

                if (action == "del")
                {
                    IQuery sql = sesija.CreateQuery("FROM RadiNa WHERE ZID = ? AND PID = ?");
                    sql.SetInt32(0, zap.ZID);
                    sql.SetInt32(1, proj.PID);

                    IList<RadiNa> radi = sql.List<RadiNa>();

                    sesija.Delete(radi[0]);
                }

                if (action == "add")
                {
                    RadiNa radi = new RadiNa() { radnik = zap, projekat = proj };
                    sesija.Save(radi);
                }

                sesija.Flush();
                sesija.Close();

                Response.Redirect("ProjekatProfile?pid=" + pid.ToString());

            }
            catch (Exception ex)
            {
                displayError = true;
                this.error.Controls.Add(new LiteralControl(ex.Message));
            }
        }
    }
}