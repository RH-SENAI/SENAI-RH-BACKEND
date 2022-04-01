using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class CursoRepository : ICursoRepository
    {

        SenaiRHContext ctx = new SenaiRHContext();

        public Curso BuscarPorId(int id)
        {
            return ctx.Cursos.FirstOrDefault(c => c.IdCurso == id);
        }

        public void CadastrarCurso(Curso novoCurso)
        {
            throw new NotImplementedException();
        }

        public void ExcluirCurso(int id)
        {
            Curso buscarPorId = ctx.Cursos.FirstOrDefault(c => c.IdCurso == id);
            if(buscarPorId == null)
            {
                throw new Exception("Curso não Existe");
            }

            ctx.Cursos.Remove(buscarPorId);
            ctx.SaveChanges();
        }

        public List<Curso> ListarComentarioCurso(int id)
        {
            throw new NotImplementedException();
        }

        public List<Curso> ListarCursoFavorito(int id)
        {
            throw new NotImplementedException();
        }

        public List<Curso> ListarRegistroCurso(int id)
        {
            throw new NotImplementedException();
        }

        public List<Curso> ListarTodos()
        {
            return ctx.Cursos
                    .Select(p => new Curso
                {
                    IdCurso = p.IdCurso,
                    IdEmpresa = p.IdEmpresa,
                    NomeCurso = p.NomeCurso,
                    DescricaoCurso = p.DescricaoCurso,
                    SiteCurso = p.SiteCurso,
                    ModalidadeCurso = p.ModalidadeCurso,
                    CaminhoImagemCurso = p.CaminhoImagemCurso,
                    CargaHoraria = p.CargaHoraria,
                    DataFinalizacao = p.DataFinalizacao,
                    MediaAvaliacaoCurso = p.MediaAvaliacaoCurso,
                    IdEmpresaNavigation = new Empresa()
                    {

                        NomeEmpresa = p.IdEmpresaNavigation.NomeEmpresa,
                        EmailEmpresa = p.IdEmpresaNavigation.EmailEmpresa,
                        TelefoneEmpresa = p.IdEmpresaNavigation.TelefoneEmpresa,
                        IdLocalizacaoNavigation = new Localizacao()
                        {
                            Numero = p.IdEmpresaNavigation.IdLocalizacaoNavigation.Numero,
                            IdLogradouroNavigation = new Logradouro()
                            {
                                NomeLogradouro = p.IdEmpresaNavigation.IdLocalizacaoNavigation.IdLogradouroNavigation.NomeLogradouro
                            },
                            IdEstadoNavigation = new Estado()
                            {
                                NomeEstado = p.IdEmpresaNavigation.IdLocalizacaoNavigation.IdEstadoNavigation.NomeEstado
                            }

                        }


                    }

                    
                })
                .ToList();
        }
    }
}
