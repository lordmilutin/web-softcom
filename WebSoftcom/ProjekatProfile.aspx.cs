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
    public partial class ProjekatProfile : System.Web.UI.Page
    {
        public Projekat projekat;
        public bool displayError = false;
        public IList<Zaposleni> neradnici = new List<Zaposleni>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ISession sesija = DataLayer.DataLayer.GetSession();
                int pid = Convert.ToInt32(Request.QueryString["pid"]);
                this.projekat = sesija.Load<Projekat>(pid);

                IQuery sql = sesija.CreateQuery("FROM Zaposleni");
                IList<Zaposleni> zaposleni = sql.List<Zaposleni>();

                var skip = 0;

                foreach (Zaposleni zap in zaposleni)
                {
                    skip = 0;
                    foreach (RadiNa rad in projekat.radnici)
                    {
                        if (zap.ZID == rad.radnik.ZID)
                            skip = 1;
                    }
                    if (skip == 0)
                        neradnici.Add(zap);
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