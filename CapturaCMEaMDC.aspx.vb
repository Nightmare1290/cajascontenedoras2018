Imports System.Net
Imports System.Data
Imports System.Data.SqlClient

Partial Class CapturaCMEaMDC
    Inherits System.Web.UI.Page
    Public con As conexion = New conexion
    Dim ehoramin As Integer
    Private Property m As String
    'Private Property h As String

    'TABLA USUARIO
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("aceptado") = "SI" Then
                casos.Text = Session("ultparte")
                dtto.Text = Session("id_dtto")
                municipio.Text = Session("mpio")
                CARGA_MPIO()
                guardar.Enabled = False
                cancelar.Enabled = False
                Controles_Activados(False)
                Carga_h()
                Carga_m()
            Else
                Response.Redirect("login.aspx")
            End If
        End If
    End Sub
    Private Sub Carga_h()
        Dim i As Integer
        ehora.Items.Clear()
        ehora.Items.Add("")    'Add("Seleccione...")
        For i = 1 To 24
            Dim lista As New ListItem()
            If i < 10 Then
                lista.Text = "0" & i     'Tabla dbo.distritos
            Else
                lista.Text = i     'Tabla dbo.distritos
            End If
            lista.Value = i
            ehora.Items.Add(lista)
        Next
        ehora.SelectedIndex = 0
    End Sub

    Private Sub Carga_m()
        Dim i As Integer
        emin.Items.Clear()
        emin.Items.Add("")    'Add("Seleccione...")
        For i = 0 To 59
            Dim lista As New ListItem()
            If i < 10 Then
                lista.Text = "0" & i     'Tabla dbo.distritos
            Else
                lista.Text = i     'Tabla dbo.distritos
            End If
            lista.Value = i
            emin.Items.Add(lista)
        Next
        emin.SelectedIndex = 0
    End Sub
    'TABLA MUNICIPIO
    Private Sub CARGA_MPIO()
        Dim DS2 As Data.DataTable
        Dim i As Integer
        Dim MySQL As String
        If municipio.Text = 0 Then
            MySQL = "SELECT * FROM municipios WHERE dtto=" & dtto.Text      'Tabla municipios
        Else
            MySQL = "SELECT * FROM municipios WHERE mpio=" & municipio.Text      'Tabla municipios
        End If


        DS2 = con.consulta(MySQL)
        Dim uf As Integer = DS2.Rows.Count
        Mpio.Items.Clear()    'Tabla municipios
        If uf > 0 Then
            Mpio.Items.Add("")    'Add("Seleccione...")    'Tabla municipios
            For i = 0 To uf - 1
                Dim dr As Data.DataRow = DS2.Rows(i)
                Dim lista As New ListItem()
                lista.Text = dr("municipio")      'Tabla municipios
                lista.Value = dr("mpio")          'Tabla municipios
                Mpio.Items.Add(lista)
            Next
            Mpio.SelectedIndex = 0                'Tabla municipios
        End If
        If Mpio.SelectedItem.Text <> "" Then
            busca(Mpio.SelectedItem.Value)        '
            SECCIONES()
        End If
    End Sub
    'TABLA SECCIONES Y CASILLAS
    Public Sub SECCIONES()
        Dim DS2 As Data.DataTable
        Dim i As Integer
        Dim MySQL As String

        If municipio.Text = 0 Then
            MySQL = "select distinct seccion from Casillas_MPIO where  mpio='" + Mpio.SelectedValue.ToString + "' and id_dtto='" & dtto.Text & "' order by seccion"
        ElseIf municipio.Text = 155 Then
            MySQL = "select distinct seccion from Casillas_MPIO where  MUNICIPIO='TEHUACAN'"
        Else
            MySQL = "select distinct seccion from Casillas_MPIO where  mpio='" + Mpio.SelectedValue.ToString + "' order by seccion"
        End If

        'Tabla Casilla y Tabla municipios
        DS2 = con.consulta(MySQL)
        Dim uf As Integer = DS2.Rows.Count
        Secc.Items.Clear()             '????
        If uf = 0 Then
            Exit Sub
        Else
            For i = 0 To uf - 1
                Dim dr As DataRow = DS2.Rows(i)
                Dim lista As New ListItem()
                lista.Text = dr("seccion")
                lista.Value = dr("seccion")
                Secc.Items.Add(lista)
            Next
            Secc.SelectedIndex = 0                     'Tabla Seccion
        End If
        If Secc.SelectedItem.Text <> "" Then
            casillas()
        End If
    End Sub
    Private Sub casillas()
        Dim DS2 As Data.DataTable
        Dim i As Integer
        Dim MySQL As String = "SELECT id,tipoCasilla FROM Casillas_MPIO WHERE seccion = '" + Secc.SelectedItem.Value + "'"
        DS2 = con.consulta(MySQL)
        Dim uf As Integer = DS2.Rows.Count
        Cas.Items.Clear()
        If uf = 0 Then
            Exit Sub
        Else
            For i = 0 To uf - 1
                Dim dr As DataRow = DS2.Rows(i)
                Dim lista As New ListItem()
                lista.Text = dr("tipoCasilla")
                lista.Value = dr("id")
                Cas.Items.Add(lista)
            Next
            Cas.SelectedIndex = 0

        End If
        If Cas.SelectedItem.Text <> "" Then
            busca(Cas.SelectedItem.Value)
        End If
    End Sub
    'TABLA CASILLAS
    Private Sub busca(ByRef id As String)
        Dim DS2 As Data.DataTable
        Dim i As Integer
        Dim MySQL As String = "SELECT * FROM CASILLAS WHERE id=" & id      'Tabla CASILLAS
        DS2 = con.consulta(MySQL)
        Dim uf As Integer = DS2.Rows.Count
        limpia()

        If uf = 0 Then      'NO HAY RESULTADOS EN LA BUSQUEDA
            Exit Sub
        Else
            Dim dr As DataRow = DS2.Rows(i)
            If Not dr("efecha") Is DBNull.Value Then
                Fecha.Text = dr("efecha")
            End If

            If Not dr("enombre") Is DBNull.Value Then
                NombreE.Text = dr("enombre")
            End If

            If Not dr("ecargo") Is DBNull.Value Then
                CargoE.Text = dr("ecargo")
            End If

            If Not dr("rnombre") Is DBNull.Value Then
                NombreR.Text = dr("rnombre")
            End If

            If Not dr("rcargo") Is DBNull.Value Then
                CargoR.Text = dr("rcargo")
            End If

            If Not dr("ehoramin") Is DBNull.Value Then
                Dim horamin As String = dr("ehoramin")
                Dim h, m As String
                h = horamin.Substring(0, 2)
                m = horamin.Substring(3, 2)
                ehora.SelectedItem.Text = h
                emin.SelectedItem.Text = m
            Else
                'ehora.SelectedItem.Text = "01"
                'emin.SelectedItem.Text = "00"


                'ehora.SelectedItem.Text = dr("ehoramin")
            End If
            'If Not dr("ehoramin") Is DBNull.Value Then
            '    emin.SelectedItem.Text = dr("ehoramin")
            'End If
            If Not dr("rcargo") Is DBNull.Value Then
                CargoR.Text = dr("rcargo")
            End If
        End If
    End Sub
    'DISEÑO DE LA VENTANA
    Private Sub limpia()
        Fecha.Text = ""

        NombreE.Text = ""
        CargoE.Text = ""
        NombreR.Text = ""
        CargoR.Text = ""
        Lblerror.Text = ""
    End Sub
    'DISEÑO DE LA VENTANA
    Private Sub Controles_Activados(ByRef Estado As Boolean)
        Fecha.Enabled = Estado
        NombreE.Enabled = Estado
        CargoE.Enabled = Estado
        NombreR.Enabled = Estado
        CargoR.Enabled = Estado
        Fecha.Enabled = Estado
        ehora.Enabled = Estado
        emin.Enabled = Estado
    End Sub
    'Validar todos los datos correctos de la ventana
    Function valida_campos() As Boolean
        Dim valor As Boolean
        If Fecha.Text = "" Or NombreE.Text = "" Or CargoE.Text = "" Or NombreR.Text = "" Or CargoR.Text = "" Or ehora.Text = "" Or emin.Text = "" Then
            Lblerror.Text = "POR FAVOR INGRESE TODOS LOS DATOS!"
            valor = False
        Else
            valor = True
        End If
        Return valor
    End Function
    'Tabla CASILLAS
    Private Sub guarda_modificacion(ByRef id As Integer)
        If valida_campos() Then
            Dim fechacap As Date
            fechacap = System.DateTime.Today.Date.Date
            Dim MYSQL As String = "UPDATE CASILLAS SET " & _
            "dtto = '" & Session("id_dtto") & "', " & _
            "mpio = '" & Session("mpio") & "', " & _
            "efecha = '" & Fecha.Text & "', " & _
            "enombre = UPPER('" & NombreE.Text & "'), " & _
            "ecargo = UPPER('" & CargoE.Text & "'), " & _
            "rnombre = UPPER('" & NombreR.Text & "'), " & _
            "rcargo = UPPER('" & CargoR.Text & "'), " & _
            "ehoramin = '" & ehora.SelectedItem.Text & ":" & emin.SelectedItem.Text & "', " & _
            "fechaCaptura = '" & fechacap & "' WHERE id =" & id
            If con.ejecutar(MYSQL) Then
                Lblerror.Text = "LOS DATOS SE GUARDARON CORRECTAMENTE"
                Mpio.Enabled = True
                Secc.Enabled = True
                Cas.Enabled = True
                editar.Enabled = True
                guardar.Enabled = False
                cancelar.Enabled = False
                Controles_Activados(False)
                Fecha.Enabled = False
            Else
                Lblerror.Text = "OCURRIO UN ERROR"
            End If
        End If
    End Sub
    'Tabla municipios
    Protected Sub Mpio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mpio.SelectedIndexChanged
        If Mpio.SelectedItem.Text <> "" Then
            SECCIONES()
        End If
    End Sub

    Protected Sub Secc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Secc.SelectedIndexChanged
        If Secc.SelectedItem.Text <> "" Then
            casillas()
        End If
    End Sub

    Protected Sub Cas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cas.SelectedIndexChanged
        Carga_h()
        Carga_m()
        If Cas.SelectedItem.Text <> "" Then
            busca(Cas.SelectedItem.Value)
        End If
    End Sub

    Protected Sub Editar_Click(sender As Object, e As EventArgs) Handles editar.Click
        If Mpio.SelectedIndex <> 0 Then
            Mpio.Enabled = False         'Protected Sub Mpio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mpio.SelectedIndexChanged
            Secc.Enabled = False         'Protected Sub Secc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Secc.SelectedIndexChanged
            Cas.Enabled = False          'Protected Sub Cas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cas.SelectedIndexChanged
            guardar.Enabled = True
            cancelar.Enabled = True
            Controles_Activados(True)
            editar.Enabled = False
        End If
    End Sub

    Protected Sub cancelar_Click(sender As Object, e As EventArgs) Handles cancelar.Click
        limpia()
        If Cas.SelectedItem.Text <> "" Then
            busca(Cas.SelectedItem.Value)
        End If
        Mpio.Enabled = True
        Secc.Enabled = True
        Cas.Enabled = True
        guardar.Enabled = False
        cancelar.Enabled = False
        Controles_Activados(False)
        Fecha.Enabled = False
        editar.Enabled = True
    End Sub

    Protected Sub Guardar_Click(sender As Object, e As EventArgs) Handles guardar.Click
        guarda_modificacion(Cas.SelectedItem.Value)
    End Sub

    Private Function h() As String
        Throw New NotImplementedException
    End Function

    'Private Function m() As String
    'Throw New NotImplementedException
    'End Function


End Class
