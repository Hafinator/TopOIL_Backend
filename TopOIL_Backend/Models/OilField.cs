using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopOIL_Backend.Models
{
    public class OilField
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
        public int Production { get; set; }
        public int NumOfPumpjacks { get; set; }
        public string Location { get; set; }
    }
}
