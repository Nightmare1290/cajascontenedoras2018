<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="ReportesDOE.aspx.vb" Inherits="ReportesDOE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .radiobtn {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <div class="captura">
       
      <div><asp:Label ID="Label1" runat="server" CssClass="subtitulo" >Entrega de las Cajas Contenedoras de Documentación y Material Electoral</asp:Label></div>
      <asp:Label ID="titulo" runat="server" CssClass="subtitulo">DIRECCIÓN DE ORGANIZACIÓN ELECTORAL</asp:Label>
      <asp:Label ID="Distrito" runat="server" CssClass="subtitulo" ></asp:Label>
      <div><hr /></div> 
          
        <div class="datosrep">
        <div></div>
        
            <asp:RadioButtonList ID="RBTLGrafMunicip" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" 
                                CellSpacing="7" CssClass="radiobtn" AutoPostBack="True" Width="497px" >
                                <asp:ListItem Text="Excel" Value="0" Selected="True" ></asp:ListItem>
                                <asp:ListItem Text="PDF" Value="1"></asp:ListItem>
             </asp:RadioButtonList> 
            <div><hr /></div> 
            <div class="boton"> <asp:Button ID="btnR1" runat="server" Text="Reporte IEE - CDE FÓRANEOS"  Height="45px" Width="291px"  /> </div>
            <div class="boton"> <asp:Button ID="btnR2" runat="server" Text="Reporte IEE - CME PUEBLA"  Height="45px" Width="291px"  /> </div> 
            <div class="boton"> <asp:Button ID="btnR3" runat="server" Text="Reporte IEE - BOLETAS CME"  Height="45px" Width="291px"  /> </div>
            <div class="boton"> <asp:Button ID="btnR4" runat="server" Text="Grafica IEE - CDE FÓRANEOS"  Height="45px" Width="291px"  /> </div> 
            <div class="boton"> <asp:Button ID="btnR5" runat="server" Text="Grafica IEE - CME PUEBLA"  Height="45px" Width="291px"  /> </div>
            <div class="boton"> <asp:Button ID="btnR6" runat="server" Text="GRAFICA GLOBAL"  Height="45px" Width="291px"  /> </div>
                      
        <div class="error"><asp:Label ID="Lblerror" runat="server"></asp:Label></div>
       
       </div>

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

