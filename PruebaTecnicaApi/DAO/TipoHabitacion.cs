using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PruebaTecnicaApi.Data;
using PruebaTecnicaApi.DTO;
using PruebaTecnicaApi.Enums;
using PruebaTecnicaApi.Models;
using System;
using System.Linq;

namespace PruebaTecnicaApi.DAO
{
    //==================================================================================================================
    public class TipoHabitacionDao
    {
        //--------------------------------------------------------------------------------------------------------------
        //                                                  //This is a Data Access Object (DAO)

        //--------------------------------------------------------------------------------------------------------------
        /*CONSTANTS*/

        //--------------------------------------------------------------------------------------------------------------
        /*INITIALIZER*/

        //--------------------------------------------------------------------------------------------------------------
        /*INSTANCE VARIABLES*/

        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TipoHabitacionDao> _logger;

        //--------------------------------------------------------------------------------------------------------------
        /*COMPUTED VARIABLES*/

        //--------------------------------------------------------------------------------------------------------------
        /*METHODS TO SUPPORT COMPUTED VARIABLES*/

        //-------------------------------------------------------------------------------------------------------------
        /*OBJECT CONSTRUCTORS*/

        //-------------------------------------------------------------------------------------------------------------
        public TipoHabitacionDao(ApiDbContext context, IMapper mapper, ILogger<TipoHabitacionDao> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        //-------------------------------------------------------------------------------------------------------------
        /*TRANSFORMATION METHODS*/

        //-------------------------------------------------------------------------------------------------------------
        public void subAddTipoHabitacion(
            TiphabidtoTipoHabitacionDto tipoHabitacionDto, 
            out RcdoperEnum rcdoperEnum)
        {
            rcdoperEnum = RcdoperEnum.Z_NULL;

            try
            {
                var tipoHabitacionEntity = _mapper.Map<TiphabentTipoHabitacionEntity>(tipoHabitacionDto);

                _context.TiposHabitacion.Add(tipoHabitacionEntity);
                _context.SaveChanges();

                rcdoperEnum = RcdoperEnum.SUCESS;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar el tipo de habitación en la base de datos.");
                rcdoperEnum = RcdoperEnum.FAILURE;
                throw; // Lanzar la excepción para que sea manejada en un nivel superior
            }
        }

        //--------------------------------------------------------------------------------------------------------------
    }
    //==================================================================================================================
}
/*END-TASK*/
