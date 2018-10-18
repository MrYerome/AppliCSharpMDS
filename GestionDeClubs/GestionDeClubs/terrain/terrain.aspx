<%@ Page Title="Gestion Terrains" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="terrain.aspx.cs" Inherits="GestionDeClubs.terrain.terrain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Gestion des terrains</h1>
    <div>
        <h3>Ajouter un terrain</h3>
        
        <div>
            <span id="massageValidate"></span>
            <p>
                <asp:TextBox runat="server" ID="nameTerrain"    placeholder="Nome du terrain"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="requireName"
                    ControlToValidate="nameTerrain"
                    ErrorMessage="Le nom du terrain est obligatoire"
                    ForeColor="Red" ></asp:RequiredFieldValidator>
                
            </p>
            <p>
                <asp:TextBox runat="server" ID="addressTerrain" placeholder="Adresse du terrain"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="requireAddress"
                    ControlToValidate="addressTerrain"
                    ErrorMessage="L'adresse est obligatoire"
                    ForeColor="Red" ></asp:RequiredFieldValidator>
            </p>
                
            <asp:Button runat="server" ID="addTerrainButton" Text="Ajouter" OnClick="addTerrainButton_Click" />
        </div>
    </div>
    <hr />
    <div>
        <h3>Liste des terrains</h3>

    </div>
</asp:Content>
