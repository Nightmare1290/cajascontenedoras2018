<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="ImpresionCDEaCME.aspx.vb" Inherits="ImpresionCDEaCME" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <div class="captura">
       
      <div><asp:Label ID="Label1" runat="server" CssClass="subtitulo" Height="18px" >Entrega de Documentación y Material Electoral</asp:Label></div>
      <asp:Label ID="titulo" runat="server" CssClass="subtitulo">Impresión de Recibos</asp:Label>
      <asp:Label ID="Distrito" runat="server" CssClass="subtitulo" ></asp:Label>
      <div><hr /></div> 
          
        <div class="datosrep">
        <div id="CDEFor" >        
        <a href="Recibos/CDEaCME.pdf" download="CDEaCME">
        <asp:Image ID="CDEaCME" runat="server" Height="60px" ImageUrl="Imagenes/pdf.png" Width="60px"/><br />Recibo de Entrega de Consejos Distritales Electorales Fóraneos a  <br /> Consejos Municipal Electorales</a>
        </div><br /><br />
                    
        <div class="error"><asp:Label ID="Lblerror" runat="server"></asp:Label></div>
       
       </div>

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

