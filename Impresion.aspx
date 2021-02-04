<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="Impresion.aspx.vb" Inherits="Impresion" %>

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
        <a href="Recibos/IEEaCDEForaneos.pdf" download="IEEaCDEForaneos">
        <asp:Image ID="IEEaCDEForaneos" runat="server" Height="60px" ImageUrl="Imagenes/pdf.png" Width="60px"/><br />Recibo de Entrega de IEE a  <br /> Consejos Distritales Electorales Fóraneos </a>
        </div><br /><br />
        <div id="CMEPue" >
        <a href="Recibos/IEEaCMEPuebla.pdf" download="IEEaCMEPuebla">
        <asp:Image ID="IEEaCMEPuebla" runat="server" Height="60px" ImageUrl="Imagenes/pdf.png" Width="60px"/><br />Recibo de Entrega de IEE a <br /> Consejo Municipal Electoral Puebla </a>
        </div><br /><br />
        <div id="boletas">
        <a href="Recibos/IEEaboletasCME.pdf" download="IEEaboletasCME">
        <asp:Image ID="IEEaboletasCME" runat="server" Height="60px" ImageUrl="Imagenes/pdf.png" Width="60px"/><br />Recibo de Entrega de Boletas Electorales IEE a <br /> Consejos Municipales Electorales </a>
        </div>              
        <div class="error"><asp:Label ID="Lblerror" runat="server"></asp:Label></div>
       
       </div>

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

