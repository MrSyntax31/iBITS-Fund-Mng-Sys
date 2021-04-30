Imports System.Data.SqlClient
Public Class content

    Public Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showdata()
        Timer1.Start()

    End Sub
    Public Sub showdata()
        Dim conn As New SqlConnection("Data Source=ARLLAN_PSIX;Initial Catalog=malayan;Integrated Security=True")
        conn.Open()


        Dim thirdyear As New SqlCommand("select count(*) from student_tbl where yearlevel = 3", conn)
        Dim countthirdyear = Convert.ToString(thirdyear.ExecuteScalar)
        Label5.Text = countthirdyear

        Dim secondyear As New SqlCommand("select count(*) from student_tbl where yearlevel = 2", conn)
        Dim countsecond = Convert.ToString(secondyear.ExecuteScalar)
        Label4.Text = countsecond

        Dim firstyear As New SqlCommand("select count(*) from student_tbl where yearlevel = 1", conn)
        Dim countfirst = Convert.ToString(firstyear.ExecuteScalar)
        Label8.Text = countfirst

        Dim fourthyear As New SqlCommand("select count(*) from student_tbl where yearlevel = 4", conn)
        Dim countforth = Convert.ToString(fourthyear.ExecuteScalar)
        Label10.Text = countforth

        Dim firstyearBS As New SqlCommand("select count(*) from student_tbl where courseID = 1 AND yearlevel = 1", conn)
        Dim counthBS = Convert.ToString(firstyearBS.ExecuteScalar)
        Label12.Text = counthBS

        Dim firstyearDI As New SqlCommand("select count(*) from student_tbl where courseID = 2 AND yearlevel = 1", conn)
        Dim counthDI = Convert.ToString(firstyearDI.ExecuteScalar)
        Label13.Text = counthDI

        Dim firstyearDE As New SqlCommand("select count(*) from student_tbl where courseID = 3 AND yearlevel = 1", conn)
        Dim counthDE = Convert.ToString(firstyearDE.ExecuteScalar)
        Label18.Text = counthDE

        Dim secondBS As New SqlCommand("select count(*) from student_tbl where courseID = 1 AND yearlevel = 2", conn)
        Dim countBS = Convert.ToString(secondBS.ExecuteScalar)
        Label24.Text = countBS

        Dim secondDI As New SqlCommand("select count(*) from student_tbl where courseID = 2 AND yearlevel = 2", conn)
        Dim countDI = Convert.ToString(secondDI.ExecuteScalar)
        Label23.Text = countDI

        Dim secondDC As New SqlCommand("select count(*) from student_tbl where courseID = 3 AND yearlevel = 2", conn)
        Dim countDC = Convert.ToString(secondDC.ExecuteScalar)
        Label19.Text = countDC

        Dim thirdBS As New SqlCommand("select count(*) from student_tbl where courseID = 1 AND yearlevel = 3", conn)
        Dim counttBS = Convert.ToString(thirdBS.ExecuteScalar)
        Label30.Text = counttBS

        Dim thirdDI As New SqlCommand("select count(*) from student_tbl where courseID = 2 AND yearlevel = 3", conn)
        Dim counttDI = Convert.ToString(thirdDI.ExecuteScalar)
        Label29.Text = counttDI

        Dim thirdDC As New SqlCommand("select count(*) from student_tbl where courseID = 3 AND yearlevel = 3", conn)
        Dim counttDC = Convert.ToString(thirdDC.ExecuteScalar)
        Label25.Text = counttDC

        Dim fourthBS As New SqlCommand("select count(*) from student_tbl where courseID = 1 AND yearlevel = 4", conn)
        Dim countfBS = Convert.ToString(fourthBS.ExecuteScalar)
        Label32.Text = countfBS


        Dim collected As New SqlCommand("SELECT sum(misc_tbl.misc_amount) FROM misc_tbl INNER JOIN paymentHistory ON misc_tbl.misc_ID = paymentHistory.misc_ID WHERE  misc_status = 'Paid'", conn)
        Dim collectedcount = Convert.ToString(collected.ExecuteScalar)
        Label6.Text = collectedcount

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