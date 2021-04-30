Imports System.Data.SqlClient
Imports System.Configuration

Public Class student
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addStudent.Show()

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        updateStudent.Show()

    End Sub

    Private Sub student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQL As String
        Try
            SQL &= "SELECT 
	student_tbl.StudentID,student_tbl.studFname ,student_tbl.studMname ,student_tbl.studLname, student_tbl.age , student_tbl. gender,course_tbl.courseName, student_tbl.yearlevel 
FROM
	(student_tbl INNER JOIN course_tbl ON student_tbl.courseID = course_tbl.course_ID ) "

            Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
                Using cmd As SqlCommand = New SqlCommand(SQL, connection)
                    Using da As New SqlDataAdapter
                        da.SelectCommand = cmd
                        Using dt As New DataTable()
                            da.Fill(dt)
                            DataGridView1.DataSource = dt
                            DataGridView1.Columns(0).HeaderText = "Student ID"
                            DataGridView1.Columns(1).HeaderText = "First Name"
                            DataGridView1.Columns(2).HeaderText = "Middle Name"
                            DataGridView1.Columns(3).HeaderText = "Last Name"
                            DataGridView1.Columns(4).HeaderText = "Age"
                            DataGridView1.Columns(5).HeaderText = "Gender"
                            DataGridView1.Columns(6).HeaderText = "Course"
                            DataGridView1.Columns(7).HeaderText = "Year Level"



                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        searchID()
    End Sub
    Public Sub searchID()
        Dim SQL As String
        SQL &= "SELECT 
	student_tbl.StudentID,student_tbl.studFname ,student_tbl.studMname ,student_tbl.studLname, student_tbl.age , student_tbl. gender,course_tbl.courseName, student_tbl.yearlevel
FROM
	(student_tbl INNER JOIN course_tbl ON student_tbl.courseID = course_tbl.course_ID ) where StudentID like '%" + TextBox1.Text + "%'"

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
End Class