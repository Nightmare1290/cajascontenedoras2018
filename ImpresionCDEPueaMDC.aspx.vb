
Partial Class ImpresionCDEPueaMDC
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("aceptado") = "SI" Then
                Response.Redirect("login.aspx")
            End If
        End If
    End Sub
End Class
