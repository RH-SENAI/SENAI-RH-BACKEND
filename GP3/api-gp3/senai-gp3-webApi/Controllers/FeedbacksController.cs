using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackRepository _feedBacksRepostory;

        public FeedbacksController(IFeedbackRepository repo)
        {
            _feedBacksRepostory = repo;
        }

        // GET: api/<FeedbacksController>
        [HttpGet("Listar")]
        public IActionResult ListarFeedbacks()
        {
            return Ok(_feedBacksRepostory.ListarFb());
        }

        // GET api/<FeedbacksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FeedbacksController>
        [HttpPost("Cadastrar")]
        public IActionResult CadastrarFeedback(Feedback novoFeedback)
        {
            try
            {
                if (novoFeedback == null)
                {
                    return BadRequest("Objeto não pode estar vazio!");
                } else
                {
                    
                    return StatusCode(201);
                }
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        // PUT api/<FeedbacksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FeedbacksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
