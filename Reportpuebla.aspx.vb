
Partial Class Reportpuebla
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
        If Session("Admin") = "NO" Then
            query = "SELECT * FROM REP_DOE_CDE WHERE id_dtto IN (9,10,11,16,17,19,20)"
            LanzaParametros("Reportes/REP_CMEPUEBLA_CDE.rpt", query, "REP_DOE_CDE", "Reporte CME Puebla a CDE'S")
        Else

        End If
    End Sub

    Private Sub LanzaParametros(ByRef Reports As String, ByRef Consults As String, ByRef tables As String, ByRef Names As String)
        Dim tipoR = RBTLGrafMunicip.SelectedValue
        Dim pClientScript As String
        pClientScript = "VistaReporte.aspx?AUX1=" & Reports & "&AUX2=" & Consults & "&AUX3=" & tables & "&AUX4=" & Names & "&AUX5=" & tipoR
        Response.Redirect(pClientScript)
    End Sub

    Protected Sub btnR2_Click(sender As Object, e As EventArgs) Handles btnR2.Click
        Dim query As String = ""

        If Session("Admin") = "NO" Then
            query = "SELECT *  FROM REP_DOE_CDE_PUE  where id_dtto in (9,10,11,16,17,19,20)"
            'WHERE uacg='true'"
        Else
            'query = "SELECT *  FROM REP_DOE_CDE_PUE WHERE dtto=" & Session("id_dtto") & " and fechaCU IS NOT NULL" '& " and uacg='true'"
        End If
        LanzaParametros("Reportes/GRA_CMEPUE_CDE.rpt", query, "REP_DOE_CDE_PUE", "Reporte Grafica CME PUEBLA a CDE PUEBLA")
    End Sub

End Class
