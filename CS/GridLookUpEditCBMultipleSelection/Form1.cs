using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace GridLookUpEditCBMultipleSelection
{
    public partial class Form1 : Form
    {
        GridCheckMarksSelection gridCheckMarksSA;
        GridCheckMarksSelection gridCheckMarksIP;

        public Form1()
        { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = FillDataTable();
            gridLookUpEdit1.Properties.DataSource = dt;
            gridLookUpEdit1.Properties.DisplayMember = "Fruit";
            gridLookUpEdit1.Properties.View.OptionsSelection.MultiSelect = true;
            gridLookUpEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(gridLookUpEdit1_CustomDisplayText);
            gridLookUpEdit1.Properties.PopulateViewColumns();

            repositoryItemGridLookUpEdit1.DataSource = dt;
            repositoryItemGridLookUpEdit1.DisplayMember = "Fruit";
            repositoryItemGridLookUpEdit1.View.OptionsSelection.MultiSelect = true;
            repositoryItemGridLookUpEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(gridLookUpEdit1_CustomDisplayText);
            repositoryItemGridLookUpEdit1.PopulateViewColumns();
            


            gridCheckMarksSA = new GridCheckMarksSelection(gridLookUpEdit1.Properties);
            gridCheckMarksSA.SelectionChanged += new GridCheckMarksSelection.SelectionChangedEventHandler(gridCheckMarks_SelectionChanged);
            gridCheckMarksSA.SelectAll(dt.DefaultView);
            gridLookUpEdit1.Properties.Tag = gridCheckMarksSA;

            gridCheckMarksIP = new GridCheckMarksSelection(repositoryItemGridLookUpEdit1);
            repositoryItemGridLookUpEdit1.Tag = gridCheckMarksIP;
            gridCheckMarksIP.SelectionChanged += new GridCheckMarksSelection.SelectionChangedEventHandler(gridCheckMarks_SelectionChanged);
        }

        void gridCheckMarks_SelectionChanged(object sender, EventArgs e)
        {
            if (ActiveControl is GridLookUpEdit)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataRowView rv in (sender as GridCheckMarksSelection).Selection)
                {
                    if (sb.ToString().Length > 0) { sb.Append(", "); }
                    sb.Append(rv["Fruit"].ToString());
                }
                (ActiveControl as GridLookUpEdit).Text = sb.ToString();
            }            
        }

        void gridLookUpEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            GridCheckMarksSelection gridCheckMark = sender is GridLookUpEdit ? (sender as GridLookUpEdit).Properties.Tag as GridCheckMarksSelection : (sender as RepositoryItemGridLookUpEdit).Tag as GridCheckMarksSelection;
            if (gridCheckMark == null) return;
            foreach (DataRowView rv in gridCheckMark.Selection)
            {
                if (sb.ToString().Length > 0) { sb.Append(", "); }
                sb.Append(rv["Fruit"].ToString());
            }
            e.DisplayText = sb.ToString();
        }

        DataTable FillDataTable()
        {
            DataTable _dataTable = new DataTable();
            DataColumn col;
            DataRow row;

            col = new DataColumn();
            col.ColumnName = "Fruit";
            col.DataType = System.Type.GetType("System.String");
            _dataTable.Columns.Add(col);

            row = _dataTable.NewRow();
            row["Fruit"] = "Peach";
            _dataTable.Rows.Add(row);
            row = _dataTable.NewRow();
            row["Fruit"] = "Apple";
            _dataTable.Rows.Add(row);
            row = _dataTable.NewRow();
            row["Fruit"] = "Banana";
            _dataTable.Rows.Add(row);

            return _dataTable;
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
