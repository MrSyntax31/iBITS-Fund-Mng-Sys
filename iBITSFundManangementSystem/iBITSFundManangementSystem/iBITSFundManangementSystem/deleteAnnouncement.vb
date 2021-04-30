Imports System.Data.SqlClient
Public Class deleteAnnouncement
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim announcementID As String = ComboBox1.SelectedValue


        Try
            Dim sql As String = "DELETE from announcement_tbl where announcementID = @announcementID"
            Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
                Using cmd As SqlCommand = New SqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@announcementID", announcementID)


                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()


                    announcement.loadAnnouncement()
                    MsgBox("Announcement Succesfully Deleted")

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub deleteAnnouncement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateAnnouncement.combobox()
    End Sub
End Class