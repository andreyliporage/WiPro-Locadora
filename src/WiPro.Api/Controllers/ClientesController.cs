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

        [HttpGet("{id}", Name = "GetClienteWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _service.Get(id));
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
                var result = await _service.Post(cliente);
                return Created(new Uri(Url.Link("GetClienteWithId", new { id = result.Id })), result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}