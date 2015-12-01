<%@ Page Title="Profil Zaposlenog" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ZaposleniProfile.aspx.cs" Inherits="WebSoftcom.ZaposleniProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2><%: Title %></h2>
    <% if (displayError) { %>
    <div class="alert alert-dismissable alert-danger">
      <strong><asp:Panel runat="server" ID="error"></asp:Panel></strong>
    </div>
    <%} %>
    <div class="col-md-10 col-md-offset-1">
        
        <div class="col-md-5">
            <h1><%: zaposleni.ime + " " + zaposleni.prezime %></h1>
            <h3 class="notopmargin"><i>(<%: zaposleni.pozicija %>)</i></h3>
        </div>
        
        <div class="col-md-4 col-md-offset-2">
            <a href="/IzmeniZaposlenog?zid=<%: zaposleni.ZID %>"><button type="button" class="btn btn-info">Izmeni</button></a>
            <a href="/ObrisiZaposlenog?zid=<%: zaposleni.ZID %>"><button type="button" class="btn btn-danger">Obriši</button></a>
        </div>

        <div class="clearfix"></div>
        <br /><br />

        <div class="col-md-6 well">
            <h3>Info:</h3>
            <h4>JMBG: <%: zaposleni.jmbg %></h4>
            <h4>Adresa: <%: zaposleni.adresa %></h4>
            <h4>Telefon: <%: zaposleni.telefon %></h4>
            <h4>Radi na: <% Response.Write(zaposleni.radiNa.Count+" "); if (zaposleni.radiNa.Count == 1) Response.Write("projektu"); else Response.Write("projekata"); %> </h4>
        </div>

        <div class="col-md-5 col-md-offset-1 well">
            <ul> <h3>Programski jezici:</h3> 
                <li><h4 class="notopmargin">C++ - <% if (zaposleni.F_CPP == 1) Response.Write("Da"); else Response.Write("Ne"); %> </h4></li>
                <li><h4 class="notopmargin">C# - <% if (zaposleni.F_CS == 1) Response.Write("Da"); else Response.Write("Ne"); %> </h4></li>
                <li><h4 class="notopmargin">PHP - <% if (zaposleni.F_PHP == 1) Response.Write("Da"); else Response.Write("Ne"); %> </h4></li>
                <li><h4 class="notopmargin">Java - <% if (zaposleni.F_Java == 1) Response.Write("Da"); else Response.Write("Ne"); %> </h4></li>
            </ul>
        </div>

        <div class="col-md-6 well">
            <table class="table table-striped table-hover ">
            <h3>Lista projekata</h3>
              <thead>
                <tr>
                  <th>#</th>
                  <th>Naziv projekta</th>
                  <th>Tip izrade</th>
                  <th>Datum početka</th>
                  <th>Datum završetka</th>
                </tr>
              </thead>
              <tbody>
                  <%  int i = 1;
                      foreach(var proj in zaposleni.radiNa) 
                      { 
                  %>
                <tr>
                  <td><% Response.Write(i++); %></td>
                  <td><a href="/ProjekatProfile?pid=<%: proj.projekat.PID %>"> <% Response.Write(proj.projekat.ime); %></a></td>
                  <td><a href="/ProjekatProfile?pid=<%: proj.projekat.PID %>"> <% Response.Write(proj.projekat.izrada); %></a></td>
                  <td><% Response.Write(proj.datum_pocetka.ToString().Remove(10)); %></td>
                  <td><% Response.Write(proj.datum_zavrsetka.ToString().Remove(10)); %></td>
                </tr>
                  <% } %>
              </tbody>
            </table> 
        </div>

        <div class="col-md-5 col-md-offset-1 well">
            <h3>Saradnici zaposlenog</h3>
            <table class="table table-striped table-hover ">
              <thead>
                <tr>
                  <th>#</th>
                  <th>Ime</th>
                  <th>Prezime</th>
                  <th>Telefon</th>
                </tr>
              </thead>
              <tbody>
                  <%  i = 1;
                      foreach(var sar in zaposleni.saradnici) 
                      { 
                  %>
                <tr>
                  <td><% Response.Write(i++); %></td>
                  <td><a href="/SaradnikProfile?sid=<%: sar.SID %>"> <% Response.Write(sar.ime); %> </a> </td>
                  <td><a href="/SaradnikProfile?sid=<%: sar.SID %>"> <% Response.Write(sar.prezime); %></a></td>
                  <td><% Response.Write(sar.telefon); %></td>
                </tr>
                  <% } %>
              </tbody>
            </table> 
        </div>
    </div>
</asp:Content>
