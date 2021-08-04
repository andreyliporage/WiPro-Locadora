using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WiPro.Domain.Entities;
using WiPro.Domain.Entities.DTOs;
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

        [HttpGet("{id}", Name = "GetLocacaoWithId")]
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
        public async Task<ActionResult> Post([FromBody] LocacaoDTO locacaoDTO)
        {
            try
            {
                var result = await _service.Post(locacaoDTO);
                return Created(new Uri(Url.Link("GetLocacaoWithId", new { id = result.Id })), result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromQuery] Guid idCliente)
        {
            try
            {
                var result = await _service.Put(idCliente);
                if (result != null) return NoContent();
                else throw new Exception("Locação não encontrada");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}