<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ObrisiSaradnika.aspx.cs" Inherits="WebSoftcom.ObrisiSaradnika" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2><%: Title %></h2>
    <% if (displayError) { %>
    <div class="alert alert-dismissable alert-danger">
      <strong><asp:Panel runat="server" ID="error"></asp:Panel></strong>
    </div>
     <%} %>
</asp:Content>
