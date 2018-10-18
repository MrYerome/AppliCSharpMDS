<%@ Page Title="Ajouter un utilisateur" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ajouter.aspx.cs" Inherits="GestionDeClubs.Contact" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Label runat="server">Votre nom : </asp:Label>
        <asp:TextBox ID="name" runat="server">
        </asp:TextBox>
    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="name"
  ErrorMessage="Veuillez renseigner votre nom"
  ForeColor="Red">
</asp:RequiredFieldValidator>

    <asp:Label runat="server">Votre prénom : </asp:Label>
    <asp:TextBox ID="surname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
  ControlToValidate="surname"
  ErrorMessage="Veuillez renseigner votre prénom"
  ForeColor="Red">
</asp:RequiredFieldValidator>

        <asp:Label runat="server">Votre identifiant : </asp:Label>
    <asp:TextBox ID="identifiant" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
  ControlToValidate="identifiant"
  ErrorMessage="Veuillez renseigner votre identifiant"
  ForeColor="Red">
</asp:RequiredFieldValidator>
            <asp:Label runat="server">Votre mot de passe : </asp:Label>
    <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
  ControlToValidate="password"
  ErrorMessage="Veuillez renseigner votre identifiant"
  ForeColor="Red">
</asp:RequiredFieldValidator>

    <asp:DropDownList ID="DDLClubs" runat="server">
    </asp:DropDownList>
    <asp:Button runat="server" ID="submitForm" Text="Valider" OnClick="ValidateUser" />



</asp:Content>


