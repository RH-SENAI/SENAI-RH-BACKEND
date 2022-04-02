﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using SenaiRH_G1.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SenaiRH_G1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadesController : ControllerBase
    {
        private readonly senaiRhContext _context;
        private readonly IAtividadeRepository _atividadeRepository;
        public AtividadesController(senaiRhContext context, IAtividadeRepository repo)
        {
            _context = context;
            _atividadeRepository = repo;
        }

        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atividade>>> GetAtividades()
        {
            return await _context.Atividades.ToListAsync();
        }

        [HttpPost]
        public IActionResult PostAtividade(Atividade atividade)
        {
            try
            {

                if (atividade.NomeAtividade == null || atividade.DataInicio < DateTime.Now || atividade.DataInicio < DateTime.Now)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Os dados estão incorretos"
                    });
                }
                atividade.DataCriacao = DateTime.Now;
                _context.Atividades.Add(atividade);
                _context.SaveChanges();

                return StatusCode(201, new
                {
                    Mensagem = "Atividade cadastrada",
                    atividade
                });
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipamento(int id)
        {
            var atividade = await _context.Atividades.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }

            _context.Atividades.Remove(atividade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("MinhasAtividade/{id}")]
        public IActionResult ListarMinhasAtividades(int id)
        {
            try
            {
                if (id > 0)
                {
                    

                    return Ok(_atividadeRepository.ListarMinhas(id));
                }
                return BadRequest(new
                {
                    Mensagem = "O ID inserido é inválido!"
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex);  
            }
        }

        [HttpPost("Associar/{idUsuario}")]
        public IActionResult AssociarAtividade(int idUsuario, int idAtividade)
        {
            try
            {
                Atividade atividade = _context.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                if (usuario != null && atividade != null)
                {
                    _atividadeRepository.AssociarAtividade(idUsuario, idAtividade);

                    return Ok(new
                    {
                        Mensagem = "O usuário foi associado a atividade!"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Mensagem = "O ID usuário ou o ID Atividade são inválidos;"
                    });
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpPatch("FinalizarAtividade/{idAtividade}")]
        public IActionResult FinalizarAtividade(int idAtividade)
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                Atividade atividade = _context.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
                Minhasatividade minhaAtividade = _context.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);

                if (atividade != null && usuario != null)
                {
                    if (minhaAtividade != null)
                    {

                        _atividadeRepository.FinalizarAtividade(idUsuario, idAtividade, usuario.IdTipoUsuario);

                    if (atividade.NecessarioValidar)
                    {
                        return Ok(new
                        {
                            Mensagem = "Sua atividade está aguardando confirmação do administrador!"
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            Mensagem = "Sua atividade foi finalizada com sucesso!"
                        });
                    }
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            Mensagem = "O usuário não está associado a atividade"
                        });
                    }

                }
                else
                {
                    return BadRequest(new
                    {
                        Mensagem = "Os ID's informados são inválidos!"
                    });

                }
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPatch("ValidarAtividade/{idAtividade}/{idUsuario}")]
        public IActionResult ValidarAtividade(int idAtividade, int idUsuario)
        {
            try
            {
                Minhasatividade minhaAtividade = _context.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);
                Atividade atividade = _context.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                if(atividade != null && usuario != null)
                {
                    if (minhaAtividade != null)
                    {
                        _atividadeRepository.ValidarAtividade(idAtividade, idUsuario);
                        return Ok(new
                        {
                            Mensagem = "A atividade foi validada!"
                        });
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            Mensagem = "O usuário não está associado a essa atividade!"
                        });
                    }
                }
                else
                {
                    return BadRequest(new
                    {
                        Mensagem = "Os ID's inseridos são inválidos!"
                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}