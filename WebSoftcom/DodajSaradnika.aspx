<%@ Page Title="Dodaj Saradnika" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DodajSaradnika.aspx.cs" Inherits="WebSoftcom.DodajSaradnika" %>

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
        <div class="col-md-8 well">
            <form class="form-horizontal" method="post" action="">
                <fieldset>

                    <legend>Novi saradnik</legend>

                    <div class="form-group">
                        <label for="ime" class="col-lg-3 control-label">Ime</label>
                        <div class="col-lg-9">
                            <input type="text" class="form-control" name="ime" id="ime" placeholder="Ime">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="prezime" class="col-lg-3 control-label">Prezime</label>
                        <div class="col-lg-9">
                            <input type="text" class="form-control" name="prezime" id="prezime" placeholder="Prezime">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="select" class="col-lg-3 control-label">Selects</label>
                        <div class="col-lg-5">
                            <select class="form-control" id="select" name="programer">
                                <% foreach (var nad in programeri) { %>
                                <option value="<%: nad.ZID %>"><%:nad.ime + " " + nad.prezime %></option>
                                <% } %>
                            </select>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="telefon" class="col-lg-3 control-label">Telefon</label>
                        <div class="col-lg-9">
                            <input type="text" class="form-control" name="telefon" id="telefon" placeholder="Telefon">
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
