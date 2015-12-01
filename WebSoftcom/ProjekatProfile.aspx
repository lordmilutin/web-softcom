<%@ Page Title="Profil Projekta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjekatProfile.aspx.cs" Inherits="WebSoftcom.ProjekatProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <% if (displayError) { %>
    <div class="alert alert-dismissable alert-danger">
      <strong><asp:Panel runat="server" ID="error"></asp:Panel></strong>
    </div>
    <% } %>
    <div class="col-md-4 col-md-offset-1">
        <h1><%: projekat.ime %></h1>
        <h3><i>(<%:projekat.izrada %>)</i></h3>
    </div>
    <div class="col-md-4 col-md-offset-2">
        
         <a href="/IzmeniProjekat?pid=<%: projekat.PID %>"><button type="button" class="btn btn-info">Izmeni</button></a>
         <a href="/ObrisiProjekat?pid=<%: projekat.PID %>"><button type="button" class="btn btn-danger">Obriši</button></a>

    <%if (projekat.izrada == "insource") { %>
    
        <h2>Vođa projekta: <%: projekat.trenutniLeader.sef.ime + " " + projekat.trenutniLeader.sef.prezime %></h2>
        <i>(<%: projekat.trenutniLeader.vodiOd.ToString().Remove(10) + " - " + projekat.trenutniLeader.vodiDo.ToString().Remove(10) %>)</i>
        <h3>Rok za izradu: <br/>[ <%: projekat.datumPocetka.ToString().Remove(10) + " - " + projekat.datumZavrsetka.ToString().Remove(10) %> ]</h3>

    <% } else if (projekat.izrada == "outsource") { %>
    
        <h2>Izrada za firmu: <%: projekat.nazivFirme %></h2>
        <h3>Rok za izradu: <br/>[ <%: projekat.datumPocetka.ToString().Remove(10) + " - " + projekat.datumZavrsetka.ToString().Remove(10) %> ]</h3>
    
    <% } %>
    </div>
    <div class="clearfix"></div> 
    <br /><br />

    <div class="col-md-5 col-md-offset-1">
        <h4>Spisak svih zaposlenih koji rade na projektu</h4>
       <table class="table table-striped table-hover ">
          <thead>
            <tr>
              <th>#</th>
              <th>Ime</th>
              <th>Prezime</th>
              <th>Ukloni</th>
            </tr>
          </thead>
          <tbody>
              <% 
                  int i = 1;
                  foreach(var zap in projekat.radnici){ %>
                    <tr>
                        <td><%:i++ %></td>
                        <td><a href="/ZaposleniProfile?zid=<%:zap.radnik.ZID %>"><%:zap.radnik.ime %></a></td>
                        <td><a href="/ZaposleniProfile?zid=<%:zap.radnik.ZID %>"><%:zap.radnik.prezime %></a></td>
                        <td><a href="/RadnikProjekat?pid=<%:projekat.PID +"&zid=" + zap.radnik.ZID + "&a=del" %>"><button type="button" class="btn btn-danger">Ukloni</button></a></td>
                    </tr>
              <% } %>
              
          </tbody>
        </table> 
    </div>

    <div class="col-md-5 col-md-offset-1">
        <h4>Dodaj zaposlenog na projekat</h4>
       <table class="table table-striped table-hover ">
          <thead>
            <tr>
              <th>#</th>
              <th>Ime</th>
              <th>Prezime</th>
              <th>Dodaj</th>
            </tr>
          </thead>
          <tbody>
              <% 
                  i = 1;
                  foreach(var zap in neradnici){ %>
                    <tr>
                        <td><%:i++ %></td>
                        <td><a href="/ZaposleniProfile?zid=<%:zap.ZID %>"><%:zap.ime %></a></td>
                        <td><a href="/ZaposleniProfile?zid=<%:zap.ZID %>"><%:zap.prezime %></a></td>
                        <td><a href="/RadnikProjekat?pid=<%:projekat.PID +"&zid=" + zap.ZID + "&a=add" %>"><button type="button" class="btn btn-success">Dodaj</button></a></td>
                    </tr>
              <% } %>
              
          </tbody>
        </table> 
    </div>
</asp:Content>
