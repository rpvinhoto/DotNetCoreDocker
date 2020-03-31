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
    public class SaboresController : ControllerBase
    {
        private readonly ISaborAppService _saborAppService;
        private readonly IMapper _mapper;

        public SaboresController(ISaborAppService saborAppService, IMapper mapper)
        {
            _saborAppService = saborAppService;
            _mapper = mapper;
        }

        // GET: api/Sabores
        /// <summary>
        /// Listar todos os sabores
        /// </summary>
        /// <returns>Retorna todos os sabores</returns>
        /// <response code="200">Todos os sabores cadastrados</response>
        /// <response code="204">Não existe sabores cadastrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SaborViewModel>), 200)]
        [ProducesResponseType(204)]
        public ActionResult Get()
        {
            var sabores = _saborAppService.GetAll();

            if (sabores == null || !sabores.Any())
                return NoContent();

            return Ok(_mapper.Map<IEnumerable<SaborViewModel>>(sabores));
        }

        // GET: api/Sabores/5
        /// <summary>
        /// Obter um sabor
        /// </summary>
        /// <returns>Retorna o sabor pesquisado</returns>
        /// <response code="200">Informações do registro</response>
        /// <response code="404">Registro não encontrado</response>
        [HttpGet("{id}", Name = "SaborGetById")]
        [ProducesResponseType(typeof(SaborViewModel), 200)]
        [ProducesResponseType(404)]
        public ActionResult Get(int id)
        {
            var sabor = _saborAppService.GetById(id);

            if (sabor == null)
                return NotFound();

            return Ok(_mapper.Map<SaborViewModel>(sabor));
        }

        // POST: api/Sabores
        /// <summary>
        /// Inserir um sabor
        /// </summary>
        /// <returns>Retorna o registro inserido</returns>
        /// <response code="201">Registro criado</response>
        /// <response code="400">Requisição inválida</response>
        [HttpPost]
        [ProducesResponseType(typeof(SaborViewModel), 201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] SaborViewModel entity)
        {
            if (entity == null)
                return BadRequest();

            if (entity.Id != 0)
                return BadRequest("Id não deve ser informado.");

            var sabor = _saborAppService.Add(_mapper.Map<Sabor>(entity));

            return Created(string.Empty, _mapper.Map<SaborViewModel>(sabor));
        }

        // PUT: api/Sabores/5
        /// <summary>
        /// Atualizar um sabor
        /// </summary>
        /// <returns>Sem retorno</returns>
        /// <response code="204">Registro atualizado</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="404">Informação não encontrada</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, [FromBody] SaborViewModel entity)
        {
            if (entity == null)
                return BadRequest();

            if (id != entity.Id)
                return NotFound();

            var sabor = _saborAppService.GetById(id);

            if (sabor == null)
                return NotFound();

            _saborAppService.Update(_mapper.Map<Sabor>(entity));

            return NoContent();
        }

        // DELETE: api/Sabores/5
        /// <summary>
        /// Remover um sabor
        /// </summary>
        /// <returns>Sem retorno</returns>
        /// <response code="204">Registro removido</response>
        /// <response code="404">Informação não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            var sabor = _saborAppService.GetById(id);

            if (sabor == null)
                return NotFound();

            _saborAppService.Delete(sabor);

            return NoContent();
        }
    }
}