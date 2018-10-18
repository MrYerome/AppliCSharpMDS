<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="updateClub.aspx.cs" Inherits="GestionDeClubs.updateClub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
  <% 
      if (club != null)
      {
  %>
        <div class="form-group">
            <asp:Label runat="server">Nom du club :</asp:Label>
            <asp:TextBox ID="clubName" runat="server" CssClass="form-control input-lg"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server">Adresse du club :</asp:Label>
            <asp:TextBox ID="clubAddress" runat="server" CssClass="form-control input-lg"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server">Code postal du club :</asp:Label>
            <asp:TextBox ID="clubZipcode" runat="server" CssClass="form-control input-lg"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server">Ville du club :</asp:Label>
            <asp:TextBox ID="clubCity" runat="server" CssClass="form-control input-lg"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button runat="server" ID="submitFormAddClub" Text="Modifier un club" onclick="updateClubAction" CssClass="btn btn-success"/>
        </div>

  <%  }
      else
      {
  %>    <div class="alert alert-danger">Le club n'a pas ete trouve !</div>
  <%  } %>
</asp:Content>
