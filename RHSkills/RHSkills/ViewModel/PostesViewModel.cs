using RHSkills.Model;
using RHSkills.Services;
using RHSkills.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RHSkills.ViewModel
{
    public class PostesViewModel : BaseViewModel
    {
        private string _UserName;
        public string UserName
        {
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
            get
            {
                return _UserName;
            }
        }

        private int _UserCartItemsCount;
        private Postes selectedPostes;

        public int UserCartItemsCount
        {
            set
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }
            get
            {
                return _UserCartItemsCount;
            }
        }

        public ObservableCollection<Category> Categories { get; set; }

        public ObservableCollection<Postes> LastItems { get; set; }

        public Command ViewCartCommand { get; set; }

        public PostesViewModel()
        {
            var uname = Preferences.Get("Userame", String.Empty);
            if (String.IsNullOrEmpty(uname))
                UserName = "Guest";
            else
                UserName = uname;


            UserCartItemsCount = new CartItemService().GetUserCartCount();
            LastItems = new ObservableCollection<Postes>();
            Categories = new ObservableCollection<Category>();

            ViewCartCommand = new Command(async () => await ViewCartAsync());

            GetCategoriesAsync();
            GetLatestItemsAsync();
        }

        private async void GetCategoriesAsync()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var item in data)
            {
                Categories.Add(item);
            }
        }

        public PostesViewModel(Postes selectedPostes)
        {
            this.selectedPostes = selectedPostes;

        }
        private async void GetLatestItemsAsync()
        {
            var data = await new PostesItemService().GetLatestPostesItemsAsync();
            LastItems.Clear();
            foreach (var item in data)
            {
                LastItems.Add(item);
            }
        }

        private Task ViewCartAsync()
        {
            throw new NotImplementedException();
        }
    }
}
