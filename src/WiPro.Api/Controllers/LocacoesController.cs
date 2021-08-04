using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WiPro.Domain.Interfaces;

namespace WiPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacoesController : ControllerBase
    {
        private readonly ILocacaoService _service;

        public LocacoesController(ILocacaoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }
    }
}