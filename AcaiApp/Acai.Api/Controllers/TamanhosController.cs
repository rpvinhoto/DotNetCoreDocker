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
        public ActionResult Get()
        {
            var tamanhos = _tamanhoAppService.GetAll();

            if (tamanhos == null || !tamanhos.Any())
                return NoContent();

            return Ok(_mapper.Map<IEnumerable<TamanhoViewModel>>(tamanhos));
        }

        // GET: api/Tamanhos/5
        [HttpGet("{id}", Name = "TamanhoGetById")]
        public ActionResult Get(int id)
        {
            var tamanho = _tamanhoAppService.GetById(id);

            if (tamanho == null)
                return NotFound();

            return Ok(_mapper.Map<TamanhoViewModel>(tamanho));
        }

        // POST: api/Tamanhos
        [HttpPost]
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
        [HttpPut("{id}")]
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
        [HttpDelete("{id}")]
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