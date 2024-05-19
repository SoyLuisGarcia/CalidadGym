using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturacionController : ControllerBase
    {
        private readonly IFacturacion _facturacion;

        public FacturacionController(IFacturacion facturacion)
        {
            _facturacion = facturacion;
        }
    
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Facturacion facturacion)
        {
            var result = await this._facturacion.GuardarFactura(facturacion);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await this._facturacion.ListarFactura();
            return Ok(result);
        }
    
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Facturacion facturacion)
        {
            var result = await this._facturacion.ActualizarFactura(facturacion);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody] Facturacion facturacion)
        {
            var result = await this._facturacion.EliminarFactura(facturacion);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}