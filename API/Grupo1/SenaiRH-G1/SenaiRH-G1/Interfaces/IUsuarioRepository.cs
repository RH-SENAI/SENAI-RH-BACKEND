using SenaiRH_G1.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string cpf, string senha);
        Usuario BuscarUsuario(int id);
        List<Usuario> ListarFuncionarios();
        void AlterarSenha(string cpf, string senha, string senhaAtual);
        bool VerificaSenha(string senha, string cpf);
    }
}
