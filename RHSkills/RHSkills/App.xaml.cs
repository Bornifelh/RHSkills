using RHSkills.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RHSkills
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new Login();
           MainPage = new WelcomePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
