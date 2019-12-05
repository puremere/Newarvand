using Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using realstate.Classes;
using System.Drawing.Text;

namespace realstate
{
    public partial class Form3 : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();
        FontClass fontclass = new FontClass();
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        public void initFont()
        {

            byte[] fontData = Properties.Resources.IRANSans_FaNum_;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.IRANSans_FaNum_.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.IRANSans_FaNum_.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            GlobalVariable.headerlistFONT = new Font(fonts.Families[0], 9.0F, System.Drawing.FontStyle.Regular);
            GlobalVariable.headerlistFONTsmall = new Font(fonts.Families[0], 8.0F, System.Drawing.FontStyle.Regular);
            GlobalVariable.headerlistFONTBold = new Font(fonts.Families[0], 11.0F, System.Drawing.FontStyle.Bold);


            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);

        }
        public Form3()
        {
            InitializeComponent();
           
        }
      
        private void Form3_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            username.Text = Settings1.Default.username;
            password.Text = Settings1.Default.password;
            this.CenterToScreen();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            //setfont
            initFont();
        }


        private void confirm_Click(object sender, EventArgs e) {

            if (username.Text == "1" && password.Text == "1")
                backgroundWorker.RunWorkerAsync();
            else
            {

            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string result = "";
            GlobalVariable.token = "9aef7e0f3117d25dc3cdae90b83111d5";
            try
            {
                using (WebClient client = new WebClient())
                {
                    var collection = new System.Collections.Specialized.NameValueCollection();
                    collection.Add("token", "9aef7e0f3117d25dc3cdae90b83111d5");
                    byte[] response =
                    client.UploadValues("http://arvandfile.com/api/v1/getCats&Areas.php", collection);

                    result = System.Text.Encoding.UTF8.GetString(response);
                    CatsAndAreasObject CATS = new CatsAndAreasObject();
                    CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(result);
                    if (CATS.result != null)
                    {

                        GlobalVariable.newCatsAndAreas = result;
                        GlobalVariable.isadmin = "1";
                      
                    }
                   

                }


                //this.Close();
            }
            catch (Exception)
            {
               // loadingIMG.Visible = false;
                backgroundWorker.CancelAsync();
            }
        }
        
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // handle the error
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("خطا در ارتباط با سرور، لطفاً مجدداً تلاش کنید");
            }
            else
            {
                main main = new main();
                main.Show();
                this.Visible = false;
                // use it on the UI thread
            }
        }











    }
}
