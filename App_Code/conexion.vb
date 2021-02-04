Imports Microsoft.VisualBasic


Public Class conexion
    Public Function ejecutar(ByVal query As String) As Boolean
        If Not String.IsNullOrEmpty(query) Then
            Dim MyConnection As String = ConfigurationManager.ConnectionStrings("paquetesE2016").ConnectionString
            Dim cmd As New Data.SqlClient.SqlCommand()
            Dim MyConnection1 = New Data.SqlClient.SqlConnection(MyConnection)
            cmd.Connection = MyConnection1
            MyConnection1.Open()
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                MyConnection1.Close()
                Return True
            Catch ex As Data.DBConcurrencyException
                MyConnection1.Close()
                Return False
                ' MsgBox(eInsertException.Message)
            Catch ex As Exception
                MyConnection1.Close()
                Return False
                ' Response.Redirect("../error.aspx", False)
            End Try
            Return False
        End If
        Return False
    End Function

    Public Function consulta(ByVal query As String) As Data.DataTable
        Dim DS As Data.DataTable
        Dim MyConnection As String = ConfigurationManager.ConnectionStrings("paquetesE2016").ConnectionString
        Dim MyCommand As New Data.SqlClient.SqlDataAdapter
        MyCommand = New Data.SqlClient.SqlDataAdapter(query, MyConnection)
        DS = New Data.DataTable()
        MyCommand.Fill(DS)
        Return DS
    End Function

    Public Function consultaubicas(ByVal query As String) As Data.DataTable
        Dim DS As Data.DataTable
        Dim MyConnection As String = ConfigurationManager.ConnectionStrings("ubicas2016").ConnectionString
        Dim MyCommand As New Data.SqlClient.SqlDataAdapter
        MyCommand = New Data.SqlClient.SqlDataAdapter(query, MyConnection)
        DS = New Data.DataTable()
        MyCommand.Fill(DS)
        Return DS
    End Function


End Class


