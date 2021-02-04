﻿Imports System.Net
Imports System.Data
Imports System.Data.SqlClient

Partial Class CapturaCDEaCME
    Inherits System.Web.UI.Page
    Public con As conexion = New conexion
 

    'TABLA USUARIO
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("aceptado") = "SI" Then
                titulo.Text = Session("entrega")
                dtto.Text = Session("id_dtto")
                Carga_Mpios()
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
    'Tabla municipio
    Private Sub Carga_Mpios()
        Dim DS2 As Data.DataTable
        Dim i As Integer

        Dim MySQL As String = "SELECT * FROM municipios WHERE dtto=" & dtto.Text
        DS2 = con.consulta(MySQL)
        Dim uf As Integer = DS2.Rows.Count
        mpios.Items.Clear()
        If uf > 0 Then
            mpios.Items.Add("")    'Add("Seleccione...")
            For i = 0 To uf - 1
                Dim dr As Data.DataRow = DS2.Rows(i)
                Dim lista As New ListItem()
                'lista.Text = dr("mpio") & " " & dr("municipio")
                lista.Text = dr("municipio")
                lista.Value = dr("mpio")
                mpios.Items.Add(lista)
            Next
            mpios.SelectedIndex = 0
        End If
        If mpios.SelectedItem.Text <> "" Then
            busca(mpios.SelectedItem.Value)
        End If
    End Sub
    'Tabla dbo.DOE_CME
    Private Sub busca(ByRef id As String)
        Dim DS2 As Data.DataTable
        Dim i As Integer
        Dim MySQL As String = "SELECT*FROM CDE_CME WHERE mpio=" & id
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

            If Not dr("ehoramin") Is DBNull.Value Then      '"ehoramin" se encarga de separar las horas y los minutos en 2 columnas en base de datos
                Dim horamin As String = dr("ehoramin")
                Dim h, m As String
                h = horamin.Substring(0, 2)
                m = horamin.Substring(3, 2)
                ehora.SelectedItem.Text = h
                emin.SelectedItem.Text = m
            Else
                'ehora.SelectedItem.Text = "01"
                'emin.SelectedItem.Text = "00"

            End If

            If Not dr("rcargo") Is DBNull.Value Then
                CargoR.Text = dr("rcargo")
            End If
        End If
    End Sub

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
        'SE BLOQUE LAS TEXBOX Y LOS DROPDOWNLIST HASTA QUE DE CLICK EN el boton EDITAR se desbloquea y modifica los datos
        Fecha.Enabled = Estado
        NombreE.Enabled = Estado
        CargoE.Enabled = Estado
        NombreR.Enabled = Estado
        CargoR.Enabled = Estado
        ehora.Enabled = Estado
        emin.Enabled = Estado
    End Sub
    'Validar todos los datos correctos de la ventana
    Function valida_campos() As Boolean
        Dim valor As Boolean
        If Fecha.Text = "" Or NombreE.Text = "" Or CargoE.Text = "" Or NombreR.Text = "" Or CargoR.Text = "" Then
            Lblerror.Text = "POR FAVOR INGRESE TODOS LOS DATOS!"
            valor = False
        Else
            valor = True
        End If
        Return valor
    End Function
    'Tabla CDE_CME
    Private Sub guarda_captura(ByRef id As Integer)
        If valida_campos() Then
            Dim fechacap As Date
            fechacap = System.DateTime.Today.Date.Date
            Dim MySQL As String = "UPDATE CDE_CME SET " & _
                "mpio = '" & mpios.SelectedValue & "', " & _
                "efecha = '" & Fecha.Text & "', " & _
                "enombre = UPPER('" & NombreE.Text & "'), " & _
                "ecargo = UPPER('" & CargoE.Text & "'), " & _
                "rnombre = UPPER('" & NombreR.Text & "'), " & _
                "rcargo = UPPER('" & CargoR.Text & "'), " & _
                "ehoramin = '" & ehora.SelectedItem.Text & ":" & emin.SelectedItem.Text & "', " & _
                "fechacaptura = '" & fechacap & "' WHERE mpio =" & id
            If con.ejecutar(MySQL) Then
                Lblerror.Text = "LOS DATOS SE GUARDARON CORRECTAMENTE"
                mpios.Enabled = True
                editar.Enabled = True
                guardar.Enabled = False
                cancelar.Enabled = False
                Controles_Activados(False)                           'Es el Privete Sub Controles_Activados
                'Fecha.Enabled = False                                No son las tablas es para ejecutar, guardar, cancelar datos
            Else
                Lblerror.Text = "OCURRIO UN ERROR"
            End If
        End If
    End Sub
    'Tabla MUNICIPIO
    Protected Sub mpios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mpios.SelectedIndexChanged
        Carga_h()
        Carga_m()
        If mpios.SelectedItem.Text <> "" Then         'Selecciona el municipio para saber quien tiene los datos
            busca(mpios.SelectedItem.Value)            'buscar los datos del distrito
        End If
    End Sub

    Protected Sub editar_Click(sender As Object, e As EventArgs) Handles editar.Click
        If mpios.SelectedIndex <> 0 Then
            mpios.Enabled = False
            guardar.Enabled = True
            cancelar.Enabled = True
            Fecha.Enabled = False
            Controles_Activados(True)
            editar.Enabled = False
        End If
    End Sub

    Protected Sub guardar_Click(sender As Object, e As EventArgs) Handles guardar.Click
        guarda_captura(mpios.SelectedItem.Value)
        editar.Enabled = True
    End Sub

    Protected Sub cancelar_Click(sender As Object, e As EventArgs) Handles cancelar.Click
        limpia()
        If mpios.SelectedItem.Text <> "" Then
            busca(mpios.SelectedItem.Value)
        End If
        mpios.Enabled = True
        guardar.Enabled = False
        cancelar.Enabled = False
        Fecha.Enabled = False
        Controles_Activados(False)
        editar.Enabled = True
        'SE LE COPIO DEL EDITOR_CLICK
    End Sub

   

End Class
