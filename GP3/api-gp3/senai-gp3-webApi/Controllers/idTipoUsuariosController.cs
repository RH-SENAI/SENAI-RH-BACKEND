using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class idTipoUsuariosController : ControllerBase
    {
        private readonly IIdTipoUsuarioRepository _idTipoUsuarioRepository;

        public idTipoUsuariosController(IIdTipoUsuarioRepository repo)
        {
            _idTipoUsuarioRepository = repo;
        }

        // GET: api/<idTipoUsuariosController>
        [HttpGet("Listar")]
        public IActionResult ListarIdTiposUsuarios()
        {
            try
            {
                return Ok(_idTipoUsuarioRepository.ListarTipoUsuario());
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            };
        }

        // GET api/<idTipoUsuariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<idTipoUsuariosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<idTipoUsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<idTipoUsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
