<%@ Page Title="Dodaj Projekat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DodajProjekat.aspx.cs" Inherits="WebSoftcom.DodajProjekat" %>

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
                $("#datumPocetka").datepicker({ dateFormat: 'dd/mm/yy'});
                $("#datumZavrsetka").datepicker({ dateFormat: 'dd/mm/yy' });
                $("#vodiOd").datepicker({ dateFormat: 'dd/mm/yy' });
                $("#vodiDo").datepicker({ dateFormat: 'dd/mm/yy' });
            });
        </script>

        <div class="col-md-8 well">
            <form class="form-horizontal" method="post" action="">
                <fieldset>

                    <legend>Nov projekat</legend>

                    <div class="form-group">
                        <label for="nazivProjekta" class="col-lg-3 control-label">Naziv projekta</label>
                        <div class="col-lg-9">
                            <input type="text" class="form-control" name="nazivProjekta" id="nazivProjekta" placeholder="Naziv projekta">
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-lg-3 control-label">Izrada</label>
                        <div class="col-lg-9">
                            <div class="radio">
                                <label>
                                    <input type="radio" name="izrada" id="insource" value="insource">
                                    Insource
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="izrada" id="outsource" value="outsource">
                                    Outsource
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="datumPocetka" class="col-lg-3 control-label">Početak izrade</label>
                        <div class="col-lg-5">
                            <input type="text" class="form-control" id="datumPocetka" name="datumPocetka" placeholder="Početak izrade">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="datumZavrsetka" class="col-lg-3 control-label">Rok za završetak</label>
                        <div class="col-lg-5">
                            <input type="text" class="form-control" id="datumZavrsetka" name="datumZavrsetka" placeholder="Rok za završetak">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="select" class="col-lg-3 control-label">Šef projekta*</label>
                        <div class="col-lg-5">
                            <select class="form-control" id="selectSef" name="sef">
                                <% foreach (var sef in sefovi)
                                   { %>
                                <option value="<%: sef.ZID %>"><%: sef.ime + " " + sef.prezime %></option>
                                <% } %>
                            </select>
                            <p><i>*Samo za insource projekte</i></p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="vodiOd" class="col-lg-3 control-label">Vodi od</label>
                        <div class="col-lg-5">
                            <input type="text" class="form-control" id="vodiOd" name="vodiOd" placeholder="Vodi od">
                            <p><i>*Samo za insource projekte</i></p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="vodiDo" class="col-lg-3 control-label">Vodi do</label>
                                <div class="col-lg-5">
                                    <input type="text" class="form-control" id="vodiDo" name="vodiDo" placeholder="Vodi do">
                                    <p><i>*Samo za insource projekte</i></p>
                                </div>
                    </div>


                    <div class="form-group">
                        <label for="select" class="col-lg-3 control-label">Radnici na projektu</label>
                        <div class="col-lg-5">
                            <select multiple="" class="form-control" name="radniciProjekta">
                                <% foreach (var zap in zaposleni)
                                   { %>
                                <option value="<%: zap.ZID %>"><%: zap.ime + " " + zap.prezime %></option>
                                <% } %>
                            </select>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="nazivFirme" class="col-lg-3 control-label">Naziv firme</label>
                        <div class="col-lg-9">
                            <input type="text" class="form-control" id="nazivFirme" placeholder="Naziv outsource firme">
                            <p><i>*Samo za outsource projekte</i></p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="adresaFirme" class="col-lg-3 control-label">Adresa firme</label>
                        <div class="col-lg-9">
                            <input type="text" class="form-control" id="adresaFirme" placeholder="Adresa outsource firme">
                            <p><i>*Samo za outsource projekte</i></p>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-9 col-lg-offset-3">
                            <button type="submit" class="btn btn-success">Dodaj</button>
                            <button class="btn btn-danger">Odustani</button>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>

    </div>
</asp:Content>
