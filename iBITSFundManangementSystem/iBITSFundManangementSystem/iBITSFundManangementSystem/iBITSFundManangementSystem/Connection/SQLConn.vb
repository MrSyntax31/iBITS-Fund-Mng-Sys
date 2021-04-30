Imports System.Data.SqlClient
Module SQLConn


    Public connString As String = "Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True"

    Function ExecuteSQL(sql As String) As DataTable

        Try
            Dim connection As New SqlConnection
            Dim adapter As SqlDataAdapter
            Dim dt As New DataTable

            connection.ConnectionString = connString

            connection.Open()

            adapter = New SqlDataAdapter(sql, connection)
            adapter.Fill(dt)

            connection.Close()
            connection = Nothing

            Return dt

        Catch ex As Exception

            'Connection Error

        End Try

    End Function

End Module
