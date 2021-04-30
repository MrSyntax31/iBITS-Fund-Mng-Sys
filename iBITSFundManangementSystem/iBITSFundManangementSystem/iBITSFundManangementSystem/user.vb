Imports System.Data.SqlClient
Public Class user
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        login.Show()
        payment.ComboBox1.Text = String.Empty


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With userProfile
            .TopLevel = False
            Panel5.Controls.Add(userProfile)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With userAccount
            .TopLevel = False
            Panel5.Controls.Add(userAccount)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        printPayment.Show()
        ' Me.Hide()
        'payment.showPaymentHistory()

        printPayment.CrystalReportViewer1.ReportSource = Application.StartupPath + "\CrystalReport4.rpt"
        printPayment.CrystalReportViewer1.SelectionFormula = "{login_tbl.userID} = " & Label4.Text.ToString() & ""
        printPayment.CrystalReportViewer1.Refresh()
        printPayment.CrystalReportViewer1.RefreshReport()
        'Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With userDashboard
            .TopLevel = False
            Panel5.Controls.Add(userDashboard)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With payment
            .TopLevel = False
            Panel5.Controls.Add(payment)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        schoolID()
        userDashboard.balance()
        userID()


    End Sub
    Public Sub schoolID()
        Using con As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand("Select StudentID from login_tbl where username = '" & Label1.Text & "'", con)
                Using da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    Using dt As New DataTable
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Label2.Text = dt.Rows(0)(0).ToString
                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Public Sub userID()
        Using con As SqlConnection = New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand("Select userID from login_tbl where username = '" & Label1.Text & "'", con)
                Using da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    Using dt As New DataTable
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Label4.Text = dt.Rows(0)(0).ToString
                        End If
                    End Using
                End Using
            End Using
        End Using


    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With about
            .TopLevel = False
            Panel5.Controls.Add(about)
            .BringToFront()
            .Show()
        End With
    End Sub


End Class