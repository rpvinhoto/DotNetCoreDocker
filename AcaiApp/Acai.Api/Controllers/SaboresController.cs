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
        [HttpGet]
        public ActionResult Get()
        {
            var sabores = _saborAppService.GetAll();

            if (sabores == null || !sabores.Any())
                return NoContent();

            return Ok(_mapper.Map<IEnumerable<SaborViewModel>>(sabores));
        }

        // GET: api/Sabores/5
        [HttpGet("{id}", Name = "SaborGetById")]
        public ActionResult Get(int id)
        {
            var sabor = _saborAppService.GetById(id);

            if (sabor == null)
                return NotFound();

            return Ok(_mapper.Map<SaborViewModel>(sabor));
        }

        // POST: api/Sabores
        [HttpPost]
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
        [HttpPut("{id}")]
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
        [HttpDelete("{id}")]
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