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
    public partial class SviZaposleni : System.Web.UI.Page
    {
        private IList<Zaposleni> zaposleni;
        public bool displayError = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Load sve zaposlene
                ISession sesija = DataLayer.DataLayer.GetSession();
                IQuery sql = sesija.CreateQuery("FROM Zaposleni");
                this.zaposleni = sql.List<Zaposleni>();

                // Html table head
                HtmlTable table = new HtmlTable();

                table.Attributes["class"] = "table table-striped table-hover";

                HtmlTableRow row1 = new HtmlTableRow();

                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "#" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Ime" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Prezime" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Pozicija" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Adresa" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Telefon" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "JMBG" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Programski jezici" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Br.Saradnika" });
                table.Rows.Add(row1);

                int i = 1;

                foreach (Zaposleni zap in zaposleni)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    HtmlTableCell cell = new HtmlTableCell();

                    string link = "ZaposleniProfile?zid=" + zap.ZID.ToString();

                    row.Cells.Add(new HtmlTableCell() { InnerHtml = (i++).ToString() });
                    row.Cells.Add(new HtmlTableCell() { InnerHtml = "<a href='" + link + "'>" + zap.ime + "</a>" });
                    row.Cells.Add(new HtmlTableCell() { InnerHtml = "<a href='" + link + "'>" + zap.prezime + "</a>" });
                    row.Cells.Add(new HtmlTableCell() { InnerHtml = zap.pozicija });
                    row.Cells.Add(new HtmlTableCell() { InnerHtml = zap.adresa });
                    row.Cells.Add(new HtmlTableCell() { InnerHtml = zap.telefon });
                    row.Cells.Add(new HtmlTableCell() { InnerHtml = zap.jmbg.ToString() });

                    string jezici = "";
                    if (zap.F_CPP == 1) jezici += "C++, ";
                    if (zap.F_CS == 1) jezici += "C#, ";
                    if (zap.F_PHP == 1) jezici += "PHP, ";
                    if (zap.F_Java == 1) jezici += "Java, ";
                    if (jezici.Length < 1) jezici = "-- ";

                    row.Cells.Add(new HtmlTableCell() { InnerHtml = jezici.Remove(jezici.Length - 2) }); // Remove sklanja , ili -


                    row.Cells.Add(new HtmlTableCell() { InnerHtml = zap.saradnici.Count.ToString() });

                    table.Rows.Add(row);
                }

                this.panel.Controls.Add(table);
                sesija.Close();
            }
            catch(Exception ex)
            {
                displayError = true;
                this.error.Controls.Add(new LiteralControl(ex.Message));
            }
        }
    }
}