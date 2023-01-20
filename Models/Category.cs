namespace TodeaAndreeaIuliana_Medii.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<HotelCategory>? HotelCategories { get; set; }
    }
}
