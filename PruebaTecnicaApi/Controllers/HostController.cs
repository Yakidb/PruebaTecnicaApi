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
    public class HostController : ControllerBase
    {
        //-------------------------------------------------------------------------------------------------------------
        private readonly HostDao hostDao_Z;

        //-------------------------------------------------------------------------------------------------------------
        /*OBJECT CONSTRUCTORS*/
        public HostController(
            HostDao hostDao_I)
        {
            this.hostDao_Z = hostDao_I;
        }

        //-------------------------------------------------------------------------------------------------------------
        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> CreateHost(
            HostdtoHostDto hostDto
            )
        {
            RcdoperEnum rcdoper = RcdoperEnum.Z_NULL;
            this.hostDao_Z.subAddHost(hostDto, out rcdoper);

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

        //-------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("lista")]
        public ActionResult<IEnumerable<HostdtoHostDto>> GetHosts(int pageNumber, int pageSize)
        {
            var hosts = this.hostDao_Z.GetAllHosts(pageNumber, pageSize);
            return Ok(hosts);
        }

        //--------------------------------------------------------------------------------------------------------------
    }
    //==================================================================================================================
}
/*END-TASK*/
