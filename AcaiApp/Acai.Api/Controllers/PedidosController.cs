using Acai.Api.ViewModel;
using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acai.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
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
        /// <summary>
        /// Listar todos os pedidos
        /// </summary>
        /// <returns>Retorna todos os pedidos</returns>
        /// <response code="200">Todos os pedidos cadastrados</response>
        /// <response code="204">Não existe pedidos cadastrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DetalhesPedidoViewModel>), 200)]
        [ProducesResponseType(204)]
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
        /// <summary>
        /// Obter um pedido
        /// </summary>
        /// <returns>Retorna o pedido pesquisado</returns>
        /// <response code="200">Informações do registro</response>
        /// <response code="404">Registro não encontrado</response>
        [HttpGet("{id}", Name = "PedidoGetById")]
        [ProducesResponseType(typeof(DetalhesPedidoViewModel), 200)]
        [ProducesResponseType(404)]
        public ActionResult Get(int id)
        {
            var pedido = _pedidoAppService.GetById(id);

            if (pedido == null)
                return NotFound();

            var detalhesPedido = new DetalhesPedidoViewModel(pedido);

            return Ok(detalhesPedido);
        }

        // POST: api/Pedidos
        /// <summary>
        /// Inserir um pedido
        /// </summary>
        /// <returns>Retorna o registro inserido</returns>
        /// <response code="201">Registro criado</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="404">Informação não encontrada</response>
        [HttpPost]
        [ProducesResponseType(typeof(DetalhesPedidoViewModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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