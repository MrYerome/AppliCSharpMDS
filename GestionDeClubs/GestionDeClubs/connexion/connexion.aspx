<%@ Page Title="Connexion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="connexion.aspx.cs" Inherits="GestionDeClubs.connexion.connexion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Connexion</h1>

    <asp:TextBox runat="server" ID="login" placeholder="Identifiant"></asp:TextBox>
    <asp:TextBox runat="server" TextMode="Password" ID="password" placeholder="Mot de passe"></asp:TextBox>
    <asp:Button runat="server" Text="Se connecter" ID="validateConnexion" OnClick="validateConnexion_Click"/>        
   

</asp:Content>
