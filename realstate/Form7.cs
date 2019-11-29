using Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace realstate
{
    public partial class Form7 : Form
    {
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
        public static float width = 0;
       
        public Form7()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            //add.Font = GlobalVariable.headerlistFONT;
            label2.Font = GlobalVariable.headerlistFONT;
            label5.Font = GlobalVariable.headerlistFONT;
            label26.Font = GlobalVariable.headerlistFONT;
            label27.Font = GlobalVariable.headerlistFONT;
            //   label28.Font = GlobalVariable.headerlistFONT;
            width = ClientRectangle.Width;
            radListView1.Height = flowLayoutPanel1.Height - 90;
            flowLayoutPanel1.Width = (int)width;
            tableLayoutPanel6.Width = (int)width - (Width * 3) / 100;
            radListView1.Width = (int)width - (Width * 3) / 100;
            string allobject = "";
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(directory, "Arvand", "objects.txt");
            if (System.IO.File.Exists(path) == false)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {

                }
            }
            using (StreamReader sr = new StreamReader(path, true))
            {

                allobject = sr.ReadToEnd();

            }
            List<ListOfAdds.Datum> list = new List<ListOfAdds.Datum>();
            List<ListOfAdds.Datum> list2 = new List<ListOfAdds.Datum>();
            ListOfAdds.Datum obj = new ListOfAdds.Datum();
            try
            {
                list2 = JsonConvert.DeserializeObject<List<ListOfAdds.Datum>>(allobject);

            }
            catch (Exception error)
            {
                obj = JsonConvert.DeserializeObject<ListOfAdds.Datum>(allobject);
            }

            if (list2 != null)
            {
                foreach (var item in list2)
                {
                    list.Add(item);
                }
                if (list.Count > 0)
                {

                    
                    radListView1.DataSource = ConvertToDataTable(list);
                    this.radListView1.ValueMember = "ID";
                    radListView1.ViewType = ListViewType.DetailsView;
                    radListView1.ShowColumnHeaders = false;
                    radListView1.Columns["title"].Width = this.radListView1.Size.Width - this.radListView1.ListViewElement.BorderWidth * 2 - 30;

                    // radListView1.Columns["title"].
                    radListView1.ItemSize = new Size(0, 33);
                }


            }



        }
        void radListView1_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        {

            e.VisualItem.SetThemeValueOverride(LightVisualElement.NumberOfColorsProperty, 1, "RadListVisualItem.ContainsMouse.MouseOver");
            e.VisualItem.SetThemeValueOverride(LightVisualElement.BackColorProperty, Color.LightBlue, "RadListVisualItem.ContainsMouse.MouseOver");
            if (e.VisualItem.Selected == true)
            {
                e.VisualItem.BackColor = Color.Transparent;
                e.VisualItem.NumberOfColors = 1;
                e.VisualItem.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                e.VisualItem.BorderColor = Color.White;
            }

            else
            {
                e.VisualItem.BackColor = Color.Transparent;
                //    e.VisualItem.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                //    e.VisualItem.ResetValue(LightVisualElement.NumberOfColorsProperty, Telerik.WinControls.ValueResetFlags.Local);
                //    e.VisualItem.ResetValue(LightVisualElement.GradientStyleProperty, Telerik.WinControls.ValueResetFlags.Local);
                //
            }

        }


        private void radListView1_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
        {
            DetailListViewDataCellElement cell = e.CellElement as DetailListViewDataCellElement;
            if (cell != null)
            {
                cell.BackColor = Color.White;
                cell.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                //  cell.Margin = new Padding(0, 10, 0, 10);
                cell.BorderColor = Color.White;

                // DataRowView productRowView = cell.Row.DataBoundItem as DataRowView;
                //if (productRowView != null && (bool)productRowView.Row["title"] == true)
                //{
                //    e.CellElement.BackColor = Color.Yellow;
                //    e.CellElement.ForeColor = Color.Red;
                //    e.CellElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                //    //e.CellElement.Font = newFont;
                //}
                //else
                //{
                //    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                //    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                //    e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, Telerik.WinControls.ValueResetFlags.Local);
                //    e.CellElement.ResetValue(LightVisualElement.FontProperty, Telerik.WinControls.ValueResetFlags.Local);
                //}
            }
        }
        
        private void radListView1_DoubleClick(object sender, EventArgs e)
        {
            GlobalVariable.fromwhere = "sub";
            GlobalVariable.selectedOwnObject = new ListOfAdds.Datum();
            string allobject = "";
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(directory, "Arvand", "objects.txt");
            if (System.IO.File.Exists(path) == false)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {

                }
            }
            using (StreamReader sr = new StreamReader(path, true))
            {

                allobject = sr.ReadToEnd();

            }
            List<ListOfAdds.Datum> list = new List<ListOfAdds.Datum>();
            List<ListOfAdds.Datum> list2 = new List<ListOfAdds.Datum>();
            ListOfAdds.Datum obj = new ListOfAdds.Datum();
            try
            {
                list2 = JsonConvert.DeserializeObject<List<ListOfAdds.Datum>>(allobject);

            }
            catch (Exception)
            {
                obj = JsonConvert.DeserializeObject<ListOfAdds.Datum>(allobject);
            }

            if (list2 != null)
            {
                foreach (var item in list2)
                {
                    list.Add(item);
                }
            }

            string selectedindex = radListView1.SelectedItem.Value.ToString();
            ListOfAdds.Datum selected = list.Where(x => x.ID == selectedindex).FirstOrDefault();

            GlobalVariable.selectedOwnObject = selected;
            manageFile form6 = new manageFile();
            form6.Show();



        }

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
        //   // string search = searchTextBox.Text;
        //    string filepath = Path.Combine(Application.StartupPath, "Resources", "objects.txt");
        //    string allobject = System.IO.File.ReadAllText(filepath);
        //    List<ListOfAdds.Datum> list = new List<ListOfAdds.Datum>();
        //    List<ListOfAdds.Datum> list2 = new List<ListOfAdds.Datum>();
        //    ListOfAdds.Datum obj = new ListOfAdds.Datum();
        //    try
        //    {
        //        list2 = JsonConvert.DeserializeObject<List<ListOfAdds.Datum>>(allobject);

        //    }
        //    catch (Exception)
        //    {
        //        obj = JsonConvert.DeserializeObject<ListOfAdds.Datum>(allobject);
        //    }

        //    if (list2 != null)
        //    {
        //        foreach (var item in list2)
        //        {
        //            list.Add(item);
        //        }
        //    }

        //    List<ListOfAdds.Datum> selected = list.Where(x => x.title.Contains(search)).Select(x => x).ToList();
        //    this.radListView1.VisualItemFormatting += new Telerik.WinControls.UI.ListViewVisualItemEventHandler(radListView1_VisualItemFormatting);
        //    this.radListView1.CellCreating += new Telerik.WinControls.UI.ListViewCellElementCreatingEventHandler(radListView1_CellCreating);
        //    this.radListView1.ColumnCreating += new ListViewColumnCreatingEventHandler(radListView1_ColumnCreating);

        //    this.radListView1.CellFormatting += new Telerik.WinControls.UI.ListViewCellFormattingEventHandler(radListView1_CellFormatting);

        //    radListView1.DataSource = ConvertToDataTable(selected);
        //    this.radListView1.ValueMember = "server_id";
        //    radListView1.ViewType = ListViewType.DetailsView;
        //    radListView1.ShowColumnHeaders = false;
        //    radListView1.Columns["title"].Width = this.radListView1.Size.Width - this.radListView1.ListViewElement.BorderWidth * 2 - 30;

        //    // radListView1.Columns["title"].
        //    radListView1.ItemSize = new Size(0, 100);

        //}



        public void getdata()
        {
            string allobject = "";
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(directory, "Arvand", "objects.txt");
            if (System.IO.File.Exists(path) == false)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {

                }
            }
            using (StreamReader sr = new StreamReader(path, true))
            {

                allobject = sr.ReadToEnd();

            }

            List<ListOfAdds.Datum> list = new List<ListOfAdds.Datum>();
            List<ListOfAdds.Datum> list2 = new List<ListOfAdds.Datum>();
            ListOfAdds.Datum obj = new ListOfAdds.Datum();
            try
            {
                list2 = JsonConvert.DeserializeObject<List<ListOfAdds.Datum>>(allobject);

            }
            catch (Exception)
            {
                obj = JsonConvert.DeserializeObject<ListOfAdds.Datum>(allobject);
            }
            foreach (var item in list2)
            {
                list.Add(item);
            }
          
            this.radListView1.ValueMember = "ID";
            radListView1.ViewType = ListViewType.DetailsView;
            radListView1.ShowColumnHeaders = false;
            radListView1.Columns["title"].Width = this.radListView1.Size.Width - this.radListView1.ListViewElement.BorderWidth * 2 - 30;

            // radListView1.Columns["title"].
            radListView1.ItemSize = new Size(0, 100);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            getdata();
        }



        private void add_Click(object sender, EventArgs e)
        {
            manageFile form = new manageFile();
            GlobalVariable.selectedOwnObject = null;
            form.Show();
            this.Dispose();
        }



        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radListView1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
