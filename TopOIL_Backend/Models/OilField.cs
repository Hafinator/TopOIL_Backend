using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopOIL_Backend.Models
{
    public class OilField
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        public int NumOfEmployees { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int Production { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int NumOfPumpjacks { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Location { get; set; }
    }
}
