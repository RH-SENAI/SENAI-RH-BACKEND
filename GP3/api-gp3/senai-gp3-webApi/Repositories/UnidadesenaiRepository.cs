﻿using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_gp3_webApi.Repositories
{
    public class UnidadesenaiRepository : IUnidadesenaiRepository
    {
        private readonly senaiRhContext ctx;

        public UnidadesenaiRepository(senaiRhContext appContext)
        {
            ctx = appContext;   
        }

        public void CadastrarUniSenai(Unidadesenai unidadesenai)
        {
            ctx.Unidadesenais.Add(unidadesenai);
            
            ctx.SaveChanges();
        }

        public List<Unidadesenai> ListarUniSenai()
        {
            return ctx.Unidadesenais.ToList();
        }
    }
}
