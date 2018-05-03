using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessWeb
{
    public class MobiliaBusiness
    {
        public void InserirMobilia(tb_mobilias item)
        {
            try
            {
                using (GesComEntities db = new GesComEntities())
                {
                    db.tb_mobilias.Add(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
