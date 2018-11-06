<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="readClub.aspx.cs" Inherits="GestionDeClubs.readClub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
  <asp:GridView ID="GridViewClub" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped" DataKeyNames="id">
      <Columns>
          <asp:BoundField HeaderText="id" DataField="id" Visible="false" />
          <asp:BoundField HeaderText="Nom du club" DataField="nom" />
          <asp:BoundField HeaderText="Adresse" DataField="adresse" />
          <asp:BoundField HeaderText="Code postal" DataField="codePostal" />
          <asp:BoundField HeaderText="Ville" DataField="ville" />
          <asp:TemplateField HeaderText="Modifier">
              <ItemTemplate>
                    <asp:Button ID="editButton" Text="Modifier" runat="server" CssClass="btn btn-warning" OnClick="redirectToEdit"/>  
              </ItemTemplate>     
          </asp:TemplateField>
           <asp:TemplateField HeaderText="Supprimer">
              <ItemTemplate>
                    <asp:Button ID="deleteButton" Text="X" runat="server" CssClass="btn btn-danger"/>  
              </ItemTemplate>     
          </asp:TemplateField>
      </Columns>
  </asp:GridView>
</asp:Content>
