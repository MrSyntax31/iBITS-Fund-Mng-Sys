Imports System.Data.SqlClient
Public Class userAccount
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim btn As MessageBoxButtons = MessageBoxButtons.OK
        Dim ico As MessageBoxIcon = MessageBoxIcon.Information
        Dim caption As String = "Malayan"
        Try
            If String.IsNullOrEmpty(TextBox1.Text) Then
                MessageBox.Show("Please Enter Old Password.", caption, btn, ico)
                TextBox1.Select()
                Return
            End If

            If String.IsNullOrEmpty(TextBox2.Text) Then
                MessageBox.Show("Please Enter New Password.", caption, btn, ico)
                TextBox2.Select()
                Return
            End If

            If String.IsNullOrEmpty(TextBox3.Text) Then
                MessageBox.Show("Please Confirm Password.", caption, btn, ico)
                TextBox3.Select()
                Return
            End If
            If TextBox2.Text <> TextBox3.Text Then

                MessageBox.Show("Passwords do not match", caption, btn, ico)
                TextBox3.Select()
                Return
            End If

            Dim SQL As String = String.Empty

            SQL &= "UPDATE login_tbl SET password = '" & TextBox2.Text & "' WHERE username = '" & Label5.Text & "' "

            ExecuteSQL(SQL)

            MessageBox.Show("Password Succesfully Changed")

            For Each tbox As TextBox In Me.Controls.OfType(Of TextBox)()
                tbox.Text = String.Empty
            Next
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Public Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class