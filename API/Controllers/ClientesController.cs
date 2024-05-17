using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ICliente _cliente;

        public ClientesController(ICliente cliente)
        {
            _cliente = cliente;
        }
    
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Cliente cliente)
        {
            var result = await this._cliente.GuardarCliente(cliente);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await this._cliente.ListarCliente();
            return Ok(result);
        }
    
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Cliente cliente)
        {
            var result = await this._cliente.ActualizarCliente(cliente);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody] Cliente cliente)
        {
            var result = await this._cliente.EliminarCliente(cliente);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}