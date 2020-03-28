using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acai.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Acai.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaboresController : Controller
    {
        private readonly ISaborAppService _saborAppService;
        
        public SaboresController(ISaborAppService saborAppService)
        {
            _saborAppService = saborAppService;
        }

        // GET api/sabores
        [HttpGet]
        public IActionResult Index()
        {
            var teste = _saborAppService.GetAll();
            return View();
        }
    }
}