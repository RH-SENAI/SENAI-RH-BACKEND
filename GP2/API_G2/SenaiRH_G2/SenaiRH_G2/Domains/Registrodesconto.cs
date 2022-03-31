﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G2.Domains
{
    public partial class Registrodesconto
    {
        public int IdRegistroDesconto { get; set; }
        public int IdDesconto { get; set; }
        public int IdUsuario { get; set; }

        public virtual Desconto IdDescontoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
