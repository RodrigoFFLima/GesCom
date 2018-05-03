using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessWeb;

namespace sistemaGesCom
{
    public partial class registroMobiliario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtDescricaoMovel.Text != "" && txtValorCompra.Text != "")
            {
                if (Convert.ToDateTime(txtDataCompra.Text) <= DateTime.Today)
                {
                    if (Convert.ToInt32(txtQuantidade.Text) > 0)
                    {
                        tb_mobilias mob = new tb_mobilias();
                        mob.mob_descricao = txtDescricaoMovel.Text;
                        mob.mob_dataCompra = Convert.ToDateTime(txtDataCompra.Text);
                        mob.mob_valor = Convert.ToDouble(txtValorCompra.Text);
                        mob.mob_qtde = Convert.ToInt32(txtQuantidade.Text);

                        (new MobiliaBusiness()).InserirMobilia(mob);

                        mob = null;

                        txtDescricaoMovel.Text = "";
                        txtDataCompra.Text = "";
                        txtValorCompra.Text = "";
                        txtQuantidade.Text = "";


                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Cadastro Feito com Sucesso!!');", true);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Ops! Quantidade deve ser maior que 0!!');", true);

                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Ops! Data não pode ser posterior a data de hoje!!');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Ops! Há campos em branco!!');", true);
        }
    }
}