using Acai.Api.ViewModel;
using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
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
        [SwaggerResponse(200, "Todos os registros")]
        [SwaggerResponse(204, "Não existe registros")]
        public ActionResult Get()
        {
            var pedidos = _pedidoAppService.GetAll();

            if (pedidos == null || !pedidos.Any())
                return NoContent();

            var detalhesPedidos = new List<DetalhesPedidoViewModel>();

            foreach (var pedido in pedidos)
            {
                var detalhesPedido = new DetalhesPedidoViewModel(pedido);
                detalhesPedidos.Add(detalhesPedido);
            }

            return Ok(detalhesPedidos);
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}", Name = "PedidoGetById")]
        [SwaggerResponse(200, "Informações do registros")]
        [SwaggerResponse(404, "Registro não encontrado")]
        public ActionResult Get(int id)
        {
            var pedido = _pedidoAppService.GetById(id);

            if (pedido == null)
                return NotFound();

            var detalhesPedido = new DetalhesPedidoViewModel(pedido);

            return Ok(detalhesPedido);
        }

        // POST: api/Pedidos
        [HttpPost]
        [SwaggerResponse(201, "Registro criado")]
        [SwaggerResponse(400, "Requisição inválida")]
        [SwaggerResponse(404, "Informação não encontrada")]
        public ActionResult Post([FromBody] PedidoViewModel entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest();

                var pedido = _pedidoAppService.Add(_mapper.Map<Pedido>(entity));
                var detalhesPedido = new DetalhesPedidoViewModel(pedido);

                return Created(string.Empty, detalhesPedido);
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}