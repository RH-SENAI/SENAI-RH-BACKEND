using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly senaiRhContext _context;
        public UsuariosController(senaiRhContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        
        [HttpPost("VerificaSenha")]
        public IActionResult VerificaSenha(string senhaAtual, string cpf)
        {
            try
            {
                bool resposta = _usuarioRepository.VerificaSenha(senhaAtual, cpf);
                return Ok(new
                {
                    Mensagem = resposta
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
