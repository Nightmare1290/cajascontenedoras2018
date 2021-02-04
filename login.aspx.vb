
Partial Class login
    Inherits System.Web.UI.Page
    Public con As conexion = New conexion
    Dim tipo As String = ""

    Function tipousuario(user As String, pass As String) As String
        Dim DS2 As Data.DataTable
        Dim query As String = "Select * from usuarios WHERE usr='" & user & "' AND pwd= '" + pass + "'"
        DS2 = con.consulta(query)
        Dim uf As Integer = DS2.Rows.Count
        If uf = 0 Then
            tipo = "n/a"   'NO EXISTE EL USUARIO
        Else
            Dim dr As Data.DataRow = DS2.Rows(0)
            Session("id_usuario") = dr("id_us")
            Session("aceptado") = "SI"
            Session("id_dtto") = dr("id_dtto")
            Session("usr") = dr("usr")
            Session("entrega") = dr("entrega")
            Session("ultparte") = dr("ultparte")
            Session("mpio") = dr("mpio")

            If dr("id_us") = 0 Then
                tipo = "1"
            Else
                tipo = "0"
            End If
        End If
        Return tipo

    End Function

    Protected Sub BtnEntrar_Click(sender As Object, e As EventArgs) Handles BtnEntrar.Click
        tipousuario(TxtUser.Text, TxtPassword.Text)
        If tipo = "n/a" Then
            'USUARIO O CONTRASEÑA INCORRECTO
            Lblerror.Text = "Usario o contraseña incorrecto"
            TxtUser.Text = ""
            TxtPassword.Text = ""
        Else
            If tipo = "1" Then
                'ENVIAR A INICIO DE ADMIN
                Session("Admin") = "SI"
            Else
                'ENVIAR A INICIO DE USUARIO
                Session("Admin") = "NO"
            End If
            Response.Redirect("menu.aspx")
        End If
    End Sub
End Class
