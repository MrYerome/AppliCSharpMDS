<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEntrainement.aspx.cs" Inherits="GestionDeClubs.EntrainementPage.AddEntrainement" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h2><%: Title %></h2>
    <h3>Ajouter un entrainement</h3>

            <label>Type d'entrainement :</label>
            <asp:TextBox ID="typeentrainement" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
          ControlToValidate="typeentrainement"
          ErrorMessage="Veuillez rentrez le type de l'entrainement."
          ForeColor="Red">
        </asp:RequiredFieldValidator>

       <br />

    <label>Date de l'entrainement :</label>
     <asp:TextBox ID="dateentrainement" runat="server" TextMode="Date"></asp:TextBox>

      <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
      ControlToValidate="dateentrainement"
      ErrorMessage="Veuillez rentrez la date de l'entrainement."
      ForeColor="Red">
    </asp:RequiredFieldValidator>

       <br />

    <label>Heure de l'entrainement :</label>
    <asp:TextBox ID="heureentrainement" runat="server" TextMode="Time"></asp:TextBox>

    <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
      ControlToValidate="heureentrainement"
      ErrorMessage="Veuillez rentrez l'heure de l'entrainement."
      ForeColor="Red">
    </asp:RequiredFieldValidator>
    <br />
    <asp:Button runat="server" ID="Button1" Text="Valider" onclick="ValidateEntrainement"/>
</asp:Content>