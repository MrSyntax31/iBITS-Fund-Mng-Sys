Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class printPayment
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cryRpt As New ReportDocument
        cryRpt.Load("C:\Users\HP\Downloads\iBITSFundManangementSystem\iBITSFundManangementSystem\iBITSFundManangementSystem\CrystalReport1.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub printPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class