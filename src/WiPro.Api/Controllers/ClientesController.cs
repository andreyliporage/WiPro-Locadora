using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WiPro.Domain.Entities;
using WiPro.Domain.Interfaces;

namespace WiPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            try
            {
                return Ok(await _service.Post(cliente));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Cliente já cadastrado");
            }
        }
    }
}