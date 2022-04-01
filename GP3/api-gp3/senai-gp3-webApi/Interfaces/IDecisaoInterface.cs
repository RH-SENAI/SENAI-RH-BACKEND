using senai_gp3_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    interface IDecisaoInterface
    {
        List<Decisao> ListarDecisoes();

        void DeletarDecisao(int idDecisao);

        void CadastrarDecisao(Decisao novaDecisao);

        void AtualizarDecisao(int idDecisao, Decisao decisaoAtualizada);

        Decisao ListarDecisaoPorId(int idDecisao);

        Decisao VerificarDecisao(Decisao decisao);
    }
}
