namespace TodeaAndreeaIuliana_Medii.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public ICollection<Hotel>? Hotels { get; set; }
    }
}
