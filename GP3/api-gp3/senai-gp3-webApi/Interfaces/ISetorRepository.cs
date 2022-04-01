using senai_gp3_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    interface ISetorRepository
    {
        List<Setor> ListarSetores();

        void DeletarSetor(int idSetor);

        void CadastrarSetor(Setor novoSetor);

        Setor AtualizarSetor(int idSetor, Setor setorAtualizado);

        Setor ListarSetorPorId(int idSetor);
    }
}
