using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Repositories
{
    public class AtividadeRepository : IAtividadeRepository
    {
        private readonly SenaiRHContext ctx;
        public AtividadeRepository(SenaiRHContext appContext)
        {
            ctx = appContext;
        }
        public Atividade BuscarPorId(int id)
        {
            return ctx.Atividades.FirstOrDefault(c => c.IdAtividade == id);
        }

        public void CadastrarAtividade(Atividade atividade)
        {
            ctx.Atividades.Add(atividade);
            ctx.SaveChangesAsync();
        }

        public List<Atividade> ListarMinhas(int id)
        {
            throw new NotImplementedException();
        }

        public List<Atividade> ListarTodas()
        {
            return ctx.Atividades.ToList();
        }

        public void RemoverAtividade(Atividade atividade)
        {
            ctx.Atividades.Remove(atividade);
            ctx.SaveChangesAsync();
        }
    }
}
