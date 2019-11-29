using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using realstate.Model;
using realstate.ListOfAdds;

namespace realstate
{
    class databaseManager
    {
        dbContext context = new dbContext();

        public void additem(item item) {
            context.items.Add(item);
            context.SaveChanges();
        }
        public void deleteitem(string id)
        {
            item item  = context.items.Where(b => b.ID == id).FirstOrDefault();
            if (item != null)
            {
                
                context.items.Remove(item);
                context.SaveChanges();
            }
          
        }
    }
}
