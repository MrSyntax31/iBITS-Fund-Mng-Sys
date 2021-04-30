Imports System.Data.SqlClient
Imports System.Configuration


Public Class transaction
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddTransaction.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 
        updateTransaction.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        deleteTransaction.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Public Sub miscLoad()
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
                        DataGridView2.Columns(2).HeaderText = "Due Date"

                    End Using
                End Using
            End Using
        End Using
    End Sub
    Private Sub transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        miscLoad()
        Dim SQL As String
        SQL &= "SELECT misc_tbl.misc_name,student_tbl.studFname, paymentHistory.misc_status FROM (((student_tbl INNER JOIN paymentHistory ON student_tbl.studentID = paymentHistory.studentID INNER JOIN misc_tbl  ON misc_tbl.misc_ID = paymentHistory.misc_ID ))) where misc_status = 'Paid' order by misc_datepaid desc;"

        Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(SQL, connection)
                Using da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.Columns(0).HeaderText = "Miscellanous"
                        DataGridView1.Columns(1).HeaderText = "Student Name"
                        DataGridView1.Columns(2).HeaderText = "Status"

                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim SQL As String
        SQL &= "SELECT misc_tbl.misc_name,student_tbl.studFname, paymentHistory.misc_status FROM (((student_tbl INNER JOIN paymentHistory ON student_tbl.studentID = paymentHistory.studentID INNER JOIN misc_tbl  ON misc_tbl.misc_ID = paymentHistory.misc_ID ))) where  misc_name like '%" + TextBox1.Text + "%'"

        Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(SQL, connection)
                Using da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    Using dt As New DataTable()

                        da.Fill(dt)
                        DataGridView1.DataSource = dt
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class