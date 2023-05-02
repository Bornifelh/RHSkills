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
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            Task task = Navigation.PushModalAsync(new Login());
        }

        private void NvCompte_Clicked(object sender, EventArgs e)
        {
            Task task = Navigation.PushModalAsync(new RegisterPage());
        }

        private void VoirOffres_Clicked(object sender, EventArgs e)
        {
            Task task = Navigation.PushModalAsync(new PageMain());
        }
    }
}