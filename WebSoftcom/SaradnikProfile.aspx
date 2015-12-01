<%@ Page Title="Profil Saradnika" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SaradnikProfile.aspx.cs" Inherits="WebSoftcom.SaradnikProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
     <% if (displayError) { %>
    <div class="alert alert-dismissable alert-danger">
      <strong><asp:Panel runat="server" ID="error"></asp:Panel></strong>
    </div>
    <%} %>
    <div class="col-md-10 col-md-offset-1">
        <div class="col-md-5">
            <h1><%: saradnik.ime + " " + saradnik.prezime %></h1>
        </div>
        
        <div class="col-md-4 col-md-offset-2">
            <a href="/IzmeniSaradnika?sid=<%: saradnik.SID %>"><button type="button" class="btn btn-info">Izmeni</button></a>
            <a href="/ObrisiSaradnika?sid=<%: saradnik.SID %>"><button type="button" class="btn btn-danger">Obriši</button></a>
        </div>
        <br /> <br /> <br />
        <div class="col-md-4 col-md-offset-2 well">
            <h4>Telefon: <%: saradnik.telefon %></h4>
            <h4>Angažovao ga: <a href="/ZaposleniProfile?zid=<%: saradnik.nadredjeni.ZID%>"><%: saradnik.nadredjeni.ime + " " + saradnik.nadredjeni.prezime %></a></h4>
        </div>
    </div>
</asp:Content>
