Imports System.Data.SqlClient
Public Class AddTransaction
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim misc_name As String = TextBox1.Text
        Dim misc_duedate As String = DateTimePicker1.Value
        Dim misc_amount As String = TextBox4.Text
        Dim misc_date = Date.Now

        Try
            Dim sql As String = "INSERT INTO misc_tbl VALUES (@misc_name,@misc_date,@misc_duedate,@misc_amount)"
            Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
                Using cmd As SqlCommand = New SqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@misc_name", misc_name)
                    cmd.Parameters.AddWithValue("@misc_date", misc_date)
                    cmd.Parameters.AddWithValue("@misc_duedate", misc_duedate)
                    cmd.Parameters.AddWithValue("@misc_amount", misc_amount)

                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()

                    For Each tbox As TextBox In Me.Controls.OfType(Of TextBox)()
                        tbox.Text = String.Empty
                    Next

                    MsgBox("New Fee Succesfully Added")

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub
End Class