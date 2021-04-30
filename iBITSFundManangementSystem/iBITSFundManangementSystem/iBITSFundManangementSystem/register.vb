Public Class register
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        login.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim btn As MessageBoxButtons = MessageBoxButtons.OK
        Dim ico As MessageBoxIcon = MessageBoxIcon.Information
        Dim caption As String = "Malayan"
        Try
            If String.IsNullOrEmpty(TextBox1.Text) Then
                MessageBox.Show("Please Enter Username.", caption, btn, ico)
                TextBox1.Select()
                Return
            End If

            If String.IsNullOrEmpty(TextBox2.Text) Then
                MessageBox.Show("Please Enter Password.", caption, btn, ico)
                TextBox2.Select()
                Return
            End If

            If String.IsNullOrEmpty(TextBox3.Text) Then
                MessageBox.Show("Please Re-Enter Password.", caption, btn, ico)
                TextBox3.Select()
                Return
            End If

            If String.IsNullOrEmpty(TextBox4.Text) Then
                MessageBox.Show("Please Enter School ID.", caption, btn, ico)
                TextBox4.Select()
                Return
            End If

            If TextBox2.Text <> TextBox3.Text Then

                MessageBox.Show("Passwords do not match", caption, btn, ico)
                TextBox3.Select()

                Exit Sub
            End If
            Dim checkdupsUser As DataTable = ExecuteSQL("SELECT username FROM login_tbl WHERE username = '" & TextBox1.Text & "'")

            If checkdupsUser.Rows.Count > 0 Then

                MessageBox.Show("Username already exists. Please try another username", caption, btn, ico)
                TextBox1.Focus()
                Return
            End If
            Dim checkdupsID As DataTable = ExecuteSQL("SELECT StudentID FROM login_tbl WHERE StudentID= '" & TextBox4.Text & "'")

            If checkdupsID.Rows.Count > 0 Then

                MessageBox.Show("You already have an account. Please confirm Student ID", caption, btn, ico)
                TextBox4.Focus()

                Return
            End If

            Dim checkdupsRegister As DataTable = ExecuteSQL("SELECT StudentID FROM student_tbl WHERE StudentID= '" & TextBox4.Text & "'")

            If checkdupsRegister.Rows.Count > 0 Then

                Dim SQL As String = String.Empty

                SQL &= "Insert INTO login_tbl (StudentID,username,password)"
                SQL &= " VALUES ('" & TextBox4.Text & "', '" & TextBox1.Text & "', '" & TextBox2.Text & "')"

                ExecuteSQL(SQL)

                MessageBox.Show("Account Succesfully Created")

                For Each tbox As TextBox In Me.Controls.OfType(Of TextBox)()
                    tbox.Text = String.Empty
                Next

            Else
                MessageBox.Show("STUDENT NOT FOUND")

            End If

        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    'Private Sub txtusernameR_valid(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
    '    If String.IsNullOrEmpty(TextBox1.Text.Trim) Then
    '        ErrorProvider1.SetError(TextBox1, "Password is required.")
    '    Else
    '        ErrorProvider1.SetError(TextBox1, String.Empty)
    '    End If
    'End Sub

    'Private Sub txtPassR_valid(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating
    '    If String.IsNullOrEmpty(TextBox2.Text.Trim) Then
    '        ErrorProvider1.SetError(TextBox2, "Password is required.")
    '    Else
    '        ErrorProvider1.SetError(TextBox2, String.Empty)
    '    End If
    'End Sub

    'Private Sub txtCPassR_valid(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox3.Validating
    '    If String.IsNullOrEmpty(TextBox3.Text.Trim) Then
    '        ErrorProvider1.SetError(TextBox3, "Password is required.")
    '    Else
    '        ErrorProvider1.SetError(TextBox3, String.Empty)
    '    End If
    'End Sub

    'Private Sub txtSchoolIDR_valid(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox4.Validating
    '    If String.IsNullOrEmpty(TextBox4.Text.Trim) Then
    '        ErrorProvider1.SetError(TextBox4, "Password is required.")
    '    Else
    '        ErrorProvider1.SetError(TextBox4, String.Empty)
    '    End If
    'End Sub
End Class