
Partial Class ReportesCDEaCME
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
        query = "SELECT * FROM REP_CDE_CME WHERE dtto=" & Session("id_dtto")
        LanzaParametros("Reportes/REP_CDE_CME.rpt", query, "REP_CDE_CME", "Reporte CDE-CME")

    End Sub

    Private Sub LanzaParametros(ByRef Reports As String, ByRef Consults As String, ByRef tables As String, ByRef Names As String)
        Dim pClientScript As String
        Dim tipoR = RBTLGrafMunicip.SelectedValue
        pClientScript = "VistaReporte.aspx?AUX1=" & Reports & "&AUX2=" & Consults & "&AUX3=" & tables & "&AUX4=" & Names & "&AUX5=" & tipoR
        Response.Redirect(pClientScript)

    End Sub

    Protected Sub btnR2_Click(sender As Object, e As EventArgs) Handles btnR2.Click
        Dim query As String
        query = "SELECT *  FROM REP_CDE_CME WHERE dtto=" & Session("id_dtto")
        LanzaParametros("Reportes/GRA_CDE_CME.rpt", query, "REP_CDE_CME", "Reporte Grafica CDE-CME")
    End Sub


    Protected Sub btnR3_Click(sender As Object, e As EventArgs) Handles btnR3.Click
        Dim query As String
        query = "SELECT * FROM REP_CME_MDC WHERE dtto=" & Session("id_dtto")
        LanzaParametros("Reportes/REP_CME_MDC.rpt", query, "REP_CME_MDC", "Reporte CME-MDC")
    End Sub

    Protected Sub btnR4_Click(sender As Object, e As EventArgs) Handles btnR4.Click
        Dim query As String
        query = "SELECT * FROM GRA_XDIS WHERE distrito=" & Session("id_dtto")
        LanzaParametros("Reportes/GRA_CME_MDC.rpt", query, "GRA_XDIS", "Reporte CME-MDC")

    End Sub
End Class
