using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaApi.DAO;
using PruebaTecnicaApi.DTO;
using PruebaTecnicaApi.Enums;
using System.Threading.Tasks;

namespace PruebaTecnicaApi.Controllers
{
    //==================================================================================================================
    [Route("api/[controller]")]
    [ApiController]
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public class TipoHabitacionController : ControllerBase
    {
        //-------------------------------------------------------------------------------------------------------------
        private readonly TipoHabitacionDao _tipoHabitacionDao;

        //-------------------------------------------------------------------------------------------------------------
        /*OBJECT CONSTRUCTORS*/
        public TipoHabitacionController(TipoHabitacionDao tipoHabitacionDao_I)
        {
            _tipoHabitacionDao = tipoHabitacionDao_I;
        }

        //-------------------------------------------------------------------------------------------------------------
        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> CreateTipoHabitacion(TiphabidtoTipoHabitacionDto tipoHabitacionDto)
        {
            RcdoperEnum rcdoper = RcdoperEnum.Z_NULL;
            _tipoHabitacionDao.subAddTipoHabitacion(tipoHabitacionDto, out rcdoper);

            if (rcdoper == RcdoperEnum.SUCESS)
            {
                return StatusCode(201); // Created
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

