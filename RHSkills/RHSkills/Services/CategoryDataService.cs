using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database.Query;
using RHSkills.Model;

namespace RHSkills.Services
{
    public class CategoryDataService
    {

        FirebaseClient client;
        public CategoryDataService()
        {
            client = new FirebaseClient("https://rhskillsapp-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        { 
            var categoties = (await client.Child("Categories")
                .OnceAsync<Category>())
                .Select(c => new Category
                {
                    CategoryID = c.Object.CategoryID,
                    CategoryName = c.Object.CategoryName,
                    CategoryPoster = c.Object.CategoryPoster,
                    ImageUrl = c.Object.ImageUrl
                }).ToList();

            return categoties;
        }
        
    }
}
