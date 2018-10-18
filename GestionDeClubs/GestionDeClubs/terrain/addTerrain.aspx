<%@ Page Title="Ajouter Terrain" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addTerrain.aspx.cs" Inherits="GestionDeClubs.terrain.addTerrain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Gestion des terrains</h1>
        <div class="row">
            <h3>Ajouter un terrain</h3>
            <div>
                <asp:TextBox runat="server" ID="addressTerrain" placeholder="Adresse du terrain"></asp:TextBox>
                <asp:DropDownList runat="server" ID="_dropDownListClub" ></asp:DropDownList>
            </div>
        </div>
</asp:Content>
