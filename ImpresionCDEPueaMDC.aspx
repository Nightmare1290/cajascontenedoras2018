<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="ImpresionCDEPueaMDC.aspx.vb" Inherits="ImpresionCDEPueaMDC" %>

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
        <a href="Recibos/CDEPueaMDC.pdf" download="CDEPueaMDC">
        <asp:Image ID="CDEPueaMDC" runat="server" Height="60px" ImageUrl="Imagenes/pdf.png" Width="60px"/><br />Recibo de Entrega de Consejo Distrital Electoral Puebla a<br /> Mesas Directivas de Casillas </a>
        </div><br /><br />
        <div id="CMEPue" >
        <a href="Recibos/CDEPueaMDCESP.pdf" download="CDEPueaMDCESP">
        <asp:Image ID="CDEPueaMDCESP" runat="server" Height="60px" ImageUrl="Imagenes/pdf.png" Width="60px"/><br />Recibo de Entrega de Consejo Distrital Electoral Pueblaa<br /> Mesas Directivas de Casilla Especial </a>
        </div><br /><br />         
        <div class="error"><asp:Label ID="Lblerror" runat="server"></asp:Label></div>
       
       </div>

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

