<%@ Page Title="Radnik - Projekat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RadnikProjekat.aspx.cs" Inherits="WebSoftcom.RadnikProjekat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <% if (displayError) { %>
    <div class="alert alert-dismissable alert-danger">
      <strong><asp:Panel runat="server" ID="error"></asp:Panel></strong>
    </div>
    <% } %>
</asp:Content>
