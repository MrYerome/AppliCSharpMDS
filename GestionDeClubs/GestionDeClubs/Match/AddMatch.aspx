<%@ Page Title="Match" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMatch.aspx.cs" Inherits="GestionDeClubs.Match" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Ajouter un match</h3>

    <asp:TextBox ID="datematch" runat="server" TextMode="Date"></asp:TextBox>
 
    <asp:RequiredFieldValidator id="RequiredFieldValidatorDateMatch" runat="server"
      ControlToValidate="datematch"
      ErrorMessage="Veuillez rentrez la date du match."
      ForeColor="Red">
    </asp:RequiredFieldValidator>
       <br />
    <asp:TextBox ID="heurematch" runat="server" TextMode="Time"></asp:TextBox>

    <asp:RequiredFieldValidator id="RequiredFieldValidatorHeureMatch" runat="server"
      ControlToValidate="heurematch"
      ErrorMessage="Veuillez rentrez l'heure du match."
      ForeColor="Red">
    </asp:RequiredFieldValidator>
    <br />
    <asp:Button runat="server" ID="submitForm" Text="Valider" onclick="ValidateMatch"/>
    
</asp:Content>