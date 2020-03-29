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
        public IEnumerable<SaborViewModel> Get()
        {
            return _mapper.Map<IEnumerable<SaborViewModel>>(_saborAppService.GetAll());
        }

        // GET: api/Sabores/5
        [HttpGet("{id}", Name = "SaborGetById")]
        public SaborViewModel Get(int id)
        {
            return _mapper.Map<SaborViewModel>(_saborAppService.GetById(id));
        }

        // POST: api/Sabores
        [HttpPost]
        public void Post([FromBody] SaborViewModel entity)
        {
            if (entity.Id != 0)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                throw new ApplicationException("Id não deve ser informado.");
            }

            _saborAppService.Add(_mapper.Map<Sabor>(entity));

            Response.StatusCode = StatusCodes.Status201Created;
        }

        // PUT: api/Sabores/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SaborViewModel entity)
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

            var sabor = _saborAppService.GetById(id);

            if (sabor == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            _saborAppService.Update(_mapper.Map<Sabor>(entity));

            Response.StatusCode = StatusCodes.Status204NoContent;
        }

        // DELETE: api/Sabores/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var sabor = _saborAppService.GetById(id);

            if (sabor == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            _saborAppService.Delete(sabor);

            Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}