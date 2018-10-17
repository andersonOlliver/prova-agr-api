using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CN.Taverna.Domain.Dto.Especialidade;
using CN.Taverna.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CN.Taverna.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeService _especialidadeService;

        public EspecialidadeController(IEspecialidadeService especialidadeService)
        {
            _especialidadeService = especialidadeService;
        }

        // GET: api/Especialidade
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await _especialidadeService.ObterTodos();
            return Ok(resultado);
        }

        // GET: api/Especialidade/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            var resultado = await _especialidadeService.ObterPorIdAsync(id);
            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        // POST: api/Especialidade
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EspecialidadeDto value)
        {
            var resultado = await _especialidadeService.Inserir(value);

            return Ok(resultado);
        }

        // PUT: api/Especialidade/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] EspecialidadeDto value)
        {
            return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NotFound();
        }
    }
}
