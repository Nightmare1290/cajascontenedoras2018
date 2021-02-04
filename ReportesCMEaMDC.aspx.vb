
Partial Class ReportesCMEaMDC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("aceptado") = "SI" Then
                Response.Redirect("login.aspx")
            End If
        End If
    End Sub

    Protected Sub btnR1_Click(sender As Object, e As EventArgs) Handles btnR1.Click
        Dim query As String
        query = "SELECT * FROM REP_CME_MDC WHERE mpio=" & Session("mpio")
        LanzaParametros("Reportes/REP_CME_MDC.rpt", query, "REP_CME_MDC", "Reporte CME a MDC")

    End Sub

    Private Sub LanzaParametros(ByRef Reports As String, ByRef Consults As String, ByRef tables As String, ByRef Names As String)
        Dim pClientScript As String
        Dim tipoR = RBTLGrafMunicip.SelectedValue
        pClientScript = "VistaReporte.aspx?AUX1=" & Reports & "&AUX2=" & Consults & "&AUX3=" & tables & "&AUX4=" & Names & "&AUX5=" & tipoR
        Response.Redirect(pClientScript)

    End Sub

    Protected Sub btnR2_Click(sender As Object, e As EventArgs) Handles btnR2.Click
        Dim query As String
        query = "SELECT * FROM prueba WHERE mpio=" & Session("mpio")
        LanzaParametros("Reportes/pruba.rpt", query, "prueba", "Reporte CME a MDC")
    End Sub

End Class
