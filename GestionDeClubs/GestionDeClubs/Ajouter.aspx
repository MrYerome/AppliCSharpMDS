<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ajouter.aspx.cs" Inherits="GestionDeClubs.Contact" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Ajouter un utilisateur</h3>
    <asp:TextBox ID="identifiant" runat="server" Text="Votre identifiant"></asp:TextBox>
        <asp:TextBox ID="password" runat="server" Text="Votre mot de passe"></asp:TextBox>
    <asp:DropDownList ID="DDLClubs" runat="server">

</asp:DropDownList>
    <asp:Button runat="server" ID="submitForm" Text="Valider" onclick="ValidateUser"/>
    


</asp:Content>