Public NotInheritable Class SplashScreen1
    Private iProgressBarValue As Integer = 0


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        ''Copyright info
        'Copyright.Text = My.Application.Info.Copyright
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 1000
        ProgressBar1.Value = 0
        Timer1.Enabled = True
        Timer1.Interval = 300
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        iProgressBarValue += 1
        Select Case iProgressBarValue
            Case 1, 3, 5, 7, 9
                ProgressBar1.ForeColor = Color.White
                ProgressBar1.Value = (iProgressBarValue * 100)
            Case 2, 4, 6, 8, 10
                ProgressBar1.Value = (iProgressBarValue * 100)
            Case 13
                Timer1.Stop()
                Timer1.Enabled = False
                login.Show()
                Me.Close()
        End Select

    End Sub
End Class
