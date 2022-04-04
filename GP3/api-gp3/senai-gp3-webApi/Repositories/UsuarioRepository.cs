using Newtonsoft.Json;
using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Utils;
using senai_gp3_webApi.ViewModels;
using System;
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

        public Usuario AtualizarUsuario(int idUsuario, Usuario usuarioAtualizado)
        {
            var usuarioAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuarioAchado != null)
            {

                if (usuarioAtualizado.Nome != null)
                {
                    usuarioAchado.Nome = usuarioAtualizado.Nome;
                }

                if (usuarioAtualizado.Email != null)
                {
                    usuarioAchado.Email = usuarioAtualizado.Email;
                }

                if (usuarioAtualizado.Senha != null)
                {
                    usuarioAchado.Senha = usuarioAtualizado.Senha;
                }

                if (usuarioAtualizado.Cpf != null)
                {
                    usuarioAchado.Cpf = usuarioAtualizado.Cpf;
                }

                if (usuarioAtualizado.CaminhoFotoPerfil != null)
                {
                    usuarioAchado.CaminhoFotoPerfil = usuarioAtualizado.CaminhoFotoPerfil;
                }

                if (usuarioAchado.DataNascimento < usuarioAtualizado.DataNascimento)
                {
                    usuarioAchado.DataNascimento = usuarioAtualizado.DataNascimento;
                }

                if (usuarioAtualizado.IdTipoUsuario != 0)
                {
                    usuarioAchado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
                }

                if (usuarioAtualizado.Trofeus != 0)
                {
                    usuarioAchado.Trofeus = usuarioAtualizado.Trofeus;
                }

                if (usuarioAtualizado.IdCargo != 0)
                {
                    usuarioAchado.IdCargo = usuarioAtualizado.IdCargo;
                }

                if (usuarioAtualizado.IdUnidadeSenai != 0)
                {
                    usuarioAchado.IdUnidadeSenai = usuarioAtualizado.IdUnidadeSenai;
                }

                if (usuarioAtualizado.LocalizacaoUsuario != null)
                {
                    usuarioAchado.LocalizacaoUsuario = usuarioAtualizado.LocalizacaoUsuario;
                }

                if (usuarioAtualizado.NivelSatisfacao != 0)
                {
                    usuarioAchado.NivelSatisfacao = usuarioAtualizado.NivelSatisfacao;
                }

                if (usuarioAtualizado.Salario != 0)
                {
                    usuarioAchado.Salario = usuarioAtualizado.Salario;
                }

                if (usuarioAtualizado.SaldoMoeda != 0)
                {
                    usuarioAchado.SaldoMoeda = usuarioAtualizado.SaldoMoeda;
                }

                if (usuarioAtualizado.Vantagens != 0)
                {
                    usuarioAchado.Vantagens = usuarioAtualizado.Vantagens;
                }

                ctx.Usuarios.Update(usuarioAchado);

                ctx.SaveChanges();

                return usuarioAchado;
            }

            return null;
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
            var usuarioAchado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            ctx.Usuarios.Remove(usuarioAchado);

            ctx.SaveChanges();
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
                    IdUsuario = u.IdUsuario,
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
