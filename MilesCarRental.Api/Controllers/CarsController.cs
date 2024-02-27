using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilesCarRental.Application.DTO.Response;
using MilesCarRental.Application.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MilesCarRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CarsController : ControllerBase
    {
        private readonly IVehiculoServices _vehiculoServices;

        public CarsController(IVehiculoServices vehiculoServices)
        {
            this._vehiculoServices = vehiculoServices;
        }

        /// <summary>
        /// Se encarga de validar la disponibilidad de los vehículos de acuerdo a fecha y lugar de recogida.
        /// </summary>
        /// <param name="PickupDate">Fecha en la que se va solicitar el servicio</param>
        /// <param name="Location">Localidad donde se va recoger el vehículo</param>
        /// <returns></returns>
        /// <response code="200">Indica que se pudo hacer la consulta</response>
        /// <response code="400">Indica error con los datos o alerta.</response>
        /// <response code="500">Devuelve alguna excepción controlada.</response>
        [HttpGet("GetAvaliableCars")]
        public async Task<IActionResult> GetAvaliableCars([FromQuery] DateTime PickupDate, [FromQuery] int Location)
        {
            try
            {
                if (PickupDate.Date < DateTime.Now.Date)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseError
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "La fecha debe ser igual o superior a la fecha actual."
                    });

                return Ok(await _vehiculoServices.GetAvaliableCars(PickupDate, Location));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseError
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Se presento un error en la búsqueda de disponibilidad de vehículos." + ex.Message
                });
            }
        }
    }
}
