using Microsoft.AspNetCore.Mvc.RazorPages;
using TodeaAndreeaIuliana_Medii.Data;

namespace TodeaAndreeaIuliana_Medii.Models
{
    public class HotelCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(TodeaAndreeaIuliana_MediiContext context,Hotel hotel)
        {
            var allCategories = context.Category;
            var hotelCategories = new HashSet<int>(
            hotel.HotelCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = hotelCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateHotelCategories(TodeaAndreeaIuliana_MediiContext context,
        string[] selectedCategories, Hotel hotelToUpdate)
        {
            if (selectedCategories == null)
            {
                hotelToUpdate.HotelCategories = new List<HotelCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var hotelCategories = new HashSet<int>
            (hotelToUpdate.HotelCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!hotelCategories.Contains(cat.ID))
                    {
                        hotelToUpdate.HotelCategories.Add(
                        new HotelCategory
                        {
                            HotelID = hotelToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (hotelCategories.Contains(cat.ID))
                    {
                        HotelCategory courseToRemove
                        = hotelToUpdate
                        .HotelCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

