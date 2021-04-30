Imports System.Data.SqlClient
Public Class content

    Public Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showdata()
        Timer1.Start()

    End Sub
    Public Sub showdata()
        Dim conn As New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
        conn.Open()

        Dim population As New SqlCommand("select count(*) from student_tbl", conn)
        Dim countpopu = Convert.ToString(population.ExecuteScalar)
        Label6.Text = countpopu

        Dim thirdyear As New SqlCommand("select count(*) from student_tbl where yearlevel = 3", conn)
        Dim countthirdyear = Convert.ToString(thirdyear.ExecuteScalar)
        Label5.Text = countthirdyear

        Dim secondyear As New SqlCommand("select count(*) from student_tbl where yearlevel = 2", conn)
        Dim countsecond = Convert.ToString(secondyear.ExecuteScalar)
        Label4.Text = countsecond

        Dim firstyear As New SqlCommand("select count(*) from student_tbl where yearlevel = 1", conn)
        Dim countfirst = Convert.ToString(firstyear.ExecuteScalar)
        Label8.Text = countfirst

        conn.Close()
    End Sub

    Private Sub Menu_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Panel1.Left = (Me.Width - Panel1.Width) / 2
    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        showdata()
    End Sub
End Class