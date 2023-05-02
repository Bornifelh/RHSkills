using RHSkills.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RHSkills.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        async void ButtonCategories_Clicked(object sender, EventArgs e)
        {
            var acd = new AjoutDonnéesCategory();
            await acd.AddCategoryAsync();
        }

        async void ButtonProducts_Clicked(object sender, EventArgs e)
        {
            var afd = new PostesItemData();
            await afd.AddPostesItemSync();
        }
    }
}