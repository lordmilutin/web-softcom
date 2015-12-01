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
    public partial class Projekti : System.Web.UI.Page
    {
        private IList<Projekat> projekti;
        public bool displayError = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Load sve projekte
                ISession sesija = DataLayer.DataLayer.GetSession();
                IQuery sql = sesija.CreateQuery("FROM Projekat");
                this.projekti = sql.List<Projekat>();

                // Html table head
                HtmlTable insourceTable = new HtmlTable();
                HtmlTable outsourceTable = new HtmlTable();

                insourceTable.Attributes["class"] = "table table-striped table-hover";
                outsourceTable.Attributes["class"] = "table table-striped table-hover";

                HtmlTableRow row1 = new HtmlTableRow();
                HtmlTableRow row2 = new HtmlTableRow();


                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "#" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Naziv projekta" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Datum početka" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Rok za završetak" });
                row1.Cells.Add(new HtmlTableCell() { InnerHtml = "Vođa projekta" });
                insourceTable.Rows.Add(row1);

                row2.Cells.Add(new HtmlTableCell() { InnerHtml = "#" });
                row2.Cells.Add(new HtmlTableCell() { InnerHtml = "Naziv projekta" });
                row2.Cells.Add(new HtmlTableCell() { InnerHtml = "Datum početka" });
                row2.Cells.Add(new HtmlTableCell() { InnerHtml = "Rok za završetak" });
                row2.Cells.Add(new HtmlTableCell() { InnerHtml = "Radi se za firmu" });
                outsourceTable.Rows.Add(row2);

            
                int i = 1, j = 1;

                foreach (Projekat projekat in projekti)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    HtmlTableCell cell = new HtmlTableCell();

                    string link = "ProjekatProfile?pid=" + projekat.PID.ToString();

                    if (projekat.izrada == "insource")
                    {
                        cell = new HtmlTableCell();
                        cell.InnerHtml = (i++).ToString();
                        row.Cells.Add(cell);

                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<a href='" + link + "'>" + projekat.ime + "</a>";
                        row.Cells.Add(cell);

                        cell = new HtmlTableCell();
                        cell.InnerHtml = projekat.datumPocetka.ToString().Remove(10);
                        row.Cells.Add(cell);

                        cell = new HtmlTableCell();
                        cell.InnerHtml = projekat.datumZavrsetka.ToString().Remove(10);
                        row.Cells.Add(cell);

                        var leader = projekat.trenutniLeader;
                        cell = new HtmlTableCell();
                        cell.InnerHtml = leader.sef.ime + " " + leader.sef.prezime;
                        row.Cells.Add(cell);

                        insourceTable.Rows.Add(row);
                    }

                    if (projekat.izrada == "outsource")
                    {
                        cell = new HtmlTableCell();
                        cell.InnerHtml = (j++).ToString();
                        row.Cells.Add(cell);

                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<a href='" + link + "'>" + projekat.ime + "</a>";
                        row.Cells.Add(cell);

                        cell = new HtmlTableCell();
                        cell.InnerHtml = projekat.datumPocetka.ToString().Remove(10);
                        row.Cells.Add(cell);

                        cell = new HtmlTableCell();
                        cell.InnerHtml = projekat.datumZavrsetka.ToString().Remove(10);
                        row.Cells.Add(cell);

                        cell = new HtmlTableCell();
                        cell.InnerHtml = projekat.nazivFirme;
                        row.Cells.Add(cell);
                        outsourceTable.Rows.Add(row);
                    }

                }

                this.insource.Controls.Add(insourceTable);
                this.outsource.Controls.Add(outsourceTable);
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