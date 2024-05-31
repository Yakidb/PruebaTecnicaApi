using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaApi.Data;
using PruebaTecnicaApi.DTO;
using PruebaTecnicaApi.Enums;
using PruebaTecnicaApi.Helpers;
using PruebaTecnicaApi.Models;
using System.Collections.Generic;

namespace PruebaTecnicaApi.DAO
{
    //==================================================================================================================
    public class HostDao
    {
        //--------------------------------------------------------------------------------------------------------------
        //                                                  //This is a Data Access Object (DAO)

        //--------------------------------------------------------------------------------------------------------------
        /*CONSTANTS*/

        //--------------------------------------------------------------------------------------------------------------
        /*INITIALIZER*/

        //--------------------------------------------------------------------------------------------------------------
        /*INSTANCE VARIABLES*/

        private readonly ApiDbContext context_Z;
        private readonly IMapper mapper_Z;
        private readonly ILogger<HostDao> logger_Z;
        //--------------------------------------------------------------------------------------------------------------
        /*COMPUTED VARIABLES*/

        //--------------------------------------------------------------------------------------------------------------
        /*METHODS TO SUPPORT COMPUTED VARIABLES*/

        //-------------------------------------------------------------------------------------------------------------
        /*OBJECT CONSTRUCTORS*/

        //-------------------------------------------------------------------------------------------------------------
        public HostDao(
            ApiDbContext context_I,
            IMapper mapper_I,
            ILogger<HostDao> logger_I
            )
        {
            this.context_Z = context_I;
            this.mapper_Z = mapper_I;
            this.logger_Z = logger_I;
        }

        //-------------------------------------------------------------------------------------------------------------
        /*TRANSFORMATION METHODS*/

        //-------------------------------------------------------------------------------------------------------------
        public void subAddHost(
            //                                              //Agregar host a base de datos
            HostdtoHostDto hostDto_I,
            out RcdoperEnum rcdoperEnum_IO
            )
        {
            rcdoperEnum_IO = RcdoperEnum.Z_NULL;

            try
            {
                HostentHostEntity hostentHostEntity = this.mapper_Z.Map<HostentHostEntity>(hostDto_I);
                this.context_Z.Add(hostentHostEntity);
                this.context_Z.SaveChanges();
                rcdoperEnum_IO = RcdoperEnum.SUCESS;
                
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.logger_Z.LogErrorWrapped(BorderEnum.BorderBoth, typeof(HostDao),
                    $"Exepcion de concurrencia atrapada: {ex.Message}", "*");
                rcdoperEnum_IO = RcdoperEnum.CONCURRENCY_ISSUE;
            }
            catch (DbUpdateException ex)
            {
                this.logger_Z.LogErrorWrapped(BorderEnum.BorderBoth, typeof(HostDao),
                    $"Error al guardar registro en la base de datos: {ex.Message}", "*");
                rcdoperEnum_IO = RcdoperEnum.FAILURE;
            }
            catch (Exception ex)
            {
                this.logger_Z.LogErrorWrapped(BorderEnum.BorderBoth, typeof(HostDao),
                    $"Error desconocido ocurrido: {ex.Message}",
                    "*");
                //dbTransaction.Rollback();
                rcdoperEnum_IO = RcdoperEnum.UNKNOWN_ERROR;
            }

        }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //ACCESS METHODS.

        //--------------------------------------------------------------------------------------------------------------
        public List<HostdtoHostDto> GetAllHosts(int pageNumber, int pageSize)
        {
            List<HostdtoHostDto> hostDtos = new List<HostdtoHostDto>();
            try
            {
                var hosts = this.context_Z.Hosts
                    .Include(h => h.HabitacionesEntity)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                hostDtos = hosts.Select(host =>
                {
                    HostdtoHostDto hostDto = this.mapper_Z.Map<HostdtoHostDto>(host);
                    hostDto.HabitacionesDtos = host.HabitacionesEntity
                        .Select(hab => this.mapper_Z.Map<HabidtoHabitacionDto>(hab))
                        .ToList();
                    return hostDto;
                }).ToList();

                return hostDtos;
            }
            catch (Exception ex)
            {
                this.logger_Z.LogError(ex.Message);
                return hostDtos;
            }
        }

        //--------------------------------------------------------------------------------------------------------------
        public List<HostdtoHostDto> GetAllHostsPaginated(int pageNumber, int pageSize)
        {
            try
            {
                return GetAllHosts(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                this.logger_Z.LogError(ex.Message);
                return new List<HostdtoHostDto>();
            }
        }


        //-------------------------------------------------------------------------------------------------------------
    }
    //==================================================================================================================
}
/*END-TASK*/