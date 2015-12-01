<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSoftcom._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Softcom - Web solution</h1>
        <p class="lead">Softcom web solution predstavlja Web verziju windows aplikacije "Softcom" koju su razvili studenti:
            <ul>
                <li>Stanković Milutin [14161]</li>
                <li>Mario Žalac [14232]</li>
            </ul>    
            za projekat is predmeta "Sistemi Baza Podataka".
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Projekti</h2>
            <p>
                U odeljku "Projekti" u glavnom meniju možete naći sve projekte kao i u "Softcom" aplikaciji. Sa ove strane možete vrlo lako
                i pregledno da upravljate svim projektima.
            </p>
        </div>
        <div class="col-md-4">
            <h2>Zaposleni</h2>
            <p>
               U odeljku "Zaposleni" u glavnom meniju možete naći sve podatke o zaposlenima firme i vrlo lako možete ažurirati sve podatke zaposlenih.
            </p>
        </div>
        <div class="col-md-4">
            <h2>Saradnici</h2>
            <p>
                U odeljku "Saradnici" su svi podaci vezani za sve saradnike firme, kao i o programerima koji su ih angažovali.
            </p>
        </div>
    </div>

</asp:Content>
