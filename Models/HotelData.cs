namespace TodeaAndreeaIuliana_Medii.Models
{
    public class HotelData
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<HotelCategory> HotelCategories { get; set; }
    }
}
