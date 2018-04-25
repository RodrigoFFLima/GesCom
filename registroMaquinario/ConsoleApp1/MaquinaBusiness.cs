using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MaquinaBusiness
    {
        public int InserirMaquina(tb_maquinario item)
        {
            try
            {
                int id = 0;
                using (GesComEntities1 db = new GesComEntities1())
                {
                    db.tb_maquinario.Add(item);
                    db.SaveChanges();
                    id = item.maq_id;
                }

                return id;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void AlterarMaquina(tb_maquinario item)
        {
            try
            {
                using (GesComEntities1 db = new GesComEntities1())
                {
                    db.Entry(item).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
