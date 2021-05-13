using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace invetory_managament.SalesReports
{
    public partial class SalesReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            RefreshReport();
        }
        private void RefreshReport()
        {
            DataSet ds = GetDataSet();
            ReportDataSource rds = new ReportDataSource("SaleDataSet", ds.Tables[0]);
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
        
        }
        private DataSet GetDataSet()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["invetory_managamentConnectionString"].ConnectionString);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Sale", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            conn.Close();
            return ds;
        }
    }
}