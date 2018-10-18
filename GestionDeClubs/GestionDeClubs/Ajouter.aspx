<%@ Page Title="Ajouter un utilisateur" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ajouter.aspx.cs" Inherits="GestionDeClubs.Contact" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Label runat="server">Votre nom : </asp:Label>
    <asp:TextBox ID="identifiant" runat="server" Text="Votre identifiant"></asp:TextBox>
            <asp:Label runat="server">Votre nom : </asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Text="Votre identifiant"></asp:TextBox>    
    <asp:Label runat="server">Votre nom : </asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Text="Votre identifiant"></asp:TextBox>
        <asp:TextBox ID="password" runat="server" Text="Votre mot de passe"></asp:TextBox>
    <asp:DropDownList ID="DDLClubs" runat="server">

</asp:DropDownList>
    <asp:Button runat="server" ID="submitForm" Text="Valider" onclick="ValidateUser"/>
    


</asp:Content>


