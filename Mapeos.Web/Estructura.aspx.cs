using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mapeos.Web
{
    public partial class Estructura : System.Web.UI.Page
    {
        private static int numOfRows = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateTable(numOfRows);
            }
        }

        private void GenerateTable(int rowsCount)
        {
            //Creat the Table and Add it to the Page
            Table table = new Table();
            table.ID = "Table1";
            Page.Form.Controls.Add(table);

            const int colsCount = 7;

            for (int i = 0; i < rowsCount; i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < colsCount; j++)
                {
                    TableCell cell = new TableCell();
                    TextBox tb = new TextBox();
                    CheckBox chk = new CheckBox();
                    DropDownList ddl = new DropDownList();
                    Button btn = new Button();

                    tb.ID = "TextBoxRow_" + i + "Col_" + j;
                    chk.ID = "CheckBoxRow_" + i + "Col_" + j;
                    ddl.ID = "DropDownListRow_" + i + "Col_" + j;
                    btn.ID = "Button_" + i + "Col_" + j;

                    switch (j)
                    {
                        case 0:
                            cell.Controls.Add(tb);
                            row.Cells.Add(cell);
                            tb.Text = (i + 1).ToString();
                            break;
                        case 1:
                            cell.Controls.Add(tb);
                            row.Cells.Add(cell);
                            break;
                        case 2:
                            cell.Controls.Add(ddl);
                            ddl.Items.Insert(0, "--Tipo de dato--");
                            ddl.Items.Insert(1, "Varchar");
                            ddl.Items.Insert(2, "Int");
                            ddl.Items.Insert(3, "Char");
                            row.Cells.Add(cell);
                            break;
                        case 3:
                            cell.Controls.Add(chk);
                            row.Cells.Add(cell);
                            break;
                        case 4:
                            cell.Controls.Add(tb);
                            row.Cells.Add(cell);
                            break;
                        case 5:
                            cell.Controls.Add(tb);
                            row.Cells.Add(cell);
                            break;
                        case 6:
                            cell.Controls.Add(btn);
                            row.Cells.Add(cell);
                            break;
                        case 7:
                            cell.Controls.Add(btn);
                            row.Cells.Add(cell);
                            break;
                    }

                    
                }

                miTabla.Rows.Add(row);
            }

            SetPreviousData(rowsCount, colsCount);

            rowsCount++;
            ViewState["RowsCount"] = rowsCount;
        }
        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ViewState["RowsCount"] != null)
            {
                numOfRows = Convert.ToInt32(ViewState["RowsCount"].ToString());
                GenerateTable(numOfRows);
            }
            numOfRows++;
        }

        private void SetPreviousData(int rowsCount, int colsCount)
        {
            Table table = (Table)Page.FindControl("Table1");
            if (table != null)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    for (int j = 0; j < colsCount; j++)
                    {
                        TextBox tb = (TextBox)table.Rows[i].Cells[j].FindControl("TextBoxRow_" + i + "Col_" + j);
                        
                        tb.Text = Request.Form["TextBoxRow_" + i + "Col_" + j];
                    }
                }
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            TableRow rw = miTabla.Rows[miTabla.Rows.Count - 1];
            miTabla.Rows.Remove(rw);
            miTabla.Visible = true;
            numOfRows--;
            GenerateTable(numOfRows);
        }
    }
}