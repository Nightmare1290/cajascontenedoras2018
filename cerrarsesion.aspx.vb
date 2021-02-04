Partial Class cerrarsesion
    Inherits System.Web.UI.Page
    Protected Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        Session.Abandon()
        Response.Cookies.Add(New HttpCookie("ASP.NET_SessionId", ""))
        Response.Redirect("login.aspx")
    End Sub
End Class