<%@ Page Title="Ajouter un utilisateur" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ajouter.aspx.cs" Inherits="GestionDeClubs.UsersPage.Ajouter" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       

    <h2><%: Title %>.</h2>
    <asp:Label runat="server">Votre nom : </asp:Label>
    <asp:TextBox ID="name" runat="server">
    </asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
        ControlToValidate="name"
        ErrorMessage="Veuillez renseigner votre nom"
        ForeColor="Red">
    </asp:RequiredFieldValidator><br />

    <asp:Label runat="server">Votre prénom : </asp:Label>
    <asp:TextBox ID="surname" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
        ControlToValidate="surname"
        ErrorMessage="Veuillez renseigner votre prénom"
        ForeColor="Red">
    </asp:RequiredFieldValidator><br />

        <asp:Label runat="server">Votre mail : </asp:Label>
    <asp:TextBox textmode="Email" ID="email" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
        ControlToValidate="email"
        ErrorMessage="Veuillez renseigner votre mail"
        ForeColor="Red">
    </asp:RequiredFieldValidator><br />

            <asp:Label runat="server">Votre poste : </asp:Label>
    <asp:TextBox ID="poste" runat="server"></asp:TextBox>
<br />

    <asp:Label runat="server">Votre identifiant : </asp:Label>
    <asp:TextBox textmode="Password" ID="identifiant" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
        ControlToValidate="identifiant"
        ErrorMessage="Veuillez renseigner votre identifiant"
        ForeColor="Red">
    </asp:RequiredFieldValidator><br />

    <asp:Label runat="server">Votre mot de passe : </asp:Label>
    <asp:TextBox ID="password" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
        ControlToValidate="password"
        ErrorMessage="Veuillez renseigner votre identifiant"
        ForeColor="Red">
    </asp:RequiredFieldValidator><br />
    
    <asp:Label runat="server">Votre club : </asp:Label>
    <asp:DropDownList ID="DDLClubs" runat="server">
    </asp:DropDownList><br />

        
    <asp:Button runat="server" ID="submitForm" Text="Valider" OnClick="ValidateUser" /><br />

<div runat="server" id="messageValidateOK" class="hidden">Le terrain ajouté avec succès</div>

</asp:Content>
