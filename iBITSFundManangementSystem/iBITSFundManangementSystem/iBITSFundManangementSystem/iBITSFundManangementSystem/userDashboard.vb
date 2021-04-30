Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO
Public Class userDashboard


    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click



    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub userDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadAnnouncement()
        balance()
        loadMisc()
        Timer1.Start()

    End Sub

    Public Sub loadAnnouncement()
        Dim SQL As String
        SQL &= "select announcement,announcementDesc, announcementDate from announcement_tbl"

        Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(SQL, connection)
                Using da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.Columns(0).HeaderText = "Announcement"
                        DataGridView1.Columns(1).HeaderText = "Description"
                        DataGridView1.Columns(2).HeaderText = "Date"
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Public Sub loadMisc()
        Dim SQL As String
        SQL &= "select misc_name, misc_amount, misc_duedate from misc_tbl"

        Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(SQL, connection)
                Using da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        DataGridView2.DataSource = dt
                        DataGridView2.Columns(0).HeaderText = "Miscellanous"
                        DataGridView2.Columns(1).HeaderText = "Amount"
                        DataGridView2.Columns(2).HeaderText = "Date"
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Public Sub balance()
        Dim conn As New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
        conn.Open()

        Dim balance As New SqlCommand("
	 SELECT  
 (Select Sum (misc_amount) as misc_amount from misc_tbl)
 -
 (SELECT sum(misc_tbl.misc_amount) FROM misc_tbl INNER JOIN paymentHistory ON misc_tbl.misc_ID = paymentHistory.misc_ID WHERE  StudentID = '" & user.Label2.Text & "')", conn)
        Dim balancesum = Convert.ToString(balance.ExecuteScalar)

        Label5.Text = balancesum

        conn.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        balance()
        loadAnnouncement()
    End Sub
End Class