using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using realstate.ListOfAdds;
using realstate.Classes;

namespace realstate
{
    public partial class fileList : Form
    {
       
        public fileList(string query)
        {
           
            InitializeComponent();
            setPreliminaries();
            InitializeDataGridView();
            setDateGridData(JsonConvert.DeserializeObject<List<gridVM>> (query));
        }

        databaseManager manager = new databaseManager();
        FontClass fontclass = new FontClass();
        const int CUSTOM_CONTENT_HEIGHT = 10;
       
        private void setPreliminaries() {
            this.WindowState = FormWindowState.Maximized;
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            foreach (DataGridViewColumn c in listGrid.Columns)
            {
                c.DefaultCellStyle.Font = GlobalVariable.headerlistFONT;
            }
        }
        private void InitializeDataGridView()
        {
            // Initialize basic DataGridView properties.
            listGrid.Dock = DockStyle.Fill;
            listGrid.BackgroundColor = Color.LightGray;
            listGrid.BorderStyle = BorderStyle.Fixed3D;

            Padding newPadding = new Padding(0, 1, 0, CUSTOM_CONTENT_HEIGHT);
            this.listGrid.RowTemplate.DefaultCellStyle.Padding = newPadding;
            this.listGrid.RowTemplate.Height += CUSTOM_CONTENT_HEIGHT;
            this.listGrid.Enabled = true;
            this.listGrid.ReadOnly = false;
            //listGrid.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
            //listGrid.DefaultCellStyle.SelectionForeColor = Color.White;


        }
       
        private void setDateGridData(List<gridVM> list) {

            var bindingList = new BindingList<gridVM>(list);
            var source = new BindingSource(bindingList, null);
            listGrid.DataSource = source;
        }

       

        private void listGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;

            int row = e.RowIndex;

            if (row > -1)

                this.listGrid.Rows[row].Selected = true;
            //if (e.RowIndex != -1)
            //{
            //    listGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Purple;
            //    listGrid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            //}

        }

        private void listGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;

            int row = e.RowIndex;

            if (row > -1)

                this.listGrid.Rows[row].Selected = false;
            //if (e.RowIndex != -1)
            //{
            //    listGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            //    listGrid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Empty;
            //}

        }

        private void listGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = listGrid.Columns[e.ColumnIndex];
            string name = newColumn.Name;

        }
    }
}
