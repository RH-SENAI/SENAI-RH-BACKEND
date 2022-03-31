using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    interface ICursoRepository
    {

        List<Curso> ListarTodos();
        List<Curso> ListarCursoFavorito(int id);
        List<Curso> ListarComentarioCurso(int id);
        List<Curso> ListarRegistroCurso(int id);
        void CadastrarCurso(Curso novoCurso);
        void ExcluirCurso(int id);
        Curso BuscarPorId(int id);


    }
}
