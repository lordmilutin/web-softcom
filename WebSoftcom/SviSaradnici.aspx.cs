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
    public partial class SviSaradnici : System.Web.UI.Page
    {
        private IList<Saradnik> saradnici;
        public bool displayError = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Load sve zaposlene
                ISession sesija = DataLayer.DataLayer.GetSession();
                IQuery sql = sesija.CreateQuery("FROM Saradnik");
                this.saradnici = sql.List<Saradnik>();

                // Html table head
                HtmlTable table = new HtmlTable();

                table.Attributes["class"] = "table table-striped table-hover";

                HtmlTableRow row1 = new HtmlTableRow();

                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "#" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Ime" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Prezime" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Telefon" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Angažovao ga" });
                table.Rows.Add(row1);

                int i = 1;

                foreach (Saradnik sar in saradnici)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    HtmlTableCell cell = new HtmlTableCell();

                    string link = "SaradnikProfile?sid=" + sar.SID.ToString();

                    row.Cells.Add(new HtmlTableCell() { InnerHtml = (i++).ToString() });
                    row.Cells.Add(new HtmlTableCell() { InnerHtml = "<a href='" + link + "'>" + sar.ime + "</a>" });
                    row.Cells.Add(new HtmlTableCell() { InnerHtml = "<a href='" + link + "'>" + sar.prezime + "</a>" });
                    row.Cells.Add(new HtmlTableCell() { InnerHtml = sar.telefon });
                    row.Cells.Add(new HtmlTableCell() { InnerHtml = sar.nadredjeni.ime + " " + sar.nadredjeni.prezime });


                    table.Rows.Add(row);
                }

                this.panel.Controls.Add(table);
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