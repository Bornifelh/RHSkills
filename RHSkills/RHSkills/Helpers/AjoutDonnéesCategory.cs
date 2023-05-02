using RHSkills.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Application = Xamarin.Forms.Application;

namespace RHSkills.Helpers
{
    public class AjoutDonnéesCategory
    {
        public List<Category> Categories { get; set; }

        FirebaseClient client;
        public AjoutDonnéesCategory()
        {
            client = new FirebaseClient("https://rhskillsapp-default-rtdb.firebaseio.com/");

            Categories = new List<Category>()
                {
                new Category()
             {
                    CategoryID = "Informatique",
                    CategoryName = "Informatique",
                    CategoryPoster="MainInformatique",
                    ImageUrl="https://www.ecossimo.com/wp-content/uploads/quels-sont-les-differents-types-de-maintenance-informatique.jpg"

                }

            };
        }

        public async Task AddCategoryAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", ex.Message, "OK");
            }
        }
    }
}
