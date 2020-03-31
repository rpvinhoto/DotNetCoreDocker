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
    public class PersonalizacoesController : ControllerBase
    {
        private readonly IPersonalizacaoAppService _personalizacaoAppService;
        private readonly IMapper _mapper;

        public PersonalizacoesController(IPersonalizacaoAppService personalizacaoAppService, IMapper mapper)
        {
            _personalizacaoAppService = personalizacaoAppService;
            _mapper = mapper;
        }

        // GET: api/Personalizacoes
        /// <summary>
        /// Listar todas as personalizações
        /// </summary>
        /// <returns>Retorna todas as personalizações</returns>
        /// <response code="200">Todas as personalizações cadastrados</response>
        /// <response code="204">Não existe personalizações cadastradas</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PersonalizacaoViewModel>), 200)]
        [ProducesResponseType(204)]
        public ActionResult Get()
        {
            var personalizacoes = _personalizacaoAppService.GetAll();

            if (personalizacoes == null || !personalizacoes.Any())
                return NoContent();

            return Ok(_mapper.Map<IEnumerable<PersonalizacaoViewModel>>(personalizacoes));
        }

        // GET: api/Personalizacoes/5
        /// <summary>
        /// Obter uma personalização
        /// </summary>
        /// <returns>Retorna a personalização pesquisada</returns>
        /// <response code="200">Informações do registro</response>
        /// <response code="404">Registro não encontrado</response>
        [HttpGet("{id}", Name = "PersonalizacaoGetById")]
        [ProducesResponseType(typeof(PersonalizacaoViewModel), 200)]
        [ProducesResponseType(404)]
        public ActionResult Get(int id)
        {
            var personalizacao = _personalizacaoAppService.GetById(id);

            if (personalizacao == null)
                return NotFound();

            return Ok(_mapper.Map<PersonalizacaoViewModel>(personalizacao));
        }

        // POST: api/Personalizacoes
        /// <summary>
        /// Inserir uma personalização
        /// </summary>
        /// <returns>Retorna o registro inserido</returns>
        /// <response code="201">Registro criado</response>
        /// <response code="400">Requisição inválida</response>
        [HttpPost]
        [ProducesResponseType(typeof(PersonalizacaoViewModel), 201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] PersonalizacaoViewModel entity)
        {
            if (entity == null)
                return BadRequest();

            if (entity.Id != 0)
                return BadRequest("Id não deve ser informado.");

            var personalizacao = _personalizacaoAppService.Add(_mapper.Map<Personalizacao>(entity));

            return Created(string.Empty, _mapper.Map<PersonalizacaoViewModel>(personalizacao));
        }

        // PUT: api/Personalizacoes/5
        /// <summary>
        /// Atualizar uma personalização
        /// </summary>
        /// <returns>Sem retorno</returns>
        /// <response code="204">Registro atualizado</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="404">Informação não encontrada</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, [FromBody] PersonalizacaoViewModel entity)
        {
            if (entity == null)
                return BadRequest();

            if (id != entity.Id)
                return NotFound();

            var personalizacao = _personalizacaoAppService.GetById(id);

            if (personalizacao == null)
                return NotFound();

            _personalizacaoAppService.Update(_mapper.Map<Personalizacao>(entity));

            return NoContent();
        }

        // DELETE: api/Personalizacoes/5
        /// <summary>
        /// Remover uma personalização
        /// </summary>
        /// <returns>Sem retorno</returns>
        /// <response code="204">Registro removido</response>
        /// <response code="404">Informação não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            var personalizacao = _personalizacaoAppService.GetById(id);

            if (personalizacao == null)
                return NotFound();

            _personalizacaoAppService.Delete(personalizacao);

            return NoContent();
        }
    }
}