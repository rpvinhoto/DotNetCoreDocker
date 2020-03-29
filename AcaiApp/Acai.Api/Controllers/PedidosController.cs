using Acai.Api.ViewModel;
using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
            var pedidos = _pedidoAppService.GetAll();

            if (pedidos == null || !pedidos.Any())
            {
                Response.StatusCode = StatusCodes.Status204NoContent;
                return null;
            }

            var detalhesPedidos = new List<DetalhesPedidoViewModel>();

            foreach (var pedido in pedidos)
            {
                var detalhesPedido = new DetalhesPedidoViewModel(pedido);
                detalhesPedidos.Add(detalhesPedido);
            }

            return detalhesPedidos;
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}", Name = "PedidoGetById")]
        public DetalhesPedidoViewModel Get(int id)
        {
            var pedido = _pedidoAppService.GetById(id);

            if (pedido == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return null;
            }

            return new DetalhesPedidoViewModel(pedido);
        }

        // POST: api/Pedidos
        [HttpPost]
        public DetalhesPedidoViewModel Post([FromBody] PedidoViewModel entity)
        {
            if (entity == null)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return null;
            }

            var pedido = _pedidoAppService.Add(_mapper.Map<Pedido>(entity));
            Response.StatusCode = StatusCodes.Status201Created;
            return new DetalhesPedidoViewModel(pedido);
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