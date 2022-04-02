using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using SenaiRH_G1.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SenaiRH_G1.Repositories
{
    public class AtividadeRepository : IAtividadeRepository
    {
        private readonly senaiRhContext ctx;
        public AtividadeRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        public void AssociarAtividade(int idUsuario, int idAtividade)
        {
            Minhasatividade novaAssociacao = new Minhasatividade();
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            Atividade atividade = ctx.Atividades.FirstOrDefault(u => u.IdAtividade == idAtividade);
            Cargo cargo = ctx.Cargos.FirstOrDefault(u => u.IdCargo == usuario.IdCargo);

            if (atividade != null && usuario != null)
            {
                novaAssociacao.IdUsuario = idUsuario;
                novaAssociacao.IdAtividade = idAtividade;
                novaAssociacao.IdSetor = cargo.IdSetor;
                novaAssociacao.IdSituacaoAtividade = 3;

                ctx.Minhasatividades.Add(novaAssociacao);
                ctx.SaveChanges();
            }

           
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

        public List<MinhasAtividadesViewModel> ListarMinhas(int id)
        {

            var listaMinhasAtividade = from atividades in ctx.Atividades
                                       join minhasAtividades in ctx.Minhasatividades on atividades.IdAtividade equals minhasAtividades.IdAtividade
                                       where minhasAtividades.IdUsuario == id
                                       select new MinhasAtividadesViewModel
                                       {
                                           IdAtividade = atividades.IdAtividade,
                                           NomeAtividade = atividades.NomeAtividade,
                                           DataInicio = atividades.DataInicio,
                                           DataCriacao = atividades.DataCriacao,
                                           DataConclusao = atividades.DataConclusao,
                                           DescricaoAtividade = atividades.DescricaoAtividade,
                                           RecompensaMoeda = atividades.RecompensaMoeda,
                                           RecompensaTrofeu = atividades.RecompensaTrofeu,
                                           NecessarioValidar = atividades.NecessarioValidar,
                                           IdMinhasAtividades = minhasAtividades.IdMinhasAtividades,
                                           IdSetor = minhasAtividades.IdSetor,
                                           IdUsuario = minhasAtividades.IdUsuario,
                                           IdSituacaoAtividade = minhasAtividades.IdSituacaoAtividade
                                       };
                                       

            return listaMinhasAtividade.ToList();

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

        
        public void FinalizarAtividade(int idUsuario, int idAtividade, int idTipoUsuario)
        {
            Minhasatividade minhaAtividade = ctx.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);
            Atividade atividade = ctx.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            if (minhaAtividade != null)
            {
                if(atividade.NecessarioValidar)
                {
                    minhaAtividade.IdSituacaoAtividade = 2;
                    ctx.Minhasatividades.Update(minhaAtividade);
                    ctx.SaveChanges();
                }
                else
                {
                    minhaAtividade.IdSituacaoAtividade = 1;
                    usuario.SaldoMoeda = usuario.SaldoMoeda + atividade.RecompensaMoeda;
                    usuario.Trofeus = usuario.Trofeus + atividade.RecompensaTrofeu;
                    ctx.Minhasatividades.Update(minhaAtividade);
                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();
                }

            }
            
        }

        
        public void ValidarAtividade(int idAtividade, int idUsuario)
        {
            Minhasatividade minhaAtividade = ctx.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);
            Atividade atividade = ctx.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (minhaAtividade != null)
            {
                if(minhaAtividade.IdSituacaoAtividade == 2)
                {
                    minhaAtividade.IdSituacaoAtividade = 1;
                    usuario.SaldoMoeda = usuario.SaldoMoeda + atividade.RecompensaMoeda;
                    usuario.Trofeus = usuario.Trofeus + atividade.RecompensaTrofeu;
                    ctx.Usuarios.Update(usuario);
                    ctx.Minhasatividades.Update(minhaAtividade);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
