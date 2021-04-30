﻿Imports System.Data.SqlClient
Public Class addStudent
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim StudentID As String = TextBox1.Text
        Dim studLname As String = TextBox2.Text
        Dim studFname As String = TextBox3.Text
        Dim studMname As String = TextBox4.Text
        Dim age As String = TextBox5.Text
        Dim CourseID As String = ComboBox2.SelectedValue
        Dim yearlevel As String = TextBox7.Text
        Dim gender As String = ComboBox1.Text

        If String.IsNullOrEmpty(TextBox1.Text) Then
            MsgBox("Please Enter Student ID")
            Exit Sub

        ElseIf String.IsNullOrEmpty(TextBox2.Text) Then
            MsgBox("Please Enter Last Name")
            Exit Sub

        ElseIf String.IsNullOrEmpty(TextBox3.Text) Then
            MsgBox("Please Enter First Name")
            Exit Sub

        ElseIf String.IsNullOrEmpty(TextBox4.Text) Then
            MsgBox("Please Enter Middle Name")
            Exit Sub

        ElseIf String.IsNullOrEmpty(TextBox5.text) Then
            MsgBox("Please Enter Age")
            Exit Sub

        ElseIf String.IsNullOrEmpty(ComboBox1.text) Then
            MsgBox("Please Enter Gender")
            Exit Sub

        ElseIf String.IsNullOrEmpty(ComboBox2.text) Then
            MsgBox("Please Enter Course")
            Exit Sub

        ElseIf String.IsNullOrEmpty(TextBox7.text) Then
            MsgBox("Please Enter Year")
            Exit Sub

        End If

        Try
            Dim sql As String = "INSERT INTO student_tbl VALUES (@StudentID,@CourseID,@studLname,@studFname,@studMname,@age,@gender,@yearlevel)"
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
                    loadStudGrid()

                    updateUser.comboboxID()
                    MsgBox("New Student Succesfully Added")

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub
    Private Sub loadStudGrid()
        Dim SQL As String
        SQL &= "SELECT 
	student_tbl.StudentID,student_tbl.studFname ,student_tbl.studMname ,student_tbl.studLname, student_tbl.age , student_tbl. gender, student_tbl.yearlevel, course_tbl.courseName
FROM
	(student_tbl INNER JOIN course_tbl ON student_tbl.courseID = course_tbl.course_ID ) "

        Using connection As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(SQL, connection)
                Using da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        student.DataGridView1.DataSource = dt
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub addStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combobox()
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
End Class