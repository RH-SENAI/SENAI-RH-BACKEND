using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly ICargoRepository _cargoRepository;

        public CargosController(ICargoRepository repo)
        {
            _cargoRepository = repo;
        }

        [HttpGet("Listar")]
        public IActionResult ListarCargos()
        {
            try
            {
             return Ok(_cargoRepository.ListarCargos());
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        // GET api/<CargosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CargosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CargosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CargosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
