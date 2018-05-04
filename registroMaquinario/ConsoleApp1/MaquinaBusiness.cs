using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MaquinaBusiness
    {
        public void InserirMaquina(tb_maquinario item)
        {
            try
            {
                using (GesComEntities1 db = new GesComEntities1())
                {
                    db.tb_maquinario.Add(item);
                    db.SaveChanges();
                }

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
