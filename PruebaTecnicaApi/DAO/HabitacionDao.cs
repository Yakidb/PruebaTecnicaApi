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
    public class HabitacionDao
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
        private readonly ILogger<HabitacionDao> _logger;

        //--------------------------------------------------------------------------------------------------------------
        /*COMPUTED VARIABLES*/

        //--------------------------------------------------------------------------------------------------------------
        /*METHODS TO SUPPORT COMPUTED VARIABLES*/

        //-------------------------------------------------------------------------------------------------------------
        /*OBJECT CONSTRUCTORS*/

        //-------------------------------------------------------------------------------------------------------------
        public HabitacionDao(ApiDbContext context, IMapper mapper, ILogger<HabitacionDao> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        //-------------------------------------------------------------------------------------------------------------
        /*TRANSFORMATION METHODS*/

        //-------------------------------------------------------------------------------------------------------------
        public void subAddHabitacion(HabidtoHabitacionDto habitacionDto, out RcdoperEnum rcdoperEnum)
        {
            rcdoperEnum = RcdoperEnum.Z_NULL;

            try
            {
                // Verificar si el host especificado existe en la base de datos
                bool HostExistente = _context.Hosts.Any(h => h.id == habitacionDto.host_id);
                if (!HostExistente)
                {
                    _logger.LogError("El host especificado no existe en la base de datos.");
                    rcdoperEnum = RcdoperEnum.FAILURE;
                    return;
                }

                // Verificar si el tipo de habitación especificado existe en la base de datos
                bool tipoHabitacionExistente = _context.TiposHabitacion.Any(t => t.id == habitacionDto.tipo_habitacion_id);
                if (!tipoHabitacionExistente)
                {
                    _logger.LogError("El tipo de habitación especificado no existe en la base de datos.");
                    rcdoperEnum = RcdoperEnum.FAILURE;
                    return;
                }

                // Mapear el DTO a una entidad de habitación
                var habitacionEntity = _mapper.Map<HabentHabitacionEntity>(habitacionDto);

                // Agregar la habitación a la base de datos
                _context.Habitaciones.Add(habitacionEntity);
                _context.SaveChanges();

                rcdoperEnum = RcdoperEnum.SUCESS;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar la habitación en la base de datos.");
                rcdoperEnum = RcdoperEnum.FAILURE;
            }
        }
        //-------------------------------------------------------------------------------------------------------------
    }
    //==================================================================================================================
}
/*END-TASK*/

