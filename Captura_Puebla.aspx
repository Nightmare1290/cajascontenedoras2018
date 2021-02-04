<%@ Page Title="" Language="VB" MasterPageFile="~/menu.master" AutoEventWireup="false" CodeFile="Captura_Puebla.aspx.vb" Inherits="Captura_Puebla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Scripts/utiles.js" type="text/javascript"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <div class="captura">
       
      <div><asp:Label ID="Label1" runat="server" CssClass="subtitulo" >Entrega de Documentación y Material Electoral</asp:Label></div>
      <asp:Label ID="titulo" runat="server" CssClass="subtitulo">DIRECCIÓN DE ORGANIZACIÓN ELECTORAL</asp:Label>
       <div><hr /></div> 
          
        <div class="datos">
                <div><asp:label id="Label16" runat="server" CssClass="Etiqueta">Distrito:</asp:label><asp:DropDownList ID="dtto" runat="server" CssClass="Etiquetatexto" AutoPostBack="true"></asp:DropDownList></div>
                <br />    
                <br />    
                <div class="centrardiv">
                    <asp:button id="editar" runat="server" Text="Editar"></asp:button>&nbsp;
                    <asp:button id="guardar" runat="server" Text="Guardar"></asp:button>&nbsp;
                    <asp:button id="cancelar" runat="server" Text="Cancelar"></asp:button>
                </div>
            
                <br />  
                <div><asp:label id="Label17" runat="server" CssClass="Etiqueta">FECHA ENTREGA:</asp:label><asp:textbox id="Fecha" runat="server" CssClass="youpi" ></asp:textbox></div>
                <div>    
                <br />
                <div><asp:Label ID="Label4" runat="server" CssClass="Etiqueta" >HORA DE ENTREGA:</asp:Label>
                  <div class="horas">
                    <asp:DropDownList ID="ehora" runat="server">
                        <%--<asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>--%>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="emin" runat="server">
                        <%--<asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                        <asp:ListItem>32</asp:ListItem>
                        <asp:ListItem>33</asp:ListItem>
                        <asp:ListItem>34</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>37</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>39</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>41</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>43</asp:ListItem>
                        <asp:ListItem>44</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>46</asp:ListItem>
                        <asp:ListItem>47</asp:ListItem>
                        <asp:ListItem>48</asp:ListItem>
                        <asp:ListItem>49</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>51</asp:ListItem>
                        <asp:ListItem>52</asp:ListItem>
                        <asp:ListItem>53</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                        <asp:ListItem>56</asp:ListItem>
                        <asp:ListItem>57</asp:ListItem>
                        <asp:ListItem>58</asp:ListItem>
                        <asp:ListItem>59</asp:ListItem>--%>
                        </asp:DropDownList>
                        </div>
                        </div>
                        </div>
                       

                <div><asp:Label ID="Label6" runat="server" CssClass="subtitulo">ENTREGÓ</asp:Label></div>
                <div><asp:label id="Label18" runat="server" CssClass="Etiqueta">NOMBRE:</asp:label><asp:textbox id="NombreE" runat="server" CssClass="Etiquetatexto" MaxLength="200" ></asp:textbox></div>
                <div><asp:label id="Label10" runat="server" CssClass="Etiqueta">CARGO</asp:label><asp:textbox id="CargoE" runat="server" CssClass="Etiquetatexto" ></asp:textbox></div>
                <div><asp:Label ID="Label5" runat="server" CssClass="subtitulo">RECIBIÓ</asp:Label></div>
                <div><hr /></div> 
                <div><asp:label id="Label2" runat="server" CssClass="Etiqueta">NOMBRE:</asp:label><asp:textbox id="NombreR" runat="server" CssClass="Etiquetatexto" ></asp:textbox></div>
                <div><asp:label id="Label3" runat="server" CssClass="Etiqueta">CARGO</asp:label><asp:textbox id="CargoR" runat="server" CssClass="Etiquetatexto" ></asp:textbox></div>
                </div>

        <div class="error"><asp:Label ID="Lblerror" runat="server"></asp:Label></div>
       
       </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>