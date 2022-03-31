using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositores
{
    public class ComentariocursoRepository : IComentarioCursoRepository
    {
        senaiRhContext ctx = new senaiRhContext();

        


        public void AlterarComentarioCurso(int Id, Comentariocurso comentarioAtualizado)
        {
            Comentariocurso comentarioBuscado = ListarComentarioPorIdCurso(Id);
            if (comentarioBuscado != null)
            {
                comentarioBuscado.AvaliacaoComentario = comentarioAtualizado.AvaliacaoComentario;
                comentarioBuscado.ComentarioCurso1 = comentarioAtualizado.ComentarioCurso1;

                ctx.Comentariocursos.Update(comentarioBuscado);
                ctx.SaveChanges();
            }
        }

        public void CadastrarComentarioCurso(Comentariocurso NovoComentario)
        {
            ctx.Comentariocursos.Add(NovoComentario);
            ctx.SaveChanges();
        }

        public void ExcluirComentarioCurso(int Id)
        {
            ctx.Comentariocursos.Remove(ListarComentarioPorIdCurso(Id));
            ctx.SaveChanges();
        }

        public List<Comentariocurso> ListarComenatarioCurso()
        {
            return ctx.Comentariocursos.ToList();
        }

        public Comentariocurso ListarComentarioPorIdCurso(int Id)
        {
            return ctx.Comentariocursos.FirstOrDefault(c => c.IdComentarioCurso == Id);
        }
    }
}
