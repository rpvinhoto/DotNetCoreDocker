using Acai.Api.ViewModel;
using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Acai.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TamanhosController : ControllerBase
    {
        private readonly ITamanhoAppService _tamanhoAppService;
        private readonly IMapper _mapper;

        public TamanhosController(ITamanhoAppService tamanhoAppService, IMapper mapper)
        {
            _tamanhoAppService = tamanhoAppService;
            _mapper = mapper;
        }

        // GET: api/Tamanhos
        /// <summary>
        /// Listar todos os tamanhos
        /// </summary>
        /// <returns>Retorna todos os tamanhos</returns>
        /// <response code="200">Todos os tamanhos cadastrados</response>
        /// <response code="204">Não existe tamanhos cadastrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TamanhoViewModel>), 200)]
        [ProducesResponseType(204)]
        public ActionResult Get()
        {
            var tamanhos = _tamanhoAppService.GetAll();

            if (tamanhos == null || !tamanhos.Any())
                return NoContent();

            return Ok(_mapper.Map<IEnumerable<TamanhoViewModel>>(tamanhos));
        }

        // GET: api/Tamanhos/5
        /// <summary>
        /// Obter um tamanho
        /// </summary>
        /// <returns>Retorna o tamanho pesquisado</returns>
        /// <response code="200">Informações do registro</response>
        /// <response code="404">Registro não encontrado</response>
        [HttpGet("{id}", Name = "TamanhoGetById")]
        [ProducesResponseType(typeof(TamanhoViewModel), 200)]
        [ProducesResponseType(404)]
        public ActionResult Get(int id)
        {
            var tamanho = _tamanhoAppService.GetById(id);

            if (tamanho == null)
                return NotFound();

            return Ok(_mapper.Map<TamanhoViewModel>(tamanho));
        }

        // POST: api/Tamanhos
        /// <summary>
        /// Inserir um tamanho
        /// </summary>
        /// <returns>Retorna o registro inserido</returns>
        /// <response code="201">Registro criado</response>
        /// <response code="400">Requisição inválida</response>
        [HttpPost]
        [ProducesResponseType(typeof(TamanhoViewModel), 201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] TamanhoViewModel entity)
        {
            if (entity == null)
                return BadRequest();

            if (entity.Id != 0)
                return BadRequest("Id não deve ser informado.");

            var tamanho = _tamanhoAppService.Add(_mapper.Map<Tamanho>(entity));

            return Created(string.Empty, _mapper.Map<TamanhoViewModel>(tamanho));
        }

        // PUT: api/Tamanhos/5
        /// <summary>
        /// Atualizar um tamanho
        /// </summary>
        /// <returns>Sem retorno</returns>
        /// <response code="204">Registro atualizado</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="404">Informação não encontrada</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, [FromBody] TamanhoViewModel entity)
        {
            if (entity == null)
                return BadRequest();

            if (id != entity.Id)
                return NotFound();

            var tamanho = _tamanhoAppService.GetById(id);

            if (tamanho == null)
                return NotFound();

            _tamanhoAppService.Update(_mapper.Map<Tamanho>(entity));

            return NoContent();
        }

        // DELETE: api/Tamanhos/5
        /// <summary>
        /// Remover um tamanho
        /// </summary>
        /// <returns>Sem retorno</returns>
        /// <response code="204">Registro removido</response>
        /// <response code="404">Informação não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            var tamanho = _tamanhoAppService.GetById(id);

            if (tamanho == null)
                return NotFound();

            _tamanhoAppService.Delete(tamanho);

            return NoContent();
        }
    }
}