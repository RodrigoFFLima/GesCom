//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_usuario
    {
        public tb_usuario()
        {
            this.tb_chamados = new HashSet<tb_chamados>();
            this.tb_relacionamentos = new HashSet<tb_relacionamentos>();
        }
    
        public int usu_id { get; set; }
        public string usu_login { get; set; }
        public string usu_senha { get; set; }
        public int oracle_usu_id { get; set; }
    
        public virtual ICollection<tb_chamados> tb_chamados { get; set; }
        public virtual ICollection<tb_relacionamentos> tb_relacionamentos { get; set; }
    }
}