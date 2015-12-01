<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SviProjekti.aspx.cs" Inherits="WebSoftcom.SviProjekti" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <% if (displayError) { %>
    <div class="alert alert-dismissable alert-danger">
      <strong><asp:Panel runat="server" ID="error"></asp:Panel></strong>
    </div>
    <%} %>
    <div class="col-md-10 col-md-offset-1">
        <h2>Insource projekti</h2>
        <asp:Panel runat="server" ID="insource"></asp:Panel>
        <h2>Outsource projekti</h2>
        <asp:Panel runat="server" ID="outsource"></asp:Panel>
    </div>
</asp:Content>