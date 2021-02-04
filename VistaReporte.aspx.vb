Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.ReportAppServer
Imports CrystalDecisions.Web


Partial Class VistaReporte
    Inherits System.Web.UI.Page
    Private cr As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Public con As conexion = New conexion

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Ruta.Text = Request.QueryString("aux1")
        Consulta.Text = Request.QueryString("aux2")
        Tabla.Text = Request.QueryString("aux3")
        NameArc.Text = Request.QueryString("aux4")
        tipoR.Text = Request.QueryString("aux5")
        Imprime()
    End Sub

    Private Sub Imprime()
        Dim ds As New DataSet()
        NameArc.Text = NameArc.Text
        Try
            Dim tipo As String = tipoR.Text
            cr.Load(Server.MapPath("~/" & Ruta.Text))
            Dim DS2 As Data.DataTable
            Dim query As String = Consulta.Text
            DS2 = con.consulta(query)
            cr.SetDataSource(DS2)

            If tipo = "0" Then
                cr.ExportToHttpResponse(ExportFormatType.Excel, Response, True, NameArc.Text)
            End If
            If tipo = "1" Then
                cr.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, NameArc.Text)
            End If
        Catch ee As Exception
            NameArc.Text = ee.Message.ToString
        End Try
    End Sub

    Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Unload
        cr.Close()
    End Sub



End Class
