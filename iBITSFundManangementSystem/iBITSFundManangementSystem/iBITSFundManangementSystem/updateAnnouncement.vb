Imports System.Data.SqlClient
Public Class updateAnnouncement
    Private Sub updateAnnouncement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combobox()


    End Sub

    Public Sub combobox()
        Dim connection As New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
        Dim command As New SqlCommand("select * from announcement_tbl", connection)

        Dim adapter As New SqlDataAdapter(command)
        Dim tbl As New DataTable()
        adapter.Fill(tbl)

        ComboBox1.DataSource = tbl
        ComboBox1.DisplayMember = "announcement"
        ComboBox1.ValueMember = "announcementID"

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim ann As String = ComboBox1.SelectedValue


        Try
            Dim sql As String = "DELETE from announcement_tbl where announcementID = @announcementID"
            Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
                Using cmd As SqlCommand = New SqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@announcementID", ann)


                    connection.Open()

                    cmd.ExecuteNonQuery()
                    connection.Close()

                    For Each tbox As TextBox In Me.Controls.OfType(Of TextBox)()
                        tbox.Text = String.Empty
                    Next
                    announcement.loadAnnouncement()
                    combobox()
                    MsgBox("Announcement Succesfully Deleted")

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
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
                        announcement.DataGridView1.DataSource = dt

                    End Using
                End Using
            End Using
        End Using
    End Sub
End Class