Public Class Dashboard
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With content
            .TopLevel = False
            Panel5.Controls.Add(content)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With student
            .TopLevel = False
            Panel5.Controls.Add(student)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With transaction
            .TopLevel = False
            Panel5.Controls.Add(transaction)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With account
            .TopLevel = False
            Panel5.Controls.Add(account)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        With about
            .TopLevel = False
            Panel5.Controls.Add(about)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        login.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With announcement
            .TopLevel = False
            Panel5.Controls.Add(announcement)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class