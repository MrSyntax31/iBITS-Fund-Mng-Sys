Imports System.Data.SqlClient
Public Class updateUser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim StudentID As String = ComboBox3.SelectedValue
        Dim studLname As String = TextBox2.Text
        Dim studFname As String = TextBox3.Text
        Dim studMname As String = TextBox4.Text
        Dim age As String = TextBox5.Text
        Dim CourseID As String = ComboBox2.SelectedValue
        Dim yearlevel As String = TextBox7.Text
        Dim gender As String = ComboBox1.Text
        Try
            Dim sql As String = "UPDATE student_tbl SET CourseID =@CourseID,studLname =@studLname,studFname =@studFname,studMname =@studMname,age =@age,gender =@gender,yearlevel =@yearlevel WHERE StudentID = @StudentID"
            Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
                Using cmd As SqlCommand = New SqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@StudentID", StudentID)
                    cmd.Parameters.AddWithValue("@CourseID", CourseID)
                    cmd.Parameters.AddWithValue("@studLname", studLname)
                    cmd.Parameters.AddWithValue("@studFname", studFname)
                    cmd.Parameters.AddWithValue("@studMname", studMname)
                    cmd.Parameters.AddWithValue("@age", age)
                    cmd.Parameters.AddWithValue("@gender", gender)
                    cmd.Parameters.AddWithValue("@yearlevel", yearlevel)

                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()

                    For Each tbox As TextBox In Me.Controls.OfType(Of TextBox)()
                        tbox.Text = String.Empty
                    Next


                    MsgBox("Data Succesfully Updated")

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub updateUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combobox()
        comboboxID()
    End Sub
    Public Sub combobox()
        Dim connection As New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
        Dim command As New SqlCommand("select * from course_tbl", connection)

        Dim adapter As New SqlDataAdapter(command)
        Dim tbl As New DataTable()
        adapter.Fill(tbl)

        ComboBox2.DataSource = tbl
        ComboBox2.DisplayMember = "courseName"
        ComboBox2.ValueMember = "course_ID"

    End Sub
    Public Sub comboboxID()
        Dim connection As New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
        Dim command As New SqlCommand("select * from student_tbl", connection)

        Dim adapter As New SqlDataAdapter(command)
        Dim tbl As New DataTable()
        adapter.Fill(tbl)

        ComboBox3.DataSource = tbl
        ComboBox3.DisplayMember = "StudentID"
        ComboBox3.ValueMember = "StudentID"
    End Sub

End Class