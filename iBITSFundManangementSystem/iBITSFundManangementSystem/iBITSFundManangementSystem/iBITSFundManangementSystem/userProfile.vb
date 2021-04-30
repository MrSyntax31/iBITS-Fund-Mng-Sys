Imports System.Data.SqlClient
Public Class userProfile
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        updateUser.Show()

    End Sub
    Public Sub datatotextprofile()
        Dim id As String = user.Label2.Text
        Dim connection As New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
        connection.Open()
        Dim command As New SqlCommand("select course_tbl.courseName, studLname, studFname,studMname,age,gender,yearlevel from course_tbl INNER JOIN student_tbl on course_tbl.course_ID = student_tbl.CourseID where StudentID = @StudentID", connection)
        command.Parameters.AddWithValue("@StudentID", id)
        Dim da As SqlDataReader = command.ExecuteReader()
        While (da.Read())

            TextBox1.Text = da.GetValue(0).ToString()
            TextBox2.Text = da.GetValue(1).ToString()
            TextBox3.Text = da.GetValue(2).ToString()
            TextBox4.Text = da.GetValue(3).ToString()
            TextBox5.Text = da.GetValue(4).ToString()
            TextBox6.Text = da.GetValue(5).ToString()
            TextBox7.Text = da.GetValue(6).ToString()

            Return
        End While
    End Sub
    Private Sub userProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datatotextprofile()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
    End Sub


End Class