Imports System.Data.SqlClient
Public Class deleteAnnouncement
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim announcementID As String = TextBox1.Text


        Try
            Dim sql As String = "DELETE from announcement_tbl where announcementID = @announcementID"
            Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
                Using cmd As SqlCommand = New SqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@announcementID", announcementID)


                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()

                    For Each tbox As TextBox In Me.Controls.OfType(Of TextBox)()
                        tbox.Text = String.Empty
                    Next
                    announcement.loadAnnouncement()
                    MsgBox("Announcement Succesfully Deleted")

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub
End Class