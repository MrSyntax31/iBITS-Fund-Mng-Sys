Imports System.Data.SqlClient
Public Class payment
    Private Sub payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showPaymentHistory()
        combobox()
        Timer1.Start()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) 
        printPayment.Show()
    End Sub
    Public Sub combobox()
        Dim connection As New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
        Dim command As New SqlCommand("select * from misc_tbl", connection)

        Dim adapter As New SqlDataAdapter(command)
        Dim tbl As New DataTable()
        adapter.Fill(tbl)

        ComboBox2.DataSource = tbl
        ComboBox2.DisplayMember = "misc_name"
        ComboBox2.ValueMember = "misc_ID"

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        showPaymentHistory()
    End Sub
    Public Sub showPaymentHistory()
        Dim SQL As String
        Try
            SQL &= "SELECT 
	login_tbl.studentID, misc_tbl.misc_name,misc_tbl.misc_amount, student_tbl.studFname , paymentHistory.misc_status, paymentHistory.misc_datepaid
	
FROM
	((login_tbl INNER JOIN student_tbl ON login_tbl.StudentID = student_tbl.StudentID  INNER JOIN  paymentHistory ON paymentHistory.StudentID = student_tbl.StudentID INNER JOIN misc_tbl ON paymentHistory.misc_ID = misc_tbl.misc_ID)) WHERE username = '" & user.Label1.Text & "'"

            Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
                Using cmd As SqlCommand = New SqlCommand(SQL, connection)
                    Using da As New SqlDataAdapter
                        da.SelectCommand = cmd
                        Using dt As New DataTable()
                            da.Fill(dt)
                            DataGridView1.DataSource = dt
                            DataGridView1.Columns(0).HeaderText = "Student ID"
                            DataGridView1.Columns(1).HeaderText = "Miscellanous"
                            DataGridView1.Columns(2).HeaderText = "Amount"
                            DataGridView1.Columns(3).HeaderText = "Name"
                            DataGridView1.Columns(4).HeaderText = "Status"
                            DataGridView1.Columns(5).HeaderText = "Date paid"
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim btn As MessageBoxButtons = MessageBoxButtons.OK
        Dim ico As MessageBoxIcon = MessageBoxIcon.Information
        Dim caption As String = "Malayan"
        Dim StudentID As String = user.Label2.Text
        Dim misc_ID As String = ComboBox2.SelectedValue
        Dim misc_status As String = "Paid"
        Dim misc_datepaid As String = Date.Now


        If ComboBox1.SelectedItem = "" Then
            MessageBox.Show("Missing Payment Method!")
            Return
            Else

                Try
                Dim checkdupspayment As DataTable = ExecuteSQL("   SELECT StudentID FROM paymentHistory WHERE misc_ID = '" & ComboBox2.SelectedValue & "' and StudentID = '" & user.Label2.Text & "'")

                If checkdupspayment.Rows.Count > 0 Then

                    MessageBox.Show("Already Paid", caption, btn, ico)
                    Return
                End If

                Dim sql As String = "INSERT INTO paymentHistory VALUES (@misc_ID,@StudentID,@misc_status,@misc_datepaid)"
                Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
                    Using cmd As SqlCommand = New SqlCommand(sql, connection)
                        cmd.Parameters.AddWithValue("@misc_ID", misc_ID)
                        cmd.Parameters.AddWithValue("@StudentID", StudentID)
                        cmd.Parameters.AddWithValue("@misc_status", misc_status)
                        cmd.Parameters.AddWithValue("@misc_datepaid", misc_datepaid)

                        connection.Open()
                        cmd.ExecuteNonQuery()
                        connection.Close()

                        For Each tbox As TextBox In Me.Controls.OfType(Of TextBox)()
                            tbox.Text = String.Empty
                        Next
                        showPaymentHistory()

                        MsgBox("Payment Successful")
                        'ComboBox1.Items.Clear()
                        ComboBox1.Text = String.Empty
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error")
            End Try
        End If

    End Sub


End Class