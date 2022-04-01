using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {

        private ICursoRepository _cursoRepository { get; set; }

        public CursosController(ICursoRepository repo)
        {
            _cursoRepository = repo;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                List<Curso> listarCurso = _cursoRepository.ListarTodos();
                if (listarCurso.Count == 0)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não há nenhuma consulta cadastrada no sistema!"
                    });
                }
                return Ok(listarCurso);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }



        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_cursoRepository.BuscarPorId(id));
        }


        [HttpPatch("Deletar/{id:int}")]
        public IActionResult ExcluirCurso(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Escreva um ID válido"
                    });
                }

                if (_cursoRepository.BuscarPorId(id) == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Não há nenhuma Curso"
                    });
                }
                _cursoRepository.ExcluirCurso(id);

                return StatusCode(204, new
                {
                    Mensagem = "Curso foi cancelada"
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }



    }
}
