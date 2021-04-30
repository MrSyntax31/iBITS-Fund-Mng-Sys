Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class login

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userProfile.datatotextprofile()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Hide()
        register.Show()


    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        txtPassword.Multiline = False


    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            Exit Sub
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        txtUsername.Multiline = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim emptyTextBoxes =
        '        From txt In Me.Controls.OfType(Of TextBox)()
        '        Where txt.Text.Length = 0
        '        Select txt.Name
        'If emptyTextBoxes.Any Then
        '    MessageBox.Show(String.Format("Please fill the following textboxes: {0}",
        '            String.Join(",", emptyTextBoxes)))
        'End If

        If String.IsNullOrEmpty(txtUsername.Text) OrElse String.IsNullOrEmpty(txtPassword.Text) Then
            MsgBox("Please Enter Username and Password!")
            Exit Sub
        End If
 


        Try
            If txtUsername.Text = "admin" Then
                If Not String.IsNullOrEmpty(txtUsername.Text) And
                     Not String.IsNullOrEmpty(txtPassword.Text) Then


                    Dim SQL As String = String.Empty
                    SQL &= "SELECT * FROM admin_tbl"
                    SQL &= " WHERE username = '" & txtUsername.Text & "'COLLATE SQL_Latin1_General_CP1_CS_AS"
                    SQL &= " AND password = '" & txtPassword.Text & "'COLLATE SQL_Latin1_General_CP1_CS_AS"

                    Dim UserData As DataTable = ExecuteSQL(SQL)

                    If UserData.Rows.Count > 0 Then

                        account.Label2.Text = txtUsername.Text
                        txtUsername.Clear()
                        txtPassword.Clear()

                        Me.Hide()
                        Dashboard.Show()


                    Else
                        MsgBox("Username/Password is Incorrect!", MsgBoxStyle.Critical, "Malayan")
                        txtUsername.Focus()
                        txtUsername.SelectAll()

                    End If
                Else
                    MsgBox("Please Enter Username and Password", MsgBoxStyle.Critical, "Malayan")
                    txtUsername.Select()
                End If
            Else
                If Not String.IsNullOrEmpty(txtUsername.Text) And
                     Not String.IsNullOrEmpty(txtPassword.Text) Then

                    Dim SQL As String = String.Empty
                    SQL &= "SELECT * FROM login_tbl"
                    SQL &= " WHERE username = '" & txtUsername.Text & "'COLLATE SQL_Latin1_General_CP1_CS_AS"
                    SQL &= " AND password = '" & txtPassword.Text & "'COLLATE SQL_Latin1_General_CP1_CS_AS"


                    Dim UserData As DataTable = ExecuteSQL(SQL)

                    If UserData.Rows.Count > 0 Then


                        userAccount.Label5.Text = txtUsername.Text
                        user.Label1.Text = txtUsername.Text
                        txtUsername.Clear()
                        txtPassword.Clear()
                        Me.Hide()
                        user.Show()
                        user.schoolID()
                        user.userID()


                    Else
                        MsgBox("Username/Password is Incorrect!", MsgBoxStyle.Critical, "Malayan")
                        txtUsername.Focus()
                        txtUsername.SelectAll()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub txtUsername_valid(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtUsername.Validating
        If String.IsNullOrEmpty(txtUsername.Text.Trim) Then
            ErrorProvider1.SetError(txtUsername, "Username is required.")
        Else
            ErrorProvider1.SetError(txtUsername, String.Empty)
        End If
    End Sub

    Private Sub txtPassword_valid(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPassword.Validating
        If String.IsNullOrEmpty(txtPassword.Text.Trim) Then
            ErrorProvider1.SetError(txtPassword, "Password is required.")
        Else
            ErrorProvider1.SetError(txtPassword, String.Empty)
        End If
    End Sub

End Class
