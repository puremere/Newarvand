using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

using System.Runtime.InteropServices;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Management;

using System.Net.Sockets;
using System.Security.Cryptography;
using System.Drawing.Text;
using System.Globalization;
using Telerik.WinControls.Layouts;

using realstate.Classes;





namespace realstate
{


    public partial class main : Form
    {

        FontClass fontclass = new FontClass();
       
        public main()
        {
           
            InitializeComponent();
          
        }

        private void addfileBotton_Click(object sender, EventArgs e)
        {
            manageFile managefile = new manageFile();
            managefile.Show();
        }

        private void getDateForm_Click(object sender, EventArgs e)
        {
            getData getdata = new getData();
            getdata.Show();
           
        }

        private void searchFiltButt_Click(object sender, EventArgs e)
        {

            search srch = new search();
            srch.Show();
            //fileList filelist = new fileList();
            //filelist.Show();
        }

        private void main_Load(object sender, EventArgs e)
        {
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            this.CenterToScreen();
            dataLable.Text = dateTimeConvert.ToPersianDateString(DateTime.Now);

        }
    }
}