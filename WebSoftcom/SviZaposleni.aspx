<%@ Page Title="Softcom - Zaposleni" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SviZaposleni.aspx.cs" Inherits="WebSoftcom.SviZaposleni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
     <% if (displayError) { %>
    <div class="alert alert-dismissable alert-danger">
      <strong><asp:Panel runat="server" ID="error"></asp:Panel></strong>
    </div>
    <%} %>
    <div class="col-md-10 col-md-offset-1">
        <asp:Panel runat="server" ID="panel"></asp:Panel>
    </div>
</asp:Content>
