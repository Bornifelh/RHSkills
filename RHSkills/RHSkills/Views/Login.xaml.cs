using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RHSkills.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RHSkills.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();            
        }

        private void FermerFenetre_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void PasDeCompte_Clicked(object sender, EventArgs e)
        {
            Task task = Navigation.PushModalAsync(new RegisterPage());
        }

        private void MdpOublie_Clicked(object sender, EventArgs e)
        {
            Task task = Navigation.PushModalAsync(new RescueMdpPage());
        }
    }
}