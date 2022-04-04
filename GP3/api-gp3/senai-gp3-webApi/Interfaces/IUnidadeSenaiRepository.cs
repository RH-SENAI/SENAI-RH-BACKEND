using System.Collections.Generic;
using senai_gp3_webApi.Domains;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gp3_webApi.Interfaces
{
    public interface IUnidadesenaiRepository
    {
        /// <summary>
        /// Lista todas as decisoes
        /// </summary>
        /// <returns>Uma lista com as decisoes</returns>
        List<Unidadesenai> ListarUniSenai();



        /// <summary>
        /// Cadastra uma unidade do senai
        /// </summary>
        /// <param name="unidadesenai">unidade que será cadastrada</param>
        void CadastrarUniSenai(Unidadesenai unidadesenai);
    }
}
