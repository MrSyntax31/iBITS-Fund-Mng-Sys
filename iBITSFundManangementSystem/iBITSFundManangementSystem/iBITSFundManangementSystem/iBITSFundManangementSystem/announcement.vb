Imports System.Data.SqlClient
Public Class announcement
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        updateAnnouncement.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        deleteAnnouncement.Show()
    End Sub

    Private Sub announcement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadAnnouncement()
    End Sub
    Public Sub loadAnnouncement()
        Dim SQL As String
        SQL &= "select * from announcement_tbl"

        Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(SQL, connection)
                Using da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.Columns(0).HeaderText = "ID"
                        DataGridView1.Columns(1).HeaderText = "Date"
                        DataGridView1.Columns(2).HeaderText = "Announcement"
                        DataGridView1.Columns(3).HeaderText = "Description"
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim announcement As String = TextBox3.Text
        Dim announcementDate = Date.Now
        Dim announcementDesc = TextBox2.Text
        Try
            Dim sql As String = "INSERT INTO announcement_tbl VALUES (@announcementDate,@announcement,@announcementDesc)"
            Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
                Using cmd As SqlCommand = New SqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@announcementDate", announcementDate)
                    cmd.Parameters.AddWithValue("@announcement", announcement)
                    cmd.Parameters.AddWithValue("@announcementDesc", announcementDesc)
                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()

                    For Each tbox As TextBox In Me.Controls.OfType(Of TextBox)()
                        tbox.Text = String.Empty
                    Next
                    loadAnnouncement()
                    MsgBox("New Announcement Succesfully Added")

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub
End Class