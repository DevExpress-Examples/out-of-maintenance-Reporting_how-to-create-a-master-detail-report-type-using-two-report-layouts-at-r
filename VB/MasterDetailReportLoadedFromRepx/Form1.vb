Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI

Namespace MasterDetailReportLoadedFromRepx
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim report As New XtraReport()
			Dim subreport As New XtraReport()

			report.LoadLayout(Application.StartupPath & "\MainReport.repx")
			subreport.LoadLayout(Application.StartupPath & "\SubReport.repx")
			CType(report.FindControl("xrSubreport1", True), XRSubreport).ReportSource = subreport
			AddHandler (CType(report.FindControl("xrSubreport1", True), XRSubreport)).BeforePrint, AddressOf Form1_BeforePrint
			report.ShowPreview()

		End Sub

		Private Sub Form1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
			CType(sender, XRSubreport).ReportSource.FilterString = "[CategoryID] = " & Convert.ToInt32((CType(sender, XRSubreport)).Report.GetCurrentColumnValue("CategoryID")).ToString()
		End Sub
	End Class
End Namespace