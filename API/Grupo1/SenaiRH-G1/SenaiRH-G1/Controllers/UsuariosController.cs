﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace SenaiRH_G1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository repo)
        {
            _usuarioRepository = repo;
        }

        /// <summary>
        /// Endpoint para buscar um usuário pelo ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Retorna usuário buscado</returns>
        [HttpGet("BuscarUsuario/{id}")]
        public IActionResult BuscarUsuario(int id)
        {
            try
            {
                //Caso o ID seja maior que 0
                if (id > 0)
                {
                    //Busca o usuário pelo ID
                    Usuario usuario = _usuarioRepository.BuscarUsuario(id);
                    //Caso não haja um usuário com o mesmo ID
                    if(usuario == null) 
                        //Retorna NotFound
                        return NotFound(new
                        {
                            Mensagem = "O ID não corresponde a nenhum funcionário"
                        });
                    //Caso haja, retorna o usuário
                    return Ok(usuario);
                }
                return BadRequest(new
                {
                    Mensagem = "Id informado é inválido"
                });
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        /// <summary>
        /// Endpoint para buscar o usuário logado
        /// </summary>
        /// <returns>O usuário que está logado</returns>
        [Authorize]
        [HttpGet("BuscarUsuario")]
        public IActionResult BuscarUsuarioLogado()
        {
            try
            {
                //Recebe o ID do usuário logado
                int id = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Jti).Value);
                //Caso o ID seja maior que 0
                if (id > 0)
                {
                    //Busca o usuário pelo ID
                    Usuario usuario = _usuarioRepository.BuscarUsuario(id);
                    //Caso não haja um usuário com o mesmo ID
                    if (usuario == null)
                        //Retorna NotFound
                        return NotFound(new
                        {
                            Mensagem = "O ID não corresponde a nenhum funcionário"
                        });
                    //Caso haja, retorna o usuário
                    return Ok(usuario);
                }
                return BadRequest(new
                {
                    Mensagem = "Id informado é inválido"
                });
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Endpoint que lista todos os funcionários 
        /// </summary>
        /// <returns>Lista de Uusários</returns>
        [HttpGet("Funcionarios")]
        public IActionResult ListarFuncionarios()
        {
            try
            {
                //Instância uma lista de usuários e preenche com funcionarios
                List<Usuario> lista = _usuarioRepository.ListarFuncionarios();

                if (lista == null)
                    return NotFound(new
                    {
                        Mensagem = "Não há funcionáros no sistema"
                    });
                return Ok(lista);
            }
            catch (Exception ex)
            {

                throw;
            }
            
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
