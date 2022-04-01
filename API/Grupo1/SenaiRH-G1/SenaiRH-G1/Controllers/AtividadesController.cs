﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using SenaiRH_G1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadesController : ControllerBase
    {
        private readonly senaiRhContext _context;
        private readonly IAtividadeRepository _usuarioRepository;
        public AtividadesController(senaiRhContext context, IAtividadeRepository repo)
        {
            _context = context;
            _usuarioRepository = repo;
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
                    

                    return Ok(_usuarioRepository.ListarMinhas(id));
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
    }
}