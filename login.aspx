<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeFile="login.aspx.vb" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
    <div class="login">
        <asp:Label ID="Label1" runat="server" Text="USUARIO"></asp:Label><asp:TextBox ID="TxtUser" runat="server" AutoCompleteType="Disabled" ></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="CONTRASEÑA" ></asp:Label><asp:TextBox ID="TxtPassword" TextMode="password" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
        <asp:Button ID="BtnEntrar" runat="server" Text="Entrar" ForeColor="Black" />
        <br /><br />
        <div class="error"><asp:Label ID="Lblerror" runat="server"></asp:Label></div>
        
    </div>
         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>