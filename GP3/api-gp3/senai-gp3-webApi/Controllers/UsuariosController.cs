using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Utils;
using senai_gp3_webApi.ViewModels;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace senai_gp3_webApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController(IUsuarioRepository repo)
        {
            _usuarioRepository = repo;
        }

        [HttpGet("Listar")]
        public IActionResult ListarUsuario()
        {
            try
            {
                return Ok(_usuarioRepository.ListarUsuario());

            }
            catch (Exception execp)
            {

                return BadRequest(execp);
            }
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("Cadastrar")]
        public IActionResult CadastrarUsuario([FromForm] UsuarioCadastroViewModel novoUsuario, IFormFile fotoPerfil)
        {
            try
            {
                if (fotoPerfil == null)
                {
                    novoUsuario.CaminhoFotoPerfil = "imagem-padrao.png";
                } else
                {
                    #region Upload da Imagem com extensões permitidas apenas
                    string[] extensoesPermitidas = { "jpg", "png", "jpeg" };
                    string uploadResultado = Upload.UploadFile(fotoPerfil, extensoesPermitidas);

                    if (uploadResultado == "")
                    {
                        return BadRequest("Arquivo não encontrado !");
                    }
                    if (uploadResultado == "Extensão não permitida")
                    {
                        return BadRequest("Extensão do arquivo não permitida");
                    }

                    novoUsuario.CaminhoFotoPerfil = uploadResultado;
                    #endregion
                }



                if (novoUsuario == null)
                {
                    return BadRequest("Todos os campos do usuario devem ser preenchidos !");
                } else
                {
                    _usuarioRepository.CadastrarUsuario(novoUsuario);
                    return StatusCode(201);
                }
            }
            catch (Exception exp)
            {

                return BadRequest(exp);
            }
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
