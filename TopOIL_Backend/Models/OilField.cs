namespace TopOIL_Backend.Models
{
    public class OilField
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
        public int Production { get; set; }
        public int NumOfPumpjacks { get; set; }
        public string Location { get; set; }
    }
}
