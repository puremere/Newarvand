using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using realstate.ListOfAdds;
using realstate.Classes;
namespace realstate
{
    public partial class getData : Form
    {

        databaseManager manager = new databaseManager();
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        FontClass fontclass = new FontClass();
        functions classobj = new functions(); 
        public getData()
        {
            InitializeComponent();
        }
        private void getData_Load(object sender, EventArgs e)
        {

            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            dopreliminaries();
        }

        private void getDataVerify_Click(object sender, EventArgs e)
        {
            item newitem = new item();
            string result = "";
            
            using (WebClient client = new WebClient())
            {
                var collection = new System.Collections.Specialized.NameValueCollection();
                collection.Add("token", "9aef7e0f3117d25dc3cdae90b83111d5");

                collection.Add("limit", "1000");

                //  string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
                byte[] response =
                client.UploadValues("http://arvandfile.com/api/v1/listOfFiles.php", collection);

                result = System.Text.Encoding.UTF8.GetString(response);
                ListOfAdds.RootObject log = JsonConvert.DeserializeObject<ListOfAdds.RootObject>(result);
                foreach (var file in log.result.data)
                {


                    newitem.phones = file.phones;
                    newitem.address = file.address;

                    newitem.anbari1 = file.anbari1;
                    newitem.anbari2 = file.anbari2;
                    newitem.anbari3 = file.anbari3;
                    newitem.asansor1 = file.asansor1;
                    newitem.asansor2 = file.asansor2;
                    newitem.asansor3 = file.asansor3;


                    newitem.desc = file.desc;
                    newitem.ertefa = file.ertefa;
                    newitem.eslahi = file.eslahi;
                    newitem.hasEstakhr = file.hasEstakhr;
                    newitem.hasJakoozi = file.hasJakoozi;
                    newitem.hasSauna = file.hasSauna;
                    newitem.number =Convert.ToInt64(file.ID);
                    newitem.isEjare = file.isEjare;
                    newitem.isForoosh = file.isForoosh;
                    newitem.isMoaveze = file.isMoaveze;
                    newitem.isMosharekat = file.isMosharekat;
                    newitem.isRahn = file.isRahn;

                    newitem.maghaze = file.maghaze;
                    newitem.malek = file.malek;
                    
                    newitem.sell2khareji = file.sell2khareji;

                    newitem.suit = file.suit;

                    newitem.tabaghe_1_ejare = Convert.ToInt64(file.tabaghe_1_ejare);
                    newitem.tabaghe_1_metri = Convert.ToInt64(file.tabaghe_1_metri);
                    newitem.tabaghe_1_rahn = Convert.ToInt64(file.tabaghe_1_rahn);
                    newitem.tabaghe_1_total_price = Convert.ToInt64(file.tabaghe_1_total_price);
                    newitem.tabaghe_2_ejare = Convert.ToInt64(file.tabaghe_2_ejare);
                    newitem.tabaghe_2_metri = Convert.ToInt64(file.tabaghe_2_metri);
                    newitem.tabaghe_2_rahn = Convert.ToInt64(file.tabaghe_2_rahn);
                    newitem.tabaghe_2_total_price = Convert.ToInt64(file.tabaghe_2_total_price);
                    newitem.tabaghe_3_ejare = Convert.ToInt64(file.tabaghe_3_ejare);
                    newitem.tabaghe_3_metri = Convert.ToInt64(file.tabaghe_3_metri);
                    newitem.tabaghe_3_rahn = Convert.ToInt64(file.tabaghe_3_rahn);
                    newitem.tabaghe_3_total_price = Convert.ToInt64(file.tabaghe_3_total_price);

                    newitem.tabaghe1 = Convert.ToInt64(file.tabaghe1);
                    newitem.tabaghe2 = Convert.ToInt64(file.tabaghe2);
                    newitem.tabaghe3 = Convert.ToInt64(file.tabaghe3);
                    newitem.bed1 = Convert.ToInt64(file.bed1);
                    newitem.bed2 = Convert.ToInt64(file.bed2);
                    newitem.bed3 = Convert.ToInt64(file.bed3);

                    newitem.zirbana1 = Convert.ToInt64(file.zirbana1);
                    newitem.zirbana2 = Convert.ToInt64(file.zirbana2);
                    newitem.zirbana3 = Convert.ToInt64(file.zirbana3);

                    newitem.takhlie =file.takhlie;
                    newitem.tarakom =file.tarakom;
                    newitem.title =file.title;
                    newitem.toole_bar =file.toole_bar;
                    newitem.total_floor = Convert.ToInt64(file.total_floor);
                    newitem.total_vahed = Convert.ToInt64(file.total_vahed);
                    newitem.vahed_per_floor = Convert.ToInt64(file.vahed_per_floor);

                    newitem.zirzamin =file.zirzamin;
               
                    newitem.balkon1 =file.balkon1;
                    newitem.balkon2 =file.balkon2;
                    newitem.balkon3 =file.balkon3;
                    
                   
                    newitem.hasGym =file.hasGym;
                    newitem.hasHall =file.hasHall;
                    newitem.hasLobbyMan =file.hasLobbyMan;
                    newitem.hasRoofGarden =file.hasRoofGarden;
                    newitem.hasShooting =file.hasShooting;
                    newitem.isMoble =file.isMoble;
                    newitem.parking1 =file.parking1;
                    newitem.parking2 =file.parking2;
                    newitem.parking3 =file.parking3;
                    newitem.senn = Convert.ToInt32(file.senn);

                    newitem.date_updated = file.date_updated.ToGeorgianDateTime();
                    manager.additem(newitem);

                }
                MessageBox.Show("با موفقیت دانلود شد");
            }
            


        }


        private void Calculate(int i)
        {
            double pow = Math.Pow(i, i);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            for (int j = 0; j < 100000; j++)
            {
                Calculate(j);
                backgroundWorker.ReportProgress((j * 100) / 100000);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO: do something with final calculation.
        }
        private void dopreliminaries() {
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            DDTO.Text = dateTimeConvert.ToPersianDateString(System.DateTime.Now);
            this.CenterToScreen();
        }
    }
}
