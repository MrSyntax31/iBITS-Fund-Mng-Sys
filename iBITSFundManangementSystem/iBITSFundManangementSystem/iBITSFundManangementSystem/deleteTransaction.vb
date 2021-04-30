Imports System.Data.SqlClient

Public Class deleteTransaction
    Private Sub deleteTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim misc_ID As String = ComboBox1.Text


        Try
            Dim sql As String = "DELETE from misc_tbl where misc_ID = @misc_ID"
            Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
                Using cmd As SqlCommand = New SqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@misc_ID", misc_ID)


                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()

                    For Each tbox As TextBox In Me.Controls.OfType(Of TextBox)()
                        tbox.Text = String.Empty
                    Next
                    announcement.loadAnnouncement()
                    MsgBox("Miscellanous Succesfully Deleted")

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub
End Class