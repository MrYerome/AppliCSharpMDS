<%@ Page Title="Gestion Terrains" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="terrain.aspx.cs" Inherits="GestionDeClubs.terrain.terrain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Gestion des terrains</h1>
        <div class="row">
            <h3>Ajouter un terrain</h3>
            <div>
                <asp:TextBox runat="server" ID="addressTerrain" placeholder="Adresse du terrain"></asp:TextBox>
                <asp:Button runat="server" ID="addTerrain" Text="Ajouter" OnClick="addTerrain_Click" />
            </div>
        </div>
</asp:Content>
