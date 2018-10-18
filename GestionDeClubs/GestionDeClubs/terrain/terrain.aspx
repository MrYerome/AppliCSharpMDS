<%@ Page Title="Gestion Terrains" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="terrain.aspx.cs" Inherits="GestionDeClubs.terrain.terrain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Gestion des terrains</h1>
    <div>
        <h3>Ajouter un terrain</h3>
        <div runat="server" id="messageValidate" class="hidden"></div>
        <div>
            
            <p>
                <asp:TextBox runat="server" ID="nameTerrain"    placeholder="Nom du terrain"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="requireName"
                    ControlToValidate="nameTerrain"
                    ErrorMessage="Le nom du terrain est obligatoire"
                    ForeColor="Red" 
                    ValidationGroup="addTerrainForm"></asp:RequiredFieldValidator>
                
            </p>
            <p>
                <asp:TextBox runat="server" ID="addressTerrain" placeholder="Adresse du terrain"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="requireAddress"
                    ControlToValidate="addressTerrain"
                    ErrorMessage="L'adresse est obligatoire"
                    ForeColor="Red" 
                    ValidationGroup="addTerrainForm"></asp:RequiredFieldValidator>
            </p>
                
            <asp:Button runat="server" ID="addTerrainButton" Text="Ajouter" OnClick="addTerrainButton_Click" ValidationGroup="addTerrainForm"/>
        </div>
    </div>
    <hr />
    <div>
        <h3>Liste des terrains</h3>
        <asp:GridView ID="gridViewTerrain" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped" 
            OnRowEditing="gridViewTerrain_RowEditing"
            OnRowCancelingEdit="gridViewTerrain_RowCancelingEdit"
            OnRowUpdating="gridViewTerrain_RowUpdating"
            DataKeyNames="id">
             <Columns>
                <asp:BoundField HeaderText="Nom" DataField="nom" />
                <asp:BoundField HeaderText="Adresse" DataField="adresse" />
                <asp:CommandField ShowEditButton="true" /> 
                
                 
                 
             </Columns>
         </asp:GridView>
    </div>
</asp:Content>
