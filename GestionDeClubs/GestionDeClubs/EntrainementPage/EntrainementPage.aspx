<%@ Page Title="Entrainement" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntrainementPage.aspx.cs" Inherits="GestionDeClubs.EntrainementPage.EntrainementPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Entrainement</h1>

    <div runat="server" id="gestionEntrainement">
        <h3>Gestion des entrainements</h3>

        <div runat="server" id="ContainerMessageValidate" class="hide" role="alert">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <span runat="server" id="messageValidate"></span>
        </div>

        <div>

            <p>
            <asp:TextBox TextMode="Date" ID="dateEntrainement" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                    ControlToValidate="DateEntrainement"
                    ErrorMessage="La date de l'entrainement est obligatoire"
                    ForeColor="Red" 
                    ValidationGroup="EntrainementForm"></asp:RequiredFieldValidator>

            <asp:TextBox TextMode="time" ID="heureEntrainement" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                    ControlToValidate="HeureEntrainement"
                    ErrorMessage="L'heure de l'entrainement est obligatoire"
                    ForeColor="Red" 
                    ValidationGroup="EntrainementForm"></asp:RequiredFieldValidator>

            <asp:TextBox Placeholder="Type d'entrainement" ID="typeEntrainement" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3"
                    ControlToValidate="typeEntrainement"
                    ErrorMessage="Le type de l'entrainement est obligatoire"
                    ForeColor="Red" 
                    ValidationGroup="EntrainementForm"></asp:RequiredFieldValidator>

            <asp:DropDownList ID="ListTerrainEntrainement" CssClass="form-control" runat="server" AppendDataBoundItems="true" DataTextField="nom" DataValueField="id" >
                <asp:ListItem Text="Selectioner un terrain..." Value="0" Selected="True"></asp:ListItem>
            </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4"
                    ControlToValidate="ListTerrainEntrainement"
                    InitialValue="0"
                    ErrorMessage="Le type de l'entrainement est obligatoire"
                    ForeColor="Red" 
                    ValidationGroup="EntrainementForm"></asp:RequiredFieldValidator>
            </p>
            

            <asp:Button runat="server" ID="addEntrainement" Text="Valider" OnClick="addEntrainement_Click" ValidationGroup="EntrainementForm" CssClass="btn btn-primary"/>
           
           
        </div>

        <hr />
    </div>
</asp:Content>