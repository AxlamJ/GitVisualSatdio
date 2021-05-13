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

namespace invetory_managament.Product_Report
{
    public partial class Product_Reports : System.Web.UI.Page
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
            ReportDataSource rds = new ReportDataSource("DataSetProduct", ds.Tables[0]);
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(rds);

        }
        private DataSet GetDataSet()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["invetory_managamentConnectionString"].ConnectionString);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Product", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            conn.Close();
            return ds;
        }


    }
}