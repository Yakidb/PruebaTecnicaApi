using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaApi.Models
{
    [Table("habitaciones")]
    public class HabentHabitacionEntity
    {
        //--------------------------------------------------------------------------------------------------------------
        /*PRIMARY KEY*/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        //--------------------------------------------------------------------------------------------------------------
        /*COLUMNS*/
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(255)]
        public string descripcion { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal precio { get; set; }

        [Required]
        [StringLength(20)]
        public string codigo { get; set; }

        [Required]
        public bool es_activo { get; set; }

        //--------------------------------------------------------------------------------------------------------------
        /*FOREIGN KEYS*/
        [Required]
        [ForeignKey("host_id")]
        public int host_id { get; set; }
        public virtual HostentHostEntity? HostEntity { get; set; }

        [Required]
        [ForeignKey("tipo_habitacion_id")]
        public int tipo_habitacion_id { get; set; }
        public virtual  TiphabentTipoHabitacionEntity? TipoHabitacionEntity { get; set; }
    }
}
