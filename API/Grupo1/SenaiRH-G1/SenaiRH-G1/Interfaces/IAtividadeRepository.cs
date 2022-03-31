using SenaiRH_G1.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Interfaces
{
    interface IAtividadeRepository
    {
        void CadastrarAtividade(Atividade atividade);
        void RemoverAtividade(Atividade atividade);
        Atividade BuscarPorId(int id);
        List<Atividade> ListarTodas();
        List<Atividade> ListarMinhas(int id);
    }
}
