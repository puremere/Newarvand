using Classes;
using Newtonsoft.Json;
using realstate.ListOfAdds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using realstate.Classes;


namespace realstate
{
    public partial class search : Form
    {
        BackgroundWorker getDataBackGroundWorker = new BackgroundWorker();
        CatsAndAreasObject log = new CatsAndAreasObject();
        private Bitmap renderBmp;
        databaseManager manager = new databaseManager();
        fileList filelist = null;
        FontClass fontclass = new FontClass();




        public search()
        {
            InitializeComponent();
    

            this.refresh.Visible = false;
           // this.MouseClick += mouseClick;
            this.DoubleBuffered = true;

        }
       
        private void search_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = true;
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);

            if (GlobalVariable.isadmin == "1")
            {
                log = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
                Settings1.Default.IsLogedIn = "1";
                setcat();

            }
            else
            {
                log = GlobalVariable.catsAndAreas;
                Settings1.Default.IsLogedIn = "1";
                setcatforclient();

            }



          

            panel1.PanelElement.Shape = new RoundRectShape();
            panel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel1.PanelElement.PanelFill.BackColor = Color.White;
            panel2.PanelElement.Shape = new RoundRectShape();
            panel2.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel2.PanelElement.PanelFill.BackColor = Color.White;

            panel3.PanelElement.Shape = new RoundRectShape();
            panel3.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel3.PanelElement.PanelFill.BackColor = Color.White;
            radPanel38.PanelElement.Shape = new RoundRectShape();
            mantagheNameText.Text = "";
            mantagheNameText2.Text = "";


        }

        public void setcat()
        {


            CatsAndAreasObject log = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
            Settings1.Default.IsLogedIn = "1";

            BindingSource bs = new BindingSource();
            bs.DataSource = new List<string> {"-", "آپارتمان", "دفتر کار", "کلنگی", "مستغلات", "ویلا","مغازه" };
            kind.DataSource = bs;
            // سه گزینه زیر اینجا داده نمی شود و در بخش لاگین کاربر
            //GlobalVariable.activezonse = log.result2.active_regions;
            //GlobalVariable.portlimit = log.result2.max_users;
            //GlobalVariable.expirationdate = log.result2.expire_date;
            ////  GlobalVariable.token = log.token;

            //var sourceofApartment = new AutoCompleteStringCollection();
            //foreach (var item in log.result.apartment)
            //{

            //    sourceofApartment.Add(item);
            //}


            //apartment.AutoCompleteCustomSource = sourceofApartment;
            //apartment.AutoCompleteMode = AutoCompleteMode.Append;
            //apartment.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //apartment.MaxDropDownItems = 10;

            apartment.DisplayMember = "title";
            apartment.ValueMember = "ID";
            apartment.DataSource = new BindingSource(log.result.apartment, null);


            ashpazkhane.DisplayMember = "title";
            ashpazkhane.ValueMember = "ID";
            ashpazkhane.DataSource = new BindingSource(log.result.ashpazkhane, null);

            //var sourceofOffice = new AutoCompleteStringCollection();
            //foreach (var item in log.result.office)
            //{

            //    sourceofOffice.Add(item);
            //}

            //office.AutoCompleteCustomSource = sourceofOffice;
            //office.AutoCompleteMode = AutoCompleteMode.Append;
            //office.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //office.MaxDropDownItems = 10;

            office.DisplayMember = "title";
            office.ValueMember = "ID";
            office.DataSource = new BindingSource(log.result.office, null);


            //var sourceofKolangi = new AutoCompleteStringCollection();
            //foreach (var item in log.result.kolangi)
            //{

            //    sourceofKolangi.Add(item);
            //}
            //kolangi.AutoCompleteCustomSource = sourceofKolangi;
            //kolangi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //kolangi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //kolangi.MaxDropDownItems = 10;
            kolangi.DisplayMember = "title";
            kolangi.ValueMember = "ID";
            kolangi.DataSource = new BindingSource(log.result.kolangi, null);

            //var sourceofVilla = new AutoCompleteStringCollection();
            //foreach (var item in log.result.villa)
            //{

            //    sourceofVilla.Add(item);
            //}
            //villa.AutoCompleteCustomSource = sourceofVilla;
            //villa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //villa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //villa.MaxDropDownItems = 10;

            villa.DisplayMember = "title";
            villa.ValueMember = "ID";
            villa.DataSource = new BindingSource(log.result.villa, null);



            //var sourceofMostaghelat = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mostaghellat)
            //{

            //    sourceofMostaghelat.Add(item);
            //}
            //mostaghellat.AutoCompleteCustomSource = sourceofMostaghelat;
            //mostaghellat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mostaghellat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mostaghellat.MaxDropDownItems = 10;
            mostaghellat.DisplayMember = "title";
            mostaghellat.ValueMember = "ID";
            mostaghellat.DataSource = new BindingSource(log.result.mostaghellat, null);




            //var sourceofSamt = new AutoCompleteStringCollection();
            //foreach (var item in log.result.samt)
            //{

            //    sourceofSamt.Add(item);
            //}
            //samt.AutoCompleteCustomSource = sourceofSamt;
            //samt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //samt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //samt.MaxDropDownItems = 10;

            //samt.DataSource = log.result.samt;


            //var sourceofSenn = new AutoCompleteStringCollection();
            //foreach (var item in log.result.senn)
            //{

            //    sourceofSenn.Add(item);
            //}
            //senn.AutoCompleteCustomSource = sourceofSenn;
            //senn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //senn.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //senn.MaxDropDownItems = 10;
            //  senn.DataSource = log.result.villa;


            //var sourceofMantaghe = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mantaghe)
            //{

            //    sourceofMantaghe.Add(item);
            //}
            //mantaghe.AutoCompleteCustomSource = sourceofMantaghe;
            //mantaghe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mantaghe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mantaghe.MaxDropDownItems = 10;
            mantaghe_name.DisplayMember = "title";
            mantaghe_name.ValueMember = "ID";
            mantaghe_name.DataSource = new BindingSource(log.result.mantaghe, null);


            mantaghe_id.DisplayMember = "title";
            mantaghe_id.ValueMember = "ID";
            mantaghe_id.DataSource = new BindingSource(log.result.mantaghe_id, null);



            //var sourceofMantagheID = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mantaghe_id)
            //{

            //    sourceofMantagheID.Add(item);
            //}
            //mantaghe_id.AutoCompleteCustomSource = sourceofMantagheID;
            //mantaghe_id.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mantaghe_id.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mantaghe_id.MaxDropDownItems = 10;
            //  m.DataSource = log.result.mantaghe_id;


            //var sourceofSeraydar = new AutoCompleteStringCollection();
            //foreach (var item in log.result.seraydar)
            //{

            //    sourceofSeraydar.Add(item);
            //}
            //seraydar.AutoCompleteCustomSource = sourceofSeraydar;
            //seraydar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //seraydar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //seraydar.MaxDropDownItems = 10;
            //  seraydar.DataSource = log.result.seraydar;


            //var sourceofKatType = new AutoCompleteStringCollection();
            //foreach (var item in log.result.kaf_type)
            //{

            //    sourceofKatType.Add(item);
            //}
            //kaf_type.AutoCompleteCustomSource = sourceofKatType;
            //kaf_type.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //kaf_type.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //kaf_type.MaxDropDownItems = 10;
            // kaf_type.DataSource = log.result.kaf_type;


            //var sourceofSarmayesh = new AutoCompleteStringCollection();
            //foreach (var item in log.result.garmayesh_sarmayesh)
            //{

            //    sourceofSarmayesh.Add(item);
            //}
            //garmayesh_sarmayesh.AutoCompleteCustomSource = sourceofSarmayesh;
            //garmayesh_sarmayesh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //garmayesh_sarmayesh.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //garmayesh_sarmayesh.MaxDropDownItems = 10;
            // garmayesh_sarmayesh.DataSource = log.result.garmayesh_sarmayesh;

            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("خطا در اتصال به سرور");
            }

        }
        public void setcatforclient()
        {


            CatsAndAreasObject log = GlobalVariable.catsAndAreas;
            Settings1.Default.IsLogedIn = "1";

           

            BindingSource bs = new BindingSource();
            bs.DataSource = new List<string> { "-","آپارتمان", "دفتر کار","کلنگی","مستغلات","ویلا","مغازه" };
            kind.DataSource = bs;
            // سه گزینه زیر اینجا داده نمی شود و در بخش لاگین کاربر
            //GlobalVariable.activezonse = log.result2.active_regions;
            //GlobalVariable.portlimit = log.result2.max_users;
            //GlobalVariable.expirationdate = log.result2.expire_date;
            ////  GlobalVariable.token = log.token;

            //var sourceofApartment = new AutoCompleteStringCollection();
            //foreach (var item in log.result.apartment)
            //{

            //    sourceofApartment.Add(item);
            //}


            //apartment.AutoCompleteCustomSource = sourceofApartment;
            //apartment.AutoCompleteMode = AutoCompleteMode.Append;
            //apartment.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //apartment.MaxDropDownItems = 10;

            apartment.DisplayMember = "title";
            apartment.ValueMember = "ID";
            apartment.DataSource = new BindingSource(log.result.apartment, null);



            ashpazkhane.DisplayMember = "title";
            ashpazkhane.ValueMember = "ID";
            ashpazkhane.DataSource = new BindingSource(log.result.ashpazkhane, null);

            //var sourceofOffice = new AutoCompleteStringCollection();
            //foreach (var item in log.result.office)
            //{

            //    sourceofOffice.Add(item);
            //}

            //office.AutoCompleteCustomSource = sourceofOffice;
            //office.AutoCompleteMode = AutoCompleteMode.Append;
            //office.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //office.MaxDropDownItems = 10;

            office.DisplayMember = "title";
            office.ValueMember = "ID";
            office.DataSource = new BindingSource(log.result.office, null);


            //var sourceofKolangi = new AutoCompleteStringCollection();
            //foreach (var item in log.result.kolangi)
            //{

            //    sourceofKolangi.Add(item);
            //}
            //kolangi.AutoCompleteCustomSource = sourceofKolangi;
            //kolangi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //kolangi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //kolangi.MaxDropDownItems = 10;
            kolangi.DisplayMember = "title";
            kolangi.ValueMember = "ID";
            kolangi.DataSource = new BindingSource(log.result.kolangi, null);

            //var sourceofVilla = new AutoCompleteStringCollection();
            //foreach (var item in log.result.villa)
            //{

            //    sourceofVilla.Add(item);
            //}
            //villa.AutoCompleteCustomSource = sourceofVilla;
            //villa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //villa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //villa.MaxDropDownItems = 10;

            villa.DisplayMember = "title";
            villa.ValueMember = "ID";
            villa.DataSource = new BindingSource(log.result.villa, null);



            //var sourceofMostaghelat = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mostaghellat)
            //{

            //    sourceofMostaghelat.Add(item);
            //}
            //mostaghellat.AutoCompleteCustomSource = sourceofMostaghelat;
            //mostaghellat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mostaghellat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mostaghellat.MaxDropDownItems = 10;
            mostaghellat.DisplayMember = "title";
            mostaghellat.ValueMember = "ID";
            mostaghellat.DataSource = new BindingSource(log.result.mostaghellat, null);




            //var sourceofSamt = new AutoCompleteStringCollection();
            //foreach (var item in log.result.samt)
            //{

            //    sourceofSamt.Add(item);
            //}
            //samt.AutoCompleteCustomSource = sourceofSamt;
            //samt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //samt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //samt.MaxDropDownItems = 10;

            //samt.DataSource = log.result.samt;


            //var sourceofSenn = new AutoCompleteStringCollection();
            //foreach (var item in log.result.senn)
            //{

            //    sourceofSenn.Add(item);
            //}
            //senn.AutoCompleteCustomSource = sourceofSenn;
            //senn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //senn.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //senn.MaxDropDownItems = 10;
            //  senn.DataSource = log.result.villa;


            //var sourceofMantaghe = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mantaghe)
            //{

            //    sourceofMantaghe.Add(item);
            //}
            //mantaghe.AutoCompleteCustomSource = sourceofMantaghe;
            //mantaghe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mantaghe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mantaghe.MaxDropDownItems = 10;
            mantaghe_name.DisplayMember = "title";
            mantaghe_name.ValueMember = "ID";
            mantaghe_name.DataSource = new BindingSource(log.result.mantaghe, null);


            mantaghe_id.DisplayMember = "title";
            mantaghe_id.ValueMember = "ID";
            mantaghe_id.DataSource = new BindingSource(log.result.mantaghe_id, null);



            //var sourceofMantagheID = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mantaghe_id)
            //{

            //    sourceofMantagheID.Add(item);
            //}
            //mantaghe_id.AutoCompleteCustomSource = sourceofMantagheID;
            //mantaghe_id.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mantaghe_id.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mantaghe_id.MaxDropDownItems = 10;
            //  m.DataSource = log.result.mantaghe_id;


            //var sourceofSeraydar = new AutoCompleteStringCollection();
            //foreach (var item in log.result.seraydar)
            //{

            //    sourceofSeraydar.Add(item);
            //}
            //seraydar.AutoCompleteCustomSource = sourceofSeraydar;
            //seraydar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //seraydar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //seraydar.MaxDropDownItems = 10;
            //  seraydar.DataSource = log.result.seraydar;


            //var sourceofKatType = new AutoCompleteStringCollection();
            //foreach (var item in log.result.kaf_type)
            //{

            //    sourceofKatType.Add(item);
            //}
            //kaf_type.AutoCompleteCustomSource = sourceofKatType;
            //kaf_type.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //kaf_type.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //kaf_type.MaxDropDownItems = 10;
            // kaf_type.DataSource = log.result.kaf_type;


            //var sourceofSarmayesh = new AutoCompleteStringCollection();
            //foreach (var item in log.result.garmayesh_sarmayesh)
            //{

            //    sourceofSarmayesh.Add(item);
            //}
            //garmayesh_sarmayesh.AutoCompleteCustomSource = sourceofSarmayesh;
            //garmayesh_sarmayesh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //garmayesh_sarmayesh.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //garmayesh_sarmayesh.MaxDropDownItems = 10;
            // garmayesh_sarmayesh.DataSource = log.result.garmayesh_sarmayesh;


            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("خطا در اتصال به سرور");
            }

        }

        private void label59_Click(object sender, EventArgs e)
        {
            getDataFromServer();
        }
        private void getDataFromServer()
        {

            refresh.Visible = true;
            getDataBackGroundWorker.WorkerSupportsCancellation = true;
            getDataBackGroundWorker.DoWork += new DoWorkEventHandler(getDataBackGroundWorker_do);
            getDataBackGroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getDataBackGroundWorker_done);




            try
            {
                queryModel model = new queryModel()
                {

                };

                string dd = "";
                switch (kind.SelectedItem)
                {
                    case "آپارتمان":
                        dd = "1";
                        break;
                    case "دفتر کار":
                        dd = "2";
                        break;
                    case "کلنگی":
                        dd = "3";
                        break;
                    case "مستغلات":
                        dd = "4";
                        break;
                    case "ویلا":
                        dd = "5";
                        break;
                    case "مغازه":
                        dd = "6";
                        break;
                    default:
                        dd = "";
                        break;

                }
                model.kind = dd;
                model.apartment = (apartment.SelectedValue == null) ? "" : apartment.SelectedValue.ToString();
                model.mantaghe_id = (mantaghe_id.SelectedValue == null) ? "" : mantaghe_id.SelectedValue.ToString();
                model.villa = (villa.SelectedValue == null) ? "" : villa.SelectedValue.ToString();
                model.kolangi = (kolangi.SelectedValue == null) ? "" : kolangi.SelectedValue.ToString();
                model.mostaghellat = (mostaghellat.SelectedValue == null) ? "" : mostaghellat.SelectedValue.ToString();
                model.office = (office.SelectedValue == null) ? "" : office.SelectedValue.ToString();
                //model.nama = (nama.SelectedValue == null) ? "" : nama.SelectedValue.ToString();
                model.ashpazkhane = (ashpazkhane.SelectedValue == null) ? "" : ashpazkhane.SelectedValue.ToString();
                if (mantagheNameText2.Text == "")
                {
                    GlobalVariable.mantagheIDes = "";
                }
                model.mantaghe_name = GlobalVariable.mantagheIDes;
                if (GlobalVariable.mantagheIDes != "")
                {
                    model.mantaghe_name = ","+ GlobalVariable.mantagheIDes;
                }

                model.anbari = anbari.Checked ? "1" : "";
                model.asansor = asansor.Checked ? "1" : "";
                model.hasEstakhr = hasEstakhr.Checked ? "1" : "";
                model.hasJakoozi = hasJakoozi.Checked ? "1" : "";
                model.hasSauna = hasSauna.Checked ? "1" : "";
                model.isEjare = isEjare.Checked ? "1" : "";
                model.isForoosh = isForoosh.Checked ? "1" : "";
                model.isMoaveze = isMoaveze.Checked ? "1" : "";
                model.isMosharekat = isMosharekat.Checked ? "1" : "";
                model.isRahn = isRahn.Checked ? "1" : "";
                model.sell2khareji = sell2khareji.Checked ? "1" : "";
                model.seraydar = hasSeraydar.Checked ? "1" : "";
                model.hasGym = hasGym.Checked ? "1" : "";
                model.hasShooting = hasShooting.Checked ? "1" : "";
                model.hasHall = hasHall.Checked ? "1" : "";
                model.hasRoofGarden = hasRoofGarden.Checked ? "1" : "";
                model.isMoble = isMoble.Checked ? "1" : "";
                model.parking = parking.Checked ? "1" : "";
                model.labi = labi.Checked ? "1" : "";
                model.parking = parking.Checked ? "1" : "";
                model.address = address.Text;
                model.desc = desc.Text;
                model.tabaghe = tabaghe.Text;
                GlobalVariable.searchTabghe = tabaghe.Text;
                model.phones = phones.Text;
                model.malek = malek.Text;
                model.zirbana_from = zirbana_from.Text;
                model.zirbana_to = zirbana_to.Text;
                model.senn_from = senn_from.Text;
                model.senn_to = senn_to.Text;
                if (senn_from.Text == "" && senn_to.Text != "")
                {
                    model.senn_from = "2000";

                }
                else if (senn_from.Text != "" && senn_to.Text == "")
                {
                   
                    model.senn_to = "1000";
                }
                model.masahat_from = masahat_from.Text;
                model.masahat_to = masahat_to.Text;
                model.id_from = id_from.Text;
                model.id_to = id_to.Text;
                model.ID = ID.Text;
                model.tabaghe_from = tabaghe_from.Text;
                model.tabaghe_to = tabaghe_to.Text;
                model.rahn_from = rahn_from.Text;
                model.ejare_from = ejare_from.Text;
                model.rahn_to = rahn_to.Text;
                model.ejare_to = ejare_to.Text;
                model.metri_from = metri_from.Text;
                model.metri_to = metri_to.Text;
                model.total_price_from = total_price_from.Text;
                model.total_price_to = total_price_to.Text;
                model.date_from = date_from.Text;
                model.date_to = date_to.Text;
                model.bed_from = bed_from.Text;
                model.bed_to = bed_to.Text;



                string str = JsonConvert.SerializeObject(model);
                GlobalVariable.lastSearchModel = model;

                getDataBackGroundWorker.RunWorkerAsync(argument: str);
               
            }
            catch (Exception)
            {

                MessageBox.Show("فرم جستجو را کامل کنید ");
                return;
            }


        }
     
        void getDataBackGroundWorker_do(object sender, DoWorkEventArgs e)
        {


            string query = (string)e.Argument;
            string S = "";


            try
            {
                CatsAndAreasObject CATS = new CatsAndAreasObject();
                try
                {
                    CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
                }
                catch
                {

                    CATS = GlobalVariable.catsAndAreas;
                }
                List<gridVM> list = new List<gridVM>();
                foreach (var item in manager.getList(query, S))
                {
                    if (GlobalVariable.searchTabghe == "")
                    {
                        GlobalVariable.searchTabghe = "1";
                    }
                    string tabaghe = GlobalVariable.searchTabghe;
                    string fullprice = item.tabaghe_1_total_price.ToString();
                    string metriprice = item.tabaghe_1_metri.ToString();
                    string rahnprice = item.tabaghe_1_rahn.ToString();
                    string ejareprice = item.tabaghe_1_ejare.ToString();
                    string tabagh = item.tabaghe1.ToString();
                    string kha = item.bed1.ToString();
                    string zirban = item.zirbana1.ToString();
                    string tb1 = item.tabaghe1.ToString();
                    string tb2 = item.tabaghe2.ToString();
                    string tb3 = item.tabaghe3.ToString();

                    if (tb1 == tabaghe)
                    {
                        fullprice = item.tabaghe_1_total_price.ToString();
                        metriprice = item.tabaghe_1_metri.ToString();
                        rahnprice = item.tabaghe_1_rahn.ToString();
                        ejareprice = item.tabaghe_1_ejare.ToString();
                        tabagh = item.tabaghe1.ToString();
                        kha = item.bed1.ToString();
                        zirban = item.zirbana1.ToString();
                    }
                    if (tb2 == tabaghe)
                    {
                        fullprice = item.tabaghe_2_total_price.ToString();
                        metriprice = item.tabaghe_2_metri.ToString();
                        rahnprice = item.tabaghe_2_rahn.ToString();
                        ejareprice = item.tabaghe_2_ejare.ToString();
                        tabagh = item.tabaghe2.ToString();
                        kha = item.bed2.ToString();
                        zirban = item.zirbana2.ToString();
                    }
                    if (tb3 == tabaghe)
                    {
                        fullprice = item.tabaghe_3_total_price.ToString();
                        metriprice = item.tabaghe_3_metri.ToString();
                        rahnprice = item.tabaghe_3_rahn.ToString();
                        ejareprice = item.tabaghe_3_ejare.ToString();
                        tabagh = item.tabaghe3.ToString();
                        kha = item.bed3.ToString();
                        zirban = item.zirbana3.ToString();
                    }


                    string serverid = item.ID.ToString();
                    string date = item.date_updated.ToString();
                    string address = item.address.ToString();
                    string owner = item.malek.ToString();
                    string senn = item.senn == 0 ? "-" : (from q in CATS.result.senn
                                                          where q.ID == item.senn.ToString()
                                                          select q.title).First();

                    string melkkind = "";

                    if (item.maghaze != null)
                    {
                        melkkind = melkkind + "مغازه،";
                    }
                    if (item.apartment != null)
                    {
                        melkkind = melkkind + "آپارتمان،";
                    }
                    if (item.villa != null)
                    {
                        melkkind = melkkind + "ویلا،";
                    }
                    if (item.mostaghellat != null)
                    {
                        melkkind = melkkind + "مستغلات،";
                    }
                    if (item.kolangi != null)
                    {
                        melkkind = melkkind + "کلنگی،";
                    }
                    if (item.office != null)
                    {
                        melkkind = melkkind + "دفتر،";
                    }
                    if (melkkind.Length > 0)
                    {
                        melkkind = melkkind.Remove(melkkind.Length - 1, 1);
                    }

                    string Dealkind = "";
                    if (Convert.ToInt32(item.isForoosh.ToString()) > 0)
                    {
                        Dealkind = Dealkind + "فروش،";
                    }
                    if (Convert.ToInt32(item.isRahn.ToString()) > 0)
                    {
                        Dealkind = Dealkind + "رهن،";
                    }
                    if (Convert.ToInt32(item.isEjare.ToString()) > 0)
                    {
                        Dealkind = Dealkind + "اجاره،";
                    }
                    if (Dealkind.Length > 0)
                    {
                        Dealkind = Dealkind.Remove(Dealkind.Length - 1, 1);
                    }


                    string totalrahn = item.isForoosh.ToString() == "1" ? fullprice : rahnprice;
                    string metriejare = item.isForoosh.ToString() == "1" ? metriprice : ejareprice;


                    string Rtabaghe = tabagh;
                    string khab = kha;
                    string zirbana = zirban;



                    bool mycheckbox = false;
                    totalrahn = totalrahn.Replace(".", "");
                    if (totalrahn == "0")
                    {
                        totalrahn = "-";
                    }
                    else if (Convert.ToInt64(totalrahn) > 0)
                    {
                        string mytotal = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(totalrahn));
                        totalrahn = mytotal;
                    }
                    else if (totalrahn == "-1")
                    {
                        totalrahn = "توافقی";
                    }
                    else if (totalrahn == "-2")
                    {
                        totalrahn = "رایگان";
                    }

                    metriejare = metriejare.Replace(".", "");
                    if (Convert.ToInt64(metriejare) == 0)
                    {
                        metriejare = "-";
                    }
                    else if (Convert.ToInt64(metriejare) > 0)
                    {
                        string mymetriejare = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(metriejare));
                        metriejare = mymetriejare;
                    }
                    else if (metriejare == "-1")
                    {
                        metriejare = "توافقی";
                    }
                    else if (metriejare == "-2")
                    {
                        metriejare = "رایگان";
                    }
                    if (GlobalVariable.temporaryOwnList.Contains(serverid + ","))
                    {
                        mycheckbox = true;
                    }
                    gridVM newitem = new gridVM()
                    {
                        Address = item.address,
                        bed = kha,
                        codegrid = item.number.ToString(),
                        dategrid = dateTimeConvert.ToPersianDateString(item.date_updated),
                        ejare_metri = metriejare,
                        floorgrid = tabagh,
                        kindgrid = Dealkind,
                        typegrid = melkkind,
                        ownergrid = item.malek,
                        rahn_total = totalrahn,
                        zirbana = zirban,
                        checkbox = mycheckbox,
                        Senn = senn

                    };
                    list.Add(newitem);
                }

                string FILELIST = JsonConvert.SerializeObject(list);
                e.Result = FILELIST;




            }
            catch (Exception)
            {
                e.Result = "error";
            }
        }
        private void getDataBackGroundWorker_done(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() == "error")
            {
                refresh.Visible = false;
            }
            else
            {
                filelist = new fileList(e.Result.ToString());
                filelist.Show();
                refresh.Visible = false;
            }
        }




        private void mantagheNameText_TextChanged(object sender, EventArgs e)
        {
            List<Mantaghe> finallist = new List<Mantaghe>();

            if (mantagheNameText.Text.Length > 0)
            {
               
                var srt = mantagheNameText.Text;
                int index = mantagheNameText.Text.LastIndexOf(",");
                if (index != -1)
                {
                    srt = srt.Remove(0, index + 1);
                }

                if (srt != "")
                {
                    finallist = (from p in log.result.mantaghe
                                 where p.title.StartsWith(srt)
                                 select p).ToList();
                    mantaghe_name.DataSource = finallist;
                    int x = radPanel1.Location.X;
                    int y = radPanel1.Location.Y;
                    paneloflist.Location = new Point(x, y + 80);
                    paneloflist.Visible = true;

                }
                else
                {
                    mantaghe_name.DataSource = log.result.mantaghe;
                    int x = radPanel1.Location.X;
                    int y = radPanel1.Location.Y;
                    paneloflist.Location = new Point(x, y+80);
                    paneloflist.Visible = true;

                }

            }
            else
            {
               
                mantaghe_name.DataSource = log.result.mantaghe;
                int x = radPanel1.Location.X;
                int y = radPanel1.Location.Y;
                paneloflist.Location = new Point(x, y + 80);
                paneloflist.Visible = true;
                

            }
        }



        private void mantagheNameText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    mantaghe_name.Focus();
                }
                if (e.KeyCode == Keys.Enter)
                {

                    string srt2 = mantaghe_name.Text;
                    var srt = mantagheNameText2.Text;
                    int index = mantagheNameText2.Text.LastIndexOf(",");
                    if(srt2 != ""){
                        if (index != -1)
                        {

                            srt = srt.Remove(index + 1, mantagheNameText2.Text.Length - index - 1);
                            mantagheNameText2.Text = srt + srt2 + ",";
                            mantagheNameText.Text = "";
                            deleteText.Visible = true;
                            setIndexForMantaghe();
                            paneloflist.Visible = false;

                        }

                        else
                        {

                            mantagheNameText2.Text = srt2 + ",";
                            paneloflist.Visible = false;
                            mantagheNameText.Text = string.Empty;
                            setIndexForMantaghe();

                        }
                    }
                    


                    //enter key is down
                }
            }
            catch 
            {

               
            }
           
        }

        private void mantaghe_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string srt2 = mantaghe_name.Text;
                var srt = mantagheNameText2.Text;
                int index = mantagheNameText2.Text.LastIndexOf(",");

                if (index != -1)
                {
                    srt = srt.Remove(index + 1, mantagheNameText2.Text.Length - index - 1);
                    mantagheNameText2.Text = srt + srt2 + ",";
                    paneloflist.Visible = false;
                    mantagheNameText.Text = "";
                    setIndexForMantaghe();
                    mantagheNameText.Focus();
                }

                else
                {
                    mantagheNameText2.Text = srt2 + ",";
                    paneloflist.Visible = false;
                    mantagheNameText.Text = "";
                    setIndexForMantaghe();
                    mantagheNameText.Focus();
                }


                //enter key is down
            }

        }
        public void setIndexForMantaghe()
        {
            string text = mantagheNameText2.Text;
            text = text.Remove(text.Length - 1);
            List<string> list = text.Split(',').ToList();
            string final = "";
            foreach (var item in list)
            {
                string value = (from p in log.result.mantaghe
                                where p.title == item
                                select p.ID).First();
                final = final + value + ",";
                GlobalVariable.mantagheIDes = final;
            }
        }

        private void deleteText_Click(object sender, EventArgs e)
        {
            mantagheNameText2.Text = "";
        }

        private void mantaghe_name_Leave(object sender, EventArgs e)
        {
            paneloflist.Visible = false;
        }

        private void mantagheNameText_Click(object sender, EventArgs e)
        {
            if (paneloflist.Visible == false)
            {
                int x = radPanel1.Location.X;
                int y = radPanel1.Location.Y;
                paneloflist.Location = new Point(x, y + 80);
                paneloflist.Visible = true;
            }
            else
            {
                paneloflist.Visible = false;
            }
        }

        private void radPanel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel18_Paint(object sender, PaintEventArgs e)
        {

        }



        private void total_price_from_Leave(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            try
            {
               
                textbox.Text = string.Format("{0:#,##0}", double.Parse(textbox.Text));
            }
            catch 
            {
                textbox.Text = "";
            }
           
        }

        private void label56_Click(object sender, EventArgs e)
        {
            string now = DateTime.Now.ToPersianDateString();
            //string tomorrow = DateTime.Now.AddDays(1).ToPersianDateString();
            date_from.Text = now;
            date_to.Text = now;
           // getDataFromServer();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            kind.SelectedIndex = 0;
            apartment.SelectedIndex = 0;
            mantaghe_id.SelectedIndex = 0;
            villa.SelectedIndex = 0;
            kolangi.SelectedIndex = 0;
            mostaghellat.SelectedIndex = 0;
            office.SelectedIndex = 0;
            ashpazkhane.SelectedIndex = 0;
            mantagheNameText.Text = "";
            mantagheNameText2.Text = "";
            apartment.SelectedIndex = 0;
            GlobalVariable.mantagheIDes = "";

            anbari.Checked = false;
            asansor.Checked = false;
            hasEstakhr.Checked = false;
            hasJakoozi.Checked = false;
            hasSauna.Checked = false;
            isEjare.Checked = false;
            isForoosh.Checked = false;
            isMoaveze.Checked = false;
            isMosharekat.Checked = false;
            isRahn.Checked = false;
            sell2khareji.Checked = false;
            hasSeraydar.Checked = false;
            hasGym.Checked = false;
            hasShooting.Checked = false;
            hasHall.Checked = false;
            hasRoofGarden.Checked = false;
            isMoble.Checked = false;
            parking.Checked = false;
            labi.Checked = false;
            parking.Checked = false;

            address.Text = "";
            desc.Text = "";
            tabaghe.Text = "";

            phones.Text = "";
            malek.Text = "";
            //wc.Text = "";


            zirbana_from.Text = "";
            zirbana_to.Text = "";
            senn_from.Text = "";
            senn_to.Text = "";
            masahat_from.Text = "";
            masahat_to.Text = "";
            id_from.Text = "";
            id_to.Text = "";
            ID.Text = "";
            tabaghe_from.Text = "";
            tabaghe_to.Text = "";
            rahn_from.Text = "";
            ejare_from.Text = "";
            rahn_to.Text = "";
            ejare_to.Text = "";
            metri_from.Text = "";
            metri_to.Text = "";
            total_price_from.Text = "";
            total_price_to.Text = "";
            date_from.Text = "";
            date_to.Text = "";
            bed_from.Text = "";
            bed_to.Text = "";
        }

        private void sectionOneTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {
            GlobalVariable.result = null;
            main form1 = new main();
           // form1.wishfromsearch();
            GlobalVariable.fromwhere = "main";


            Control clt0 = form1.Controls.Find("flowLayoutPanel1", true).First();
            clt0.BackgroundImage = null;
            Control clt = form1.Controls.Find("radListView1", true).First();
            clt.Visible = true;

            Control clt2 = form1.Controls.Find("searchpanel", true).First();
            clt2.Visible = true;

            Control clt3 = form1.Controls.Find("dissconnect", true).First();
            clt3.Visible = false;

            Control clt4 = form1.Controls.Find("connect", true).First();
            clt4.Visible = true;
            form1.Show();

        }

        private void label55_Click(object sender, EventArgs e)
        {
            GlobalVariable.fromwhere6 = "sub";
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void mantagheNameText2_TextChanged(object sender, EventArgs e)
        {
            List<Mantaghe> finallist = new List<Mantaghe>();

            if (mantagheNameText.Text.Length > 0)
            {
                deleteText.Visible = true;
               
            }
            else
            {
                deleteText.Visible = false;
                
            }
        }

        public override Image BackgroundImage
        {
            set
            {
                Image baseImage = value;
                renderBmp = new Bitmap(baseImage.Width, baseImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                Graphics g = Graphics.FromImage(renderBmp);
                g.DrawImage(baseImage, 0, 0, baseImage.Width, baseImage.Height);
                g.Dispose();
            }
            get
            {
                return renderBmp;
            }
        }
        //private void mouseClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        if (!(mantaghe_name.Focused || mantagheNameText.Focused))
        //        {
        //            paneloflist.Visible = false;
        //        }
        //    }
        //}
    }
}
