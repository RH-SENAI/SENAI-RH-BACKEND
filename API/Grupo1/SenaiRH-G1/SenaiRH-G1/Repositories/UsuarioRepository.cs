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
        private readonly SenaiRHContext ctx;

        public UsuarioRepository(SenaiRHContext appContext)
        {
            ctx = appContext;
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
