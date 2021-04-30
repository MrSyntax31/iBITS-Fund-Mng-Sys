Imports System.Data.SqlClient
Public Class updateAnnouncement
    Private Sub updateAnnouncement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combobox()
        TextBox1.Enabled = False
        datatotext()
    End Sub
    Public Sub datatotext()
        Dim connection As New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
        connection.Open()
        Dim command As New SqlCommand("select announcementID, announcement, announcementDesc from announcement_tbl where announcementID = @announcementID", connection)
        command.Parameters.AddWithValue("@announcementID", Integer.Parse(ComboBox1.SelectedValue))
        Dim da As SqlDataReader = command.ExecuteReader()
        While (da.read())

            TextBox1.Text = da.GetValue(1).ToString()
            TextBox2.Text = da.GetValue(2).ToString()
            Return
        End While
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
        Dim announcement As String = TextBox1.Text
        Dim announcementDate = Date.Now
        Dim announcementID = ComboBox1.SelectedValue
        Dim announcementDesc = TextBox2.Text
        Try

            Dim sql As String = "UPDATE announcement_tbl SET announcement = @announcement, announcementDate = @announcementDate WHERE announcementID = @announcementID"
            Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security= True")
                Using cmd As SqlCommand = New SqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@announcementID", announcementID)
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
                    combobox()
                    datatotext()
                    MsgBox("Announcement Succesfully Updated")

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