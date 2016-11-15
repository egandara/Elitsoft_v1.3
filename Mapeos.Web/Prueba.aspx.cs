using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mapeos.Web
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            string csv_Excel_Path = Server.MapPath("~/csv_files/MobileInfo.xls");
            Import_ExcelData_To_Grid(csv_Excel_Path, ".xlsx", "Yes");
        }

        private void Import_ExcelData_To_Grid(string FilePath, string Extension, string isHDR)
        {

            string conStr = ConfigurationManager.ConnectionStrings["Excel07_ConStr"].ConnectionString;

            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection myExcelConn = new OleDbConnection(conStr);
            OleDbCommand myExcelCmd = new OleDbCommand();
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();
            DataTable mydt = new DataTable();
            myExcelCmd.Connection = myExcelConn;
            myExcelConn.Open();

            DataTable dtExcelSchema;
            dtExcelSchema = myExcelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            //Fetch the name of First Sheet
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            myExcelConn.Close();

            //Read Data from First Sheet
            myExcelConn.Open();
            myExcelCmd.CommandText = "SELECT * From [" + SheetName + "]";
            myDataAdapter.SelectCommand = myExcelCmd;
            myDataAdapter.Fill(mydt);
            myExcelConn.Close();

            //  save datatable in a session which we used for pagination
            Session.Add("mySessionTable", mydt);

            //Bind mySessionTable to gridview control
            gvPruebas.DataSource = (DataTable)Session["mySessionTable"];
            gvPruebas.DataBind();
        }

        protected void gvPruebas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPruebas.PageIndex = e.NewPageIndex;
            if (Session["mySessionTable"] != null)
            {
                gvPruebas.DataSource = (DataTable)Session["mySessionTable"];
                gvPruebas.DataBind();
            }
        }
    }
}