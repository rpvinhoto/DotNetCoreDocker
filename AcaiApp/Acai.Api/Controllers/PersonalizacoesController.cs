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
        [HttpGet]
        public ActionResult Get()
        {
            var personalizacoes = _personalizacaoAppService.GetAll();

            if (personalizacoes == null || !personalizacoes.Any())
                return NoContent();

            return Ok(_mapper.Map<IEnumerable<PersonalizacaoViewModel>>(personalizacoes));
        }

        // GET: api/Personalizacoes/5
        [HttpGet("{id}", Name = "PersonalizacaoGetById")]
        public ActionResult Get(int id)
        {
            var personalizacao = _personalizacaoAppService.GetById(id);

            if (personalizacao == null)
                return NotFound();

            return Ok(_mapper.Map<PersonalizacaoViewModel>(personalizacao));
        }

        // POST: api/Personalizacoes
        [HttpPost]
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
        [HttpPut("{id}")]
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
        [HttpDelete("{id}")]
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