<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listUsers.aspx.cs" Inherits="GestionDeClubs.UsersPage.listUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped">
        <Columns>
            <asp:BoundField HeaderText="Nom" DataField="nom" />
            <asp:BoundField HeaderText="Prénom" DataField="prenom" />
            <asp:BoundField HeaderText="email" DataField="email" />
            <asp:BoundField HeaderText="poste" DataField="poste" />

            <asp:TemplateField HeaderText="Modifier">
                <ItemTemplate>
                    <asp:Button name='<%# Eval("id") %>' Text='<%# "modifier " + Eval("nom") %>' runat="server" CssClass="btn btn-info" value='<%# Eval("id") %>' CommandArgument='<%# Eval("id") %>' OnClick="updateUser"/>
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Supprimer">
                <ItemTemplate>
                    <asp:Button name='<%# "test" + Eval("id") %>' Text='<%# "supprimer " + Eval("nom") %>' runat="server" CssClass="btn btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>




</asp:Content>
