
Partial Class menu
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("aceptado") = "SI" Then
                Response.Redirect("login.aspx")
            Else
                txtadmin.Text = Session("admin")
                dtto.Text = Session("id_usuario")
                distrito.Text = Session("id_dtto")
            End If

        End If
    End Sub
End Class

