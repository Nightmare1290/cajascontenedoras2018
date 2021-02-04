<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="ReportesCMEaMDC.aspx.vb" Inherits="ReportesCMEaMDC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
            <asp:RadioButtonList ID="RBTLGrafMunicip" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" 
                                CellSpacing="7" CssClass="radiobtn" AutoPostBack="True" Width="497px" >
                                <asp:ListItem Text="Excel" Value="0" Selected="True" ></asp:ListItem>
                                <asp:ListItem Text="PDF" Value="1"></asp:ListItem>
             </asp:RadioButtonList> 

            <div><hr /></div>
             <asp:Button ID="btnR1" runat="server" Text="Reporte CME - MDC" Height="45px" Width="291px"  />   
              <div><hr /></div> 
             <asp:Button ID="btnR2" runat="server" Text="Grafica CME - MDC" Height="45px" Width="291px"  />
        </div>
          
        <div class="error"><asp:Label ID="Lblerror" runat="server"></asp:Label></div>
       
       </div>

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

