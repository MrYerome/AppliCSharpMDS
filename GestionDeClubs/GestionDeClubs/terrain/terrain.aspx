<%@ Page Title="Gestion Terrains" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="terrain.aspx.cs" Inherits="GestionDeClubs.terrain.terrain" EnableEventValidation = "false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Les terrains du club</h1>
    
    <div runat="server" id="gestionTerrain" style="display:none">
    
        <h3>Ajouter un terrain</h3>
        
        <div runat="server" id="ContainerMessageValidate" class="hide" role="alert">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <span runat="server" id="messageValidate"></span>
        </div>
        
        <div>
            
                <asp:HiddenField runat="server" ID="idTerrain" ClientIDMode="Static"/>
                
                <asp:TextBox runat="server" ID="nameTerrain" AutoCompleteType="Disabled" placeholder="Nom du terrain" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="requireName"
                    ControlToValidate="nameTerrain"
                    ErrorMessage="Le nom du terrain est obligatoire"
                    ForeColor="Red" 
                    ValidationGroup="TerrainForm"></asp:RequiredFieldValidator>

                <asp:TextBox runat="server" ID="addressTerrain" AutoCompleteType="Disabled" placeholder="Adresse du terrain" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="requireAddress"
                    ControlToValidate="addressTerrain"
                    ErrorMessage="L'adresse est obligatoire"
                    ForeColor="Red" 
                    ValidationGroup="TerrainForm"></asp:RequiredFieldValidator>
            <div>

                <%if (gridViewTerrain.SelectedRow == null)
                    { %> 
                <asp:Button runat="server" ID="addTerrainButton" Text="Ajouter" OnClick="addTerrainButton_Click" ValidationGroup="TerrainForm" CssClass="btn btn-primary"/>
                <%}
                else
                { %>
                <asp:Button runat="server" ID="modifTerrainButton" Text="Modifier" OnClick="modifTerrainButton_Click" ValidationGroup="TerrainForm" CssClass="btn btn-primary"/>
                <asp:Button runat="server" ID="suppTerrainButton" Text="Supprimer" OnClick="suppTerrainButton_Click" ValidationGroup="TerrainForm" CssClass="btn btn-primary"/>
                <%} %>
           
            </div>
        </div>
        <hr />
    </div>
    
    <div>
        <h3>Liste des terrains</h3>
        <asp:GridView ID="gridViewTerrain" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" 
            OnSelectedIndexChanged="gridViewTerrain_SelectedIndexChanged"
            OnRowDataBound="gridViewTerrain_RowDataBound"
            DataKeyNames="id">

             <Columns>
                <asp:BoundField HeaderText="Nom" DataField="nom" />
                <asp:BoundField HeaderText="Adresse" DataField="adresse" />
                 
             </Columns>
         </asp:GridView>
    </div>
</asp:Content>
