<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ajouter.aspx.cs" Inherits="GestionDeClubs.Contact" %>
 


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Ajouter un utilisateur</h3>
<asp:Login ID = "Login1" runat = "server" OnAuthenticate= "ValidateUser"></asp:Login>

   
</asp:Content>


