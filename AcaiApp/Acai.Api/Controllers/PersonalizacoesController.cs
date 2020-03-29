using Acai.Api.ViewModel;
using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public IEnumerable<PersonalizacaoViewModel> Get()
        {
            return _mapper.Map<IEnumerable<PersonalizacaoViewModel>>(_personalizacaoAppService.GetAll());
        }

        // GET: api/Personalizacoes/5
        [HttpGet("{id}", Name = "PersonalizacaoGetById")]
        public PersonalizacaoViewModel Get(int id)
        {
            return _mapper.Map<PersonalizacaoViewModel>(_personalizacaoAppService.GetById(id));
        }

        // POST: api/Personalizacoes
        [HttpPost]
        public void Post([FromBody] PersonalizacaoViewModel entity)
        {
            if (entity.Id != 0)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                throw new InvalidOperationException("Id não deve ser informado.");
            }

            _personalizacaoAppService.Add(_mapper.Map<Personalizacao>(entity));

            Response.StatusCode = StatusCodes.Status201Created;
        }

        // PUT: api/Personalizacoes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PersonalizacaoViewModel entity)
        {
            if (entity == null)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            if (id != entity.Id)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            var personalizacao = _personalizacaoAppService.GetById(id);

            if (personalizacao == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            _personalizacaoAppService.Update(_mapper.Map<Personalizacao>(entity));

            Response.StatusCode = StatusCodes.Status204NoContent;
        }

        // DELETE: api/Personalizacoes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var personalizacao = _personalizacaoAppService.GetById(id);

            if (personalizacao == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            _personalizacaoAppService.Delete(personalizacao);

            Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}