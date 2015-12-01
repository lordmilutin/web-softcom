<%@ Page Title="Izmeni Projekat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IzmeniProjekat.aspx.cs" Inherits="WebSoftcom.IzmeniProjekat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <% if (displayError)
       { %>
    <div class="alert alert-dismissable alert-danger">
        <strong>
            <asp:Panel runat="server" ID="error"></asp:Panel>
        </strong>
    </div>
    <%} %>
    <div class="col-md-10 col-md-offset-1">


        <script src="//code.jquery.com/ui/1.11.0/jquery-ui.js"></script>

        <script type="text/javascript">
            $(function () {
                $("#datumPocetka").datepicker({ dateFormat: 'dd/mm/yy' });
                $("#datumZavrsetka").datepicker({ dateFormat: 'dd/mm/yy' });
                $("#vodiOd").datepicker({ dateFormat: 'dd/mm/yy' });
                $("#vodiDo").datepicker({ dateFormat: 'dd/mm/yy' });
            });
        </script>

        <div class="col-md-8 well">
            <form class="form-horizontal" method="post" action="">
                <fieldset>

                    <legend>Izmeni projekat</legend>

                    <div class="form-group">
                        <label for="nazivProjekta" class="col-lg-3 control-label">Naziv projekta</label>
                        <div class="col-lg-9">
                            <input type="text" class="form-control" name="nazivProjekta" id="nazivProjekta" placeholder="Naziv projekta" value="<%: editProj.ime  %>">
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-lg-3 control-label">Izrada</label>
                        <div class="col-lg-9">
                            <div class="radio">
                                <label>
                                    <input type="radio" name="izrada" id="insource" value="insource" <% if (editProj.izrada == "insource") Response.Write("checked"); %>>
                                    Insource
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="izrada" id="outsource" value="outsource" <% if (editProj.izrada == "outsource") Response.Write("checked"); %>>
                                    Outsource
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="datumPocetka" class="col-lg-3 control-label">Početak izrade</label>
                        <div class="col-lg-5">
                            <input type="text" class="form-control" id="datumPocetka" name="datumPocetka" placeholder="Početak izrade" value="<%: editProj.datumPocetka.ToString().Remove(10) %>">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="datumZavrsetka" class="col-lg-3 control-label">Rok za završetak</label>
                        <div class="col-lg-5">
                            <input type="text" class="form-control" id="datumZavrsetka" name="datumZavrsetka" placeholder="Rok za završetak" value="<%: editProj.datumZavrsetka.ToString().Remove(10)  %>">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="select" class="col-lg-3 control-label">Šef projekta*</label>
                        <div class="col-lg-5">
                            <select class="form-control" id="selectSef" name="sef">
                                <% foreach (var sef2 in sefovi)
                                   { %>
                                <option value="<%: sef2.ZID %>" 
                                    <% 
                                    if ( editProj.izrada == "insource")
                                        if (sef2.ZID == editProj.trenutniLeader.sef.ZID) Response.Write("SELECTED"); 
                                    %> >
                                    <%: sef2.ime + " " + sef2.prezime %></option>
                                <% } %>
                            </select>
                            <p><i>*Samo za insource projekte</i></p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="vodiOd" class="col-lg-3 control-label">Vodi od</label>
                        <div class="col-lg-5">
                            <input type="text" class="form-control" id="vodiOd" name="vodiOd" placeholder="Vodi od" value="<%: editProj.trenutniLeader.vodiOd.ToString().Remove(10)  %>">
                            <p><i>*Samo za insource projekte</i></p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="vodiDo" class="col-lg-3 control-label">Vodi do</label>
                                <div class="col-lg-5">
                                    <input type="text" class="form-control" id="vodiDo" name="vodiDo" placeholder="Vodi do" value="<%: editProj.trenutniLeader.vodiDo.ToString().Remove(10)  %>">
                                    <p><i>*Samo za insource projekte</i></p>
                                </div>
                    </div>

                    <div class="form-group">
                        <label for="nazivFirme" class="col-lg-3 control-label">Naziv firme</label>
                        <div class="col-lg-9">
                            <input type="text" class="form-control" id="nazivFirme" placeholder="Naziv outsource firme" value="<%: editProj.nazivFirme  %>">
                            <p><i>*Samo za outsource projekte</i></p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="adresaFirme" class="col-lg-3 control-label">Adresa firme</label>
                        <div class="col-lg-9">
                            <input type="text" class="form-control" id="adresaFirme" placeholder="Adresa outsource firme" value="<%: editProj.adresaFirme %>">
                            <p><i>*Samo za outsource projekte</i></p>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-9 col-lg-offset-3">
                            <button type="submit" class="btn btn-success">Izmeni</button>
                            <button class="btn btn-danger">Odustani</button>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>

    </div>
</asp:Content>
