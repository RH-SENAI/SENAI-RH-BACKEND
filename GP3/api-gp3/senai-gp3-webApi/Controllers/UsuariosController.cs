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

        
        [HttpGet("Listar/{idUsuario}")]
        public IActionResult ListaUsuarioPorId(int idUsuario)
        {
            try
            {
                if (idUsuario != 0)
                {
                    return BadRequest("O id do Usuário não pode ser 0 !");
                }

                return Ok(_usuarioRepository.ListarUsuarioPorId(idUsuario));
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
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
                    string uploadResultado = Upload.UploadFile(fotoPerfil, extensoesPermitidas).ToString();

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
        [HttpPut("Atualizar/{idUsuario}")]
        public IActionResult AtualizarUsuario(int idUsuario,  Usuario usuarioAtualizado)
        {
            try
            {


                if (usuarioAtualizado == null)
                {
                    return BadRequest("Nenhum campo foi atualizado");
                } else
                {
                    usuarioAtualizado.CaminhoFotoPerfil = "";
                    return Ok(_usuarioRepository.AtualizarUsuario(idUsuario, usuarioAtualizado));

                }
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("Deletar/{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("O id passado não pode ser 0");
                }
                else
                {

                    _usuarioRepository.DeletarUsuario(id);
                    return NoContent();
                }
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }
        }
    }
}
