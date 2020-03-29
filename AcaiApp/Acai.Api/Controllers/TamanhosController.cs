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
        [HttpGet]
        public IEnumerable<TamanhoViewModel> Get()
        {
            return _mapper.Map<IEnumerable<TamanhoViewModel>>(_tamanhoAppService.GetAll());
        }

        // GET: api/Tamanhos/5
        [HttpGet("{id}", Name = "TamanhoGetById")]
        public TamanhoViewModel Get(int id)
        {
            return _mapper.Map<TamanhoViewModel>(_tamanhoAppService.GetById(id));
        }

        // POST: api/Tamanhos
        [HttpPost]
        public void Post([FromBody] TamanhoViewModel entity)
        {
            if (entity.Id != 0)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                throw new InvalidOperationException("Id não deve ser informado.");
            }

            _tamanhoAppService.Add(_mapper.Map<Tamanho>(entity));

            Response.StatusCode = StatusCodes.Status201Created;
        }

        // PUT: api/Tamanhos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TamanhoViewModel entity)
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

            var tamanho = _tamanhoAppService.GetById(id);

            if (tamanho == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            _tamanhoAppService.Update(_mapper.Map<Tamanho>(entity));

            Response.StatusCode = StatusCodes.Status204NoContent;
        }

        // DELETE: api/Tamanhos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var tamanho = _tamanhoAppService.GetById(id);

            if (tamanho == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            _tamanhoAppService.Delete(tamanho);

            Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}