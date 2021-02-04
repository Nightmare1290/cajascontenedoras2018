
Partial Class ReportesDOE
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
        If Session("Admin") = "SI" Then
            query = "SELECT *  FROM REP_DOE_CDE where id_dtto not in (9,10,11,16,17,19,20,27)"
            LanzaParametros("Reportes/REP_DOE_CDE.rpt", query, "REP_DOE_CDE", "REPORTE IEE_CDE")

        Else
            'query = "SELECT *  FROM avanceCapturaMpio WHERE distrito=" & Session("id_dtto")
            'LanzaParametros("Reportes/CapturaUbicacionAvanceMun.rpt", query, "avanceCapturaMpio", "Avance")
        End If
    End Sub
    Private Sub LanzaParametros(ByRef Reports As String, ByRef Consults As String, ByRef tables As String, ByRef Names As String)
        Dim pClientScript As String
        Dim tipoR = RBTLGrafMunicip.SelectedValue
        pClientScript = "VistaReporte.aspx?AUX1=" & Reports & "&AUX2=" & Consults & "&AUX3=" & tables & "&AUX4=" & Names & "&AUX5=" & tipoR
        Response.Redirect(pClientScript)
    End Sub

    Protected Sub btnR2_Click(sender As Object, e As EventArgs) Handles btnR2.Click
        Dim query As String = ""

        If Session("Admin") = "SI" Then
            query = "SELECT *  FROM REP_DOE_CDE where id_dtto = 27"
            'WHERE uacg='true'"
        Else
            'query = "SELECT *  FROM REP_DOE_CDE_PUE WHERE dtto=" & Session("id_dtto") & " and fechaCU IS NOT NULL" '& " and uacg='true'"
        End If
        LanzaParametros("Reportes/REP_DOE_CME_PUE.rpt", query, "REP_DOE_CDE", "REPORTE IEE a CME PUEBLA")
    End Sub
    Protected Sub btnR3_Click(sender As Object, e As EventArgs) Handles btnR3.Click
        Dim query As String = ""

        If Session("Admin") = "SI" Then
            query = "SELECT *  FROM REP_DOE_CMEboletas where mpio < 218 order by dtto,mpio"
            'WHERE uacg='true'"
        Else
            'query = "SELECT *  FROM REP_DOE_CDE_PUE WHERE dtto=" & Session("id_dtto") & " and fechaCU IS NOT NULL" '& " and uacg='true'"
        End If
        LanzaParametros("Reportes/REP_DOE_BOLETAS_CME.rpt", query, "REP_DOE_CMEboletas", "REPORTE IEE a Boletas CME")
    End Sub
    Protected Sub btnR4_Click(sender As Object, e As EventArgs) Handles btnR4.Click
        Dim query As String = ""

        If Session("Admin") = "SI" Then
            query = "SELECT *  FROM REP_DOE_CDE where id_dtto not in (9,10,11,16,17,19,20)"
            'WHERE uacg='true'"
        Else
            'query = "SELECT *  FROM REP_DOE_CDE_PUE WHERE dtto=" & Session("id_dtto") & " and fechaCU IS NOT NULL" '& " and uacg='true'"
        End If
        LanzaParametros("Reportes/GRA_DOE_CDE.rpt", query, "REP_DOE_CDE", "GRAFICA IEE_CDE")
    End Sub
    
    Protected Sub btnR5_Click(sender As Object, e As EventArgs) Handles btnR5.Click
        Dim query As String = ""

        If Session("Admin") = "SI" Then
            query = "SELECT *  FROM REP_DOE_CDE where id_dtto = 27"
            'WHERE uacg='true'"
        Else
            'query = "SELECT *  FROM REP_DOE_CDE_PUE WHERE dtto=" & Session("id_dtto") & " and fechaCU IS NOT NULL" '& " and uacg='true'"
        End If
        LanzaParametros("Reportes/GRA_DOE_CDE_PUE.rpt", query, "REP_DOE_CDE", "GRAFICA IEE a CME PUEBLA")

    End Sub
    Protected Sub btnR6_Click(sender As Object, e As EventArgs) Handles btnR6.Click
        Dim query As String = ""

        If Session("Admin") = "SI" Then
            query = "SELECT *  FROM GRA_XDIS"
            'WHERE uacg='true'"
        Else
            'query = "SELECT *  FROM REP_DOE_CDE_PUE WHERE dtto=" & Session("id_dtto") & " and fechaCU IS NOT NULL" '& " and uacg='true'"
        End If
        LanzaParametros("Reportes/graglobal.rpt", query, "GRA_XDIS", "GRAFICA GLOBAL")
    End Sub

   
End Class
