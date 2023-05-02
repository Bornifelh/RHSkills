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
    public partial class OffresPage : ContentPage
    {
        public OffresPage()
        {
            InitializeComponent();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}