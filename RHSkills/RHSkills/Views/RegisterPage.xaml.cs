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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();


            SexeUser.Items.Add("Masculin");
            SexeUser.Items.Add("Féminin");
        }

        private void FmRegisterPuch_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}