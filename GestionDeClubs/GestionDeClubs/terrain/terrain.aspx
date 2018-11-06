<%@ Page Title="Gestion Terrains" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="terrain.aspx.cs" Inherits="GestionDeClubs.terrain.terrain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Gestion des terrains</h1>
    <div>
        <h3>Ajouter un terrain</h3>
        <div runat="server" id="messageValidate" class="hide">
            <asp:Button runat="server" type="button" class="close" data-dismiss="alert" aria-label="Close">
                
            </asp:Button>

        </div>
        <div>
            
            <p>
                
                    
                <asp:HiddenField runat="server" ID="idTerrain" ClientIDMode="Static"/>
                
                <asp:TextBox runat="server" ID="nameTerrain"    placeholder="Nom du terrain"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="requireName"
                    ControlToValidate="nameTerrain"
                    ErrorMessage="Le nom du terrain est obligatoire"
                    ForeColor="Red" 
                    ValidationGroup="TerrainForm"></asp:RequiredFieldValidator>
                
            </p>
            <p>
                <asp:TextBox runat="server" ID="addressTerrain" placeholder="Adresse du terrain"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="requireAddress"
                    ControlToValidate="addressTerrain"
                    ErrorMessage="L'adresse est obligatoire"
                    ForeColor="Red" 
                    ValidationGroup="TerrainForm"></asp:RequiredFieldValidator>
            </p>
            <%if (selectedTerrain == null)
                { %> 
            <asp:Button runat="server" ID="addTerrainButton" Text="Ajouter" OnClick="addTerrainButton_Click" ValidationGroup="TerrainForm"/>
            <%}
            else
            { %>
            <asp:Button runat="server" ID="modifTerrainButton" Text="Modifier" OnClick="modifTerrainButton_Click" ValidationGroup="TerrainForm" />
            <asp:Button runat="server" ID="suppTerrainButton" Text="Supprimer" OnClick="suppTerrainButton_Click" ValidationGroup="TerrainForm" />
            <%} %>
        </div>
    </div>
    <hr />
    <div>
        <h3>Liste des terrains</h3>
        <asp:GridView ID="gridViewTerrain" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped" 
            OnSelectedIndexChanged="gridViewTerrain_SelectedIndexChanged"
            DataKeyNames="id">
             <Columns>
                <asp:BoundField HeaderText="Nom" DataField="nom" />
                <asp:BoundField HeaderText="Adresse" DataField="adresse" />
                <asp:CommandField ShowSelectButton="true" />
                
                 
                 
             </Columns>
         </asp:GridView>
    </div>
</asp:Content>
