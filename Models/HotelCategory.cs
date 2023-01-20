namespace TodeaAndreeaIuliana_Medii.Models
{
    public class HotelCategory
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
