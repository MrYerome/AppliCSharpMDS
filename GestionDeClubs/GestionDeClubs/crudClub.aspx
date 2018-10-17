<%@ Page Title="Ajouter un club" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crudClub.aspx.cs" Inherits="GestionDeClubs.crudClub" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Ajouter un club</h3>
    <div class="form-group">
        <asp:Label runat="server">Nom du club :</asp:Label>
        <asp:TextBox ID="clubName" runat="server" CssClass="form-control input-lg"></asp:TextBox>
    </div>
    
    <div class="form-group">
        <asp:Label runat="server">Adresse :</asp:Label>
        <asp:TextBox id="clubAddress" runat="server" CssClass="form-control input-lg"></asp:TextBox>
    </div>
    
    <div class="form-group">
        <asp:Label runat="server">Code postal :</asp:Label>
        <asp:TextBox id="clubZipcode" runat="server" CssClass="form-control input-lg"></asp:TextBox>
    </div>
    
    <div class="form-group">
        <asp:Label runat="server">Ville :</asp:Label>
        <asp:TextBox id="clubCity" runat="server" CssClass="form-control input-lg"></asp:TextBox>
    </div>
    

    <asp:Button runat="server" ID="submitFormAddClub" Text="Ajouter un club" onclick="addClub" CssClass="btn btn-success"/>
</asp:Content>


