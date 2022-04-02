using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Decisao
    {
        public Decisao()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int IdDecisao { get; set; }
        public int IdUsuario { get; set; }
        public string DescricaoDecisao { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DataDecisao { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime PrazoDeAvaliacao { get; set; }
        public decimal ResultadoDecisao { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
