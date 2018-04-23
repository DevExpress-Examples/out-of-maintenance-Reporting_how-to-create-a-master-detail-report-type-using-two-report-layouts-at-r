using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace MasterDetailReportLoadedFromRepx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XtraReport report = new XtraReport();
            XtraReport subreport = new XtraReport();

            report.LoadLayout(Application.StartupPath + "\\MainReport.repx");
            subreport.LoadLayout(Application.StartupPath + "\\SubReport.repx");
            ((XRSubreport)report.FindControl("xrSubreport1", true)).ReportSource = subreport;
            ((XRSubreport)report.FindControl("xrSubreport1", true)).BeforePrint += new System.Drawing.Printing.PrintEventHandler(Form1_BeforePrint);
            report.ShowPreview();            

        }

        void Form1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {       
            ((XRSubreport)sender).ReportSource.FilterString = "[CategoryID] = " + Convert.ToInt32(((XRSubreport)sender).Report.GetCurrentColumnValue("CategoryID")).ToString();
        }
    }
}