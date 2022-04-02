using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Utils;
using senai_gp3_webApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace senai_gp3_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly senaiRhContext ctx;

        public UsuarioRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        public void AtualizarFotoDePerfil(int idUsuario)
        {
            throw new System.NotImplementedException();
        }

        public void AtualizarUsuario(int idUsuario, Usuario usuarioAtualizado)
        {
            throw new System.NotImplementedException();
        }

        public void CadastrarUsuario(UsuarioCadastroViewModel novoUsuario)
        {
            Usuario usuario = new Usuario()
            {
 
                Nome = novoUsuario.Nome,
                Email = novoUsuario.Email,
                Senha = novoUsuario.Senha,
                Cpf = novoUsuario.Cpf,
                CaminhoFotoPerfil = novoUsuario.CaminhoFotoPerfil,
                DataNascimento = novoUsuario.DataNascimento,
                IdTipoUsuario = novoUsuario.IdTipoUsuario,
                Trofeus = novoUsuario.Trofeus,
                IdCargo = novoUsuario.IdCargo,
                IdUnidadeSenai = novoUsuario.IdUnidadeSenai,
                LocalizacaoUsuario = novoUsuario.LocalizacaoUsuario,
                NivelSatisfacao = novoUsuario.NivelSatisfacao,
                Salario = novoUsuario.Salario,
                SaldoMoeda = novoUsuario.SaldoMoeda,
                Vantagens = novoUsuario.Vantagens
            };

            ctx.Usuarios.Add(usuario);


            ctx.SaveChanges();
        }


        public string CalcularMediaAvaliacao(int idUsuario)
        {
            throw new System.NotImplementedException();
        }

        public string CalcularSatisfacao(int idUsuario)
        {
            throw new System.NotImplementedException();
        }

        public void DeletarUsuario(int idUsuario)
        {
            throw new System.NotImplementedException();
        }

        public string ListarSalario(int idUsuario)
        {
            throw new System.NotImplementedException();
        }

        public List<Usuario> ListarUsuario()
        {
            return ctx.Usuarios
                .Select(u => new Usuario
                {
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    Cpf = u.Cpf,
                    CaminhoFotoPerfil = u.CaminhoFotoPerfil,
                    DataNascimento = u.DataNascimento,
                    IdTipoUsuario = u.IdTipoUsuario,
                    Trofeus = u.Trofeus,
                    IdCargo = u.IdCargo,
                    IdUnidadeSenai = u.IdUnidadeSenai,
                    LocalizacaoUsuario = u.LocalizacaoUsuario,
                    NivelSatisfacao = u.NivelSatisfacao,
                    Salario = u.Salario,
                    SaldoMoeda = u.SaldoMoeda,
                    Vantagens = u.Vantagens,
                    IdCargoNavigation = new Cargo() 
                    {
                        IdCargo = u.IdCargoNavigation.IdCargo,
                        NomeCargo = u.IdCargoNavigation.NomeCargo
                    },
                    IdTipoUsuarioNavigation = new Tipousuario() 
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        NomeTipoUsuario = u.IdTipoUsuarioNavigation.NomeTipoUsuario
                    }
                    
                }).
                ToList();
        }

        public Usuario ListarUsuarioPorId(int idUsuario)
        {
            throw new System.NotImplementedException();
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                if (usuario.Senha.Length != 60 && usuario.Senha[0].ToString() != "$")
                {
                    string senhaHash = Criptografia.GerarHash(senha);
                    usuario.Senha = senhaHash;
                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();
                    return usuario;
                }
                bool confere = Criptografia.CompararSenha(senha, usuario.Senha);
                if (confere)
                    return usuario;
            }
            return null;
        }
    }
}
