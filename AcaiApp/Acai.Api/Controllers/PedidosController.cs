using Acai.Api.ViewModel;
using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Acai.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoAppService _pedidoAppService;
        private readonly IMapper _mapper;

        public PedidosController(IPedidoAppService pedidoAppService, IMapper mapper)
        {
            _pedidoAppService = pedidoAppService;
            _mapper = mapper;
        }

        // GET: api/Pedidos
        [HttpGet]
        public IEnumerable<DetalhesPedidoViewModel> Get()
        {
            return _mapper.Map<IEnumerable<DetalhesPedidoViewModel>>(_pedidoAppService.GetAll());
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}", Name = "PedidoGetById")]
        public DetalhesPedidoViewModel Get(int id)
        {
            return _mapper.Map<DetalhesPedidoViewModel>(_pedidoAppService.GetById(id));
        }

        // POST: api/Pedidos
        [HttpPost]
        public void Post([FromBody] PedidoViewModel entity)
        {
            if (entity == null)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            _pedidoAppService.Add(_mapper.Map<Pedido>(entity));

            Response.StatusCode = StatusCodes.Status201Created;
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var pedido = _pedidoAppService.GetById(id);

            if (pedido == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            _pedidoAppService.Delete(pedido);

            Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}