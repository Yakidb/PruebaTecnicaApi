using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaApi.DAO;
using PruebaTecnicaApi.DTO;
using PruebaTecnicaApi.Enums;
using System.Net;

namespace PruebaTecnicaApi.Controllers
{
    //==================================================================================================================
    [Route("api/[controller]")]
    [ApiController]
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public class HabitacionController : ControllerBase
    {
        //-------------------------------------------------------------------------------------------------------------
        private readonly HabitacionDao habitacionDao_Z;

        //-------------------------------------------------------------------------------------------------------------
        /*OBJECT CONSTRUCTORS*/
        public HabitacionController(
            HabitacionDao habitacionDao_Z)
        {
            this.habitacionDao_Z = habitacionDao_Z;
        }

        //-------------------------------------------------------------------------------------------------------------
        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> RegistrarHabitacion(
            HabidtoHabitacionDto habitacionDto
            )
        {
            RcdoperEnum rcdoper = RcdoperEnum.Z_NULL;
            this.habitacionDao_Z.subAddHabitacion(habitacionDto, out rcdoper);

            HttpResponseMessage responseMessage;
            if (
                rcdoper == RcdoperEnum.SUCESS
                )
            {
                return StatusCode(201);
            }
            else
            {
                return BadRequest();
            }
        }
        //--------------------------------------------------------------------------------------------------------------
    }
    //==================================================================================================================
}
/*END-TASK*/

