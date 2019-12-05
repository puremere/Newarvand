using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using realstate.Model;
using realstate.ListOfAdds;
using Newtonsoft.Json;
using realstate.Classes;

namespace realstate
{
    class databaseManager
    {
        dbContext context = new dbContext();
        functions FUNS = new functions();

        public void additem(item item) {
            long number =  item.number;
            if (context.items.Any(o => o.number == number)) return;
            context.items.Add(item);
            context.SaveChanges();

        }
        public void deleteitem(long number)
        {
           
            item item  = context.items.Where(b => b.number == number).FirstOrDefault();
            if (item != null)
            {
                
                context.items.Remove(item);
                context.SaveChanges();
            }
          
        }
        List<item> list = new List<item>();
        public List<item> getList(string query, string sortname)
        {
            queryModel log = JsonConvert.DeserializeObject<queryModel>(query);
            IQueryable<item> q = context.items;
            if(log.address != "")
            {
                q = q.Where(x => x.address.Contains(log.address));
            }
            if(log.anbari == "1")
            {
                q = q.Where(x => x.anbari1 == "1" || x.anbari2 == "1" || x.anbari3 == "1");
            }
            if (log.apartment != "")
            {
                q = q.Where(x => x.apartment == log.apartment);

            }
            if (log.asansor == "1")
            {
                q = q.Where(x => x.asansor1 == "1" || x.asansor2 == "1" || x.asansor3 == "1");
            }
            if (log.ashpazkhane != "")
            {
                q = q.Where(x => x.ashpazkhane == log.ashpazkhane);
            }
            if (log.bed_from != "")
            {
                long needed = Convert.ToInt64(log.bed_from);
                q = q.Where(x => x.bed1 >= needed || x.bed2 >= needed || x.bed3 >= needed );
            }
            if (log.bed_to != "")
            {
                long needed = Convert.ToInt64(log.bed_to);
                q = q.Where(x => x.bed1 <= needed || x.bed2 <= needed || x.bed3 <= needed);
            }
            if (log.date_from != "")
            {
                DateTime needed = dateTimeConvert.ToGeorgianDateTime(log.date_from);
                q = q.Where(x => x.date_updated >= needed );
            }
            if (log.date_to != "")
            {
                DateTime needed = dateTimeConvert.ToGeorgianDateTime(log.date_to);
                q = q.Where(x => x.date_updated <= needed);
            }
            if (log.desc != "")
            {
                q = q.Where(x => x.desc.Contains(log.desc));
            }
            if (log.ejare_from != "")
            {
                long needed = Convert.ToInt64(log.ejare_from);
                q = q.Where(x => x.tabaghe_1_ejare >= needed || x.tabaghe_2_ejare >= needed || x.tabaghe_3_ejare >= needed);
            }
            if (log.ejare_to != "")
            {
                long needed = Convert.ToInt64(log.ejare_to);
                q = q.Where(x => x.tabaghe_1_ejare <= needed || x.tabaghe_2_ejare <= needed || x.tabaghe_3_ejare <= needed);
            }
            if (log.ertefa != "")
            {
                q = q.Where(x => x.ertefa == log.ertefa );
            }
            if (log.eslahi != "")
            {
                q = q.Where(x => x.eslahi == log.eslahi);
            }
            if (log.garmayesh_sarmayesh != "")
            {
                q = q.Where(x => x.garmayesh_sarmayesh == log.garmayesh_sarmayesh);
            }
            if (log.hasEstakhr != "")
            {
                q = q.Where(x => x.hasEstakhr == log.hasEstakhr);
            }
            if (log.hasGym != "")
            {
                q = q.Where(x => x.hasGym == log.hasGym);
            }
            if (log.hasHall != "")
            {
                q = q.Where(x => x.hasHall == log.hasHall);
            }
            if (log.hasJakoozi != "")
            {
                q = q.Where(x => x.hasJakoozi == log.hasJakoozi);
            }
            if (log.hasRoofGarden != "")
            {
                q = q.Where(x => x.hasRoofGarden == log.hasRoofGarden);
            }
            if (log.hasSauna != "")
            {
                q = q.Where(x => x.hasSauna == log.hasSauna);
            }
            if (log.hasSeraydar != "")
            {
                q = q.Where(x => x.hasSauna == log.hasSauna);
            }
            if (log.hasShooting != "")
            {
                q = q.Where(x => x.hasShooting == log.hasShooting);
            }
            if (log.hasShooting != "")
            {
                q = q.Where(x => x.hasShooting == log.hasShooting);
            }
            if (log.ID != "")
            {
                if (FUNS.IsDigitsOnly(log.ID))
                {
                    long needed = Convert.ToInt64(log.ID);
                    q = q.Where(x => x.number == needed);
                }
                
            }
            if (log.id_from != "")
            {
                if (FUNS.IsDigitsOnly(log.id_from))
                {
                    long needed = Convert.ToInt64(log.id_from);
                    q = q.Where(x => x.number >= needed);
                }
               
            }
            if (log.id_to != "")
            {
                if (FUNS.IsDigitsOnly(log.id_to))
                {
                    long needed = Convert.ToInt64(log.id_to);
                    q = q.Where(x => x.number >= needed);
                }

            }
            if (log.isEjare != "")
            {
                q = q.Where(x => x.isEjare == log.isEjare);

            }
            if (log.isForoosh != "")
            {
                q = q.Where(x => x.isForoosh == log.isForoosh);

            }
            if (log.isMoaveze != "")
            {
                q = q.Where(x => x.isMoaveze == log.isMoaveze);

            }
            if (log.isMoble != "")
            {
                q = q.Where(x => x.isMoble == log.isMoble);

            }
            if (log.isMosharekat != "")
            {
                q = q.Where(x => x.isMosharekat == log.isMosharekat);

            }
            if (log.isRahn != "")
            {
                q = q.Where(x => x.isRahn == log.isRahn);

            }
            if (log.kaf_type != "")
            {
                q = q.Where(x => x.kaf_type == log.kaf_type);
            }
            if (log.kind != "")
            {
                //{ "-", "آپارتمان", "دفتر کار", "کلنگی", "مستغلات", "ویلا","مغازه" };
                switch (log.kind)
                {
                    case "آپارتمان":
                        q = q.Where(x => x.apartment != "");
                        break;
                    case "ویلا":
                        q = q.Where(x => x.villa != "");
                        break;
                    case "مستغلات":
                        q = q.Where(x => x.mostaghellat != "");
                        break;
                    case "کلنگی":
                        q = q.Where(x => x.kolangi != "");
                        break;
                    case "دفتر کار":
                        q = q.Where(x => x.office != "");
                        break;
                    case "مغازه":
                        q = q.Where(x => x.maghaze != "");
                        break;
                }
               
            }
            if (log.malek != "")
            {
                q = q.Where(x => x.malek == log.malek);
            }
            if (log.mantaghe_id != "")
            {
                q = q.Where(x => x.mantaghe_id == log.mantaghe_id);
            }
            if (log.mantaghe_name != "")
            {
                string mnt = log.mantaghe_name.Substring(1, log.mantaghe_name.Length - 2);
                List<string> mantaghelst = mnt.Split(',').ToList();
                foreach(var mantaghe in mantaghelst)
                {
                    q = q.Where(x => x.mantaghe_name == mantaghe);
                }
               
            }
            if(log.masahat_from != "")
            {
                long needed = Convert.ToInt64(log.masahat_from);
                q = q.Where(x => x.zirbana1 >= needed || x.zirbana2 >= needed || x.zirbana3 >= needed);
            }
            if (log.masahat_to != "")
            {
                long needed = Convert.ToInt64(log.masahat_to);
                q = q.Where(x => x.zirbana1 <= needed || x.zirbana2 <= needed || x.zirbana3 <= needed);
            }
            if (log.masahat_zamin != "")
            {
                long needed = Convert.ToInt64(log.masahat_zamin);
                q = q.Where(x => x.masahat_zamin == needed);
            }
            if (log.metri_from != "")
            {
                long needed = Convert.ToInt64(log.metri_from);
                q = q.Where(x => x.tabaghe_1_metri >= needed || x.tabaghe_2_metri >= needed || x.tabaghe_3_metri >= needed);
            }
            if (log.metri_to != "")
            {
                long needed = Convert.ToInt64(log.metri_to);
                q = q.Where(x => x.tabaghe_1_metri <= needed || x.tabaghe_1_metri <= needed || x.tabaghe_1_metri <= needed);
            }
            if (log.mostaghellat != "")
            {
                
                q = q.Where(x => x.mostaghellat == log.mostaghellat);
            }
            if (log.office != "")
            {
                q = q.Where(x => x.office == log.office);
            }
            if(log.parking != "")
            {
                q = q.Where(x => x.parking3 == log.parking || x.parking3 == log.parking || x.parking3 == log.parking );
            }
            if (log.phones != "")
            {
                q = q.Where(x => x.phones.Contains(log.phones));
            }
            if (log.rahn_from != "")
            {
                long needed = Convert.ToInt64(log.rahn_from);
                q = q.Where(x => x.tabaghe_1_rahn >= needed || x.tabaghe_2_rahn >= needed || x.tabaghe_3_rahn >= needed);
            }
            if (log.rahn_to != "")
            {
                long needed = Convert.ToInt64(log.rahn_to);
                q = q.Where(x => x.tabaghe_1_rahn <= needed || x.tabaghe_2_rahn <= needed || x.tabaghe_3_rahn <= needed);
            }
            if (log.samt != "")
            {
                q = q.Where(x => x.samt == log.samt);
            }
            if (log.sell2khareji != "")
            {
                q = q.Where(x => x.sell2khareji == log.sell2khareji);
            }
            if (log.senn_from != "" && log.senn_to == "")
            {
                if (FUNS.IsDigitsOnly(log.senn_from))
                {
                    long needed = Convert.ToInt64(log.senn_from) - 2;
                    q = q.Where(x => x.senn >= needed || x.senn == 0);
                }
              
            }
            else if (log.senn_from == "" && log.senn_to != "")
            {
                if (FUNS.IsDigitsOnly(log.senn_to))
                {
                    long needed = Convert.ToInt64(log.senn_to) - 2;
                    q = q.Where(x => x.senn <= needed && x.senn != 1);
                }
               
            }
            else if (log.senn_from != "" && log.senn_to != "")
            {
                if (FUNS.IsDigitsOnly(log.senn_to) && FUNS.IsDigitsOnly(log.senn_from))
                {
                    long neededfrom = Convert.ToInt64(log.senn_from) - 2;
                    long neededto = Convert.ToInt64(log.senn_to) - 2;
                    q = q.Where(x => x.senn <= neededto && x.senn >= neededfrom);
                }

            }
            if(log.seraydar != "")
            {
                q = q.Where(x => x.seraydar == log.seraydar );
            }
            if (log.suit != "")
            {
                q = q.Where(x => x.suit == log.suit);
            }
            if (log.tabaghe != "")
            {
                if (FUNS.IsDigitsOnly(log.tabaghe))
                {
                    long needed = Convert.ToInt64(log.tabaghe_from);
                    q = q.Where(x => x.tabaghe1 == needed || x.tabaghe2 == needed || x.tabaghe3 == needed);

                }
            }
            if (log.tabaghe_from != "")
            {
                if (FUNS.IsDigitsOnly(log.tabaghe_from))
                {
                    long needed = Convert.ToInt64(log.tabaghe_from);
                    q = q.Where(x => x.total_floor >= needed );
                }
              
            }
            if (log.tabaghe_to != "")
            {
                if (FUNS.IsDigitsOnly(log.tabaghe_to))
                {
                    long needed = Convert.ToInt64(log.tabaghe_to);
                    q = q.Where(x => x.total_floor >= needed);
                }

            }
            if (log.takhlie != "")
            {
                q = q.Where(x => x.takhlie == log.takhlie); 

            }
            if (log.tarakom != "")
            {
                q = q.Where(x => x.tarakom == log.tarakom);

            }
            if (log.title != "")
            {
                q = q.Where(x => x.title.Contains(log.title) );

            }
            if (log.toole_bar != "")
            {
                q = q.Where(x => x.toole_bar == log.toole_bar);

            }
            if (log.total_price_from != "")
            {
                if (FUNS.IsDigitsOnly(log.total_price_from))
                {
                    long needed = Convert.ToInt64(log.total_price_from);
                    q = q.Where(x => x.tabaghe_1_total_price >= needed || x.tabaghe_2_total_price >= needed || x.tabaghe_3_total_price >= needed);

                }

            }
            if (log.total_price_to != "")
            {
                if (FUNS.IsDigitsOnly(log.total_price_to))
                {
                    long needed = Convert.ToInt64(log.total_price_to);
                    q = q.Where(x => x.tabaghe_1_total_price <= needed || x.tabaghe_2_total_price <= needed || x.tabaghe_3_total_price <= needed);

                }

            }
            if (log.total_vahed != "")
            {
                long needed = Convert.ToInt64(log.total_vahed);
                q = q.Where(x => x.total_vahed == needed);

            }
            if (log.villa != "")
            {
                q = q.Where(x => x.villa == log.villa);
            }
            if (log.wc != "")
            {
                q = q.Where(x => x.wc1 == log.wc || x.wc2 == log.wc || x.wc3 == log.wc );
            }
            if (log.zirbana_from != "")
            {
                if (FUNS.IsDigitsOnly(log.zirbana_from))
                {
                    long needed = Convert.ToInt64(log.zirbana_from);
                    q = q.Where(x => x.zirbana1 <= needed || x.zirbana2 <= needed || x.zirbana3 <= needed);

                }
            }
            if (log.zirbana_to != "")
            {
                if (FUNS.IsDigitsOnly(log.zirbana_to))
                {
                    long needed = Convert.ToInt64(log.zirbana_from);
                    q = q.Where(x => x.zirbana1 >= needed || x.zirbana2 >= needed || x.zirbana3 >= needed);

                }
            }
            if (log.zirzamin != "")
            {
                q = q.Where(x => x.zirzamin == log.zirzamin);
            }

            list = q.ToList();
            return list;
        }
       
    }
}
