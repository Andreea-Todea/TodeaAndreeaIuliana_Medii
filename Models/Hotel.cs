using System.Security.Policy;

namespace TodeaAndreeaIuliana_Medii.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int RoomNumbers { get; set; }
        public decimal Price { get; set; }
        public int? CountryID { get; set; }
        public Country? Country { get; set; }
    }
}
