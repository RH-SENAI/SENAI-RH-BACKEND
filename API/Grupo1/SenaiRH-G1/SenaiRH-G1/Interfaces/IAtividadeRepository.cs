﻿using SenaiRH_G1.Domains;
using SenaiRH_G1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Interfaces
{
    public interface IAtividadeRepository
    {
        void CadastrarAtividade(Atividade atividade);
        void RemoverAtividade(Atividade atividade);
        Atividade BuscarPorId(int id);
        List<Atividade> ListarTodas();
        List<MinhasAtividadesViewModel> ListarMinhas(int id);
        void AssociarAtividade(int idUsuario, int idAtividade);
        void FinalizarAtividade(int idUsuario, int idAtividade, int idTipoUsuario);
        void ValidarAtividade(int idAtividade, int idUsuario);
    }
}
