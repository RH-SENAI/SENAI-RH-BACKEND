using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DecisoesController : ControllerBase
    {
        private readonly IDecisaoRepository _decisaoRepository;

        public DecisoesController(IDecisaoRepository repo)
        {
            _decisaoRepository = repo;
        }


        // GET: api/<DecisoesController>
        [HttpGet("Listar")]
        public IActionResult ListarDecisoes()
        {
            try
            {
                return Ok(_decisaoRepository.ListarDecisoes());
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        // GET api/<DecisoesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DecisoesController>
        [HttpPost("Cadastrar")]
        public IActionResult CadastrarDecisoes(Decisao novaDecisao)
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                if (novaDecisao == null)
                {
                    return BadRequest("Objeto Vazio!");
                } else
                {
                    novaDecisao.IdUsuario = idUsuario;
                    _decisaoRepository.CadastrarDecisao(novaDecisao);
                    return StatusCode(201);
                }
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        // PUT api/<DecisoesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DecisoesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
