using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IVentas _ventas;

        public VentasController(IVentas ventas)
        {
            _ventas = ventas;
        }
    
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Ventas ventas)
        {
            var result = await this._ventas.GuardarVentas(ventas);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await this._ventas.ListarVentas();
            return Ok(result);
        }
    
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Ventas ventas)
        {
            var result = await this._ventas.ActualizarVentas(ventas);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody] Ventas ventas)
        {
            var result = await this._ventas.EliminarVentas(ventas);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}