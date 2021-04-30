Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class transactionreport
    Private Sub Button1_Click(ByVal sender As System.Object,
    ByVal e As System.EventArgs) Handles Button1.Click
        Dim cryRpt As New ReportDocument
        cryRpt.Load("C:\Users\HP\Downloads\iBITSFundManangementSystem\iBITSFundManangementSystem\iBITSFundManangementSystem\CrystalReport1.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub transactionreport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class