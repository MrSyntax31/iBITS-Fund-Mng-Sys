Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class login

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        Try
            If txtUsername.Text = "admin" Then
                If Not String.IsNullOrEmpty(txtUsername.Text) And
                     Not String.IsNullOrEmpty(txtPassword.Text) Then

                    Dim SQL As String = String.Empty
                    SQL &= "SELECT * FROM admin_tbl"
                    SQL &= " WHERE username = '" & txtUsername.Text & "'"
                    SQL &= " AND password = '" & txtPassword.Text & "'"

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
                    SQL &= " WHERE username = '" & txtUsername.Text & "'"
                    SQL &= " AND password = '" & txtPassword.Text & "'"



                    Dim UserData As DataTable = ExecuteSQL(SQL)

                    If UserData.Rows.Count > 0 Then


                        userAccount.Label5.Text = txtUsername.Text
                        user.Label1.Text = txtUsername.Text
                        txtUsername.Clear()
                        txtPassword.Clear()
                        Me.Hide()
                        user.Show()

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

End Class
