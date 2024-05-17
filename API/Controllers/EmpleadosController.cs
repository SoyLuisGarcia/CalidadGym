using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleado _empleado;

        public EmpleadosController(IEmpleado empleado)
        {
            _empleado = empleado;
        }
    
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Empleado empleado)
        {
            var result = await this._empleado.GuardarEmpleado(empleado);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await this._empleado.ListarEmpleados();
            return Ok(result);
        }
    
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Empleado empleado)
        {
            var result = await this._empleado.ActualizarEmpleado(empleado);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody] Empleado empleado)
        {
            var result = await this._empleado.EliminarEmpleado(empleado);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}