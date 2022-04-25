using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using SenaiRH_G1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly senaiRhContext ctx;

        public UsuarioRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        /// <summary>
        /// Método para Buscar um usuário
        /// </summary>
        /// <param name="id">ID do Usuário que será buscado</param>
        /// <returns>O usuário buscado</returns>
        public Usuario BuscarUsuario(int id)
        {
            //Instancia novo usuario
            Usuario usuario = new ();
            //Busca o usuário pelo ID fornecido, salva no usuario instânciado e retorna o usuário
            return usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        /// <summary>
        /// Método para listar todos os funcionarios
        /// </summary>
        /// <returns>Retorna todos os funcionários cadastrados</returns>
        public List<Usuario> ListarFuncionarios()
        {
            //Busca todos os usuários do sistema que
           return ctx.Usuarios
                //IdTipoUsuario seja igual ao de funcionario
                .Where(u => u.IdTipoUsuario == 1)
                //Seleciona os dados que serão enviados na resposta
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    DataNascimento = u.DataNascimento,
                    SaldoMoeda = u.SaldoMoeda,
                    Trofeus = u.Trofeus,
                    IdUnidadeSenai = u.IdUnidadeSenai,
                    IdUnidadeSenaiNavigation = new Unidadesenai()
                    {
                        NomeUnidadeSenai = u.IdUnidadeSenaiNavigation.NomeUnidadeSenai,
                        TelefoneUnidadeSenai = u.IdUnidadeSenaiNavigation.TelefoneUnidadeSenai,
                        EmailUnidadeSenai = u.IdUnidadeSenaiNavigation.EmailUnidadeSenai
                    }
                }).ToList();
        }

        /// <summary>
        /// Método para fazer login no sistema
        /// </summary>
        /// <param name="Cpf">CPF do usuário que será logado</param>
        /// <param name="senha">senha do usuário que será logado</param>
        /// <returns>Usuario</returns>
        public Usuario Login(string Cpf, string senha)
        {
            //Busca usuário pelo email
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Cpf == Cpf);

            //Caso o usuário seja válido
            if (usuario != null)
            {
                //Verifica se a senha do usuário cadastrado no banco de dados é uma hash

                //Caso não seja uma Hash
                if (usuario.Senha.Length != 60 && usuario.Senha[0].ToString() != "$")
                {
                    //Verifica se a senha digitada é correta
                    //Caso seja correta
                    if (senha == usuario.Senha)
                    {
                        //Gera uma Hash com a senha do usuario
                        string senhaHash = Criptografia.GerarHash(usuario.Senha);
                        //Altera a senha no banco de dados
                        usuario.Senha = senhaHash;
                        //Salva a alteração
                        ctx.Usuarios.Update(usuario);
                        ctx.SaveChanges();
                        //Retorna o usuário
                        return usuario;
                    }
                    //Caso seja incorreta
                    else
                    {
                        //Retorna nulo
                        return null;
                    }
                }
                //Caso seja uma Hash, Compara as senha e compara as senha
                bool confere = Criptografia.CompararSenha(senha, usuario.Senha);
                //Caso sejam compatíveis
                if (confere)
                    //Retorna o Usuário
                    return usuario;
            }
            //Caso não seja válido, retorna nulo
            return null;
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == id);
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }


    }
}
