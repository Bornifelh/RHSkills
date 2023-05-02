using RHSkills.Model;
using RHSkills.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RHSkills.ViewModel
{
    public class PostesDetailsViewModel : BaseViewModel
    {
        private Postes _SelectedPostes;
        public Postes SelectedPostes
        {
            set
            {
                _SelectedPostes = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedPostes;
            }
        }

        private int _TotalQuantity;
        public int TotalQuantity
        {
            set
            {
                this._TotalQuantity = value;
                if (this._TotalQuantity < 0)
                    this._TotalQuantity = 0;
                OnPropertyChanged();

            }

            get
            {
                return _TotalQuantity;
            }
        }

        public Command AddToCartCommand { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command HomeCommand { get; set; }

        public PostesDetailsViewModel(Postes postes)
        {
            SelectedPostes = postes;


           
            AddToCartCommand = new Command(() => AddToCart());
            ViewCartCommand = new Command(async () => await ViewCartAsync());
            HomeCommand = new Command(async () => await GotoHomeAsync());
        }

        private async Task GotoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage());
        }

        private Task ViewCartAsync()
        {
            throw new NotImplementedException();
        }

        private async void AddToCart()
        {
            var action = await Application.Current.MainPage.DisplayAlert("Postuler", "Voulez-vous postuler à : " + SelectedPostes.PostesName, "Oui", "Non");
            if (action)
            {

                var cn = DependencyService.Get<ISQLite>().GetConnection();
                try
                {
                    CartItem ci = new CartItem()
                    {
                        PostesID = SelectedPostes.PostesID,
                        PostesName = SelectedPostes.PostesName,
                        Pays = SelectedPostes.PaysPoste,
                        Recruteur = SelectedPostes.PaysPoste
                    };
                    var item = cn.Table<CartItem>().ToList()
                        .FirstOrDefault(c => c.PostesID == SelectedPostes.PostesID);
                    if (item == null)
                        cn.Insert(ci);
                    else
                    {
                        //item.Quantity += TotalQuantity;
                        cn.Update(item);
                    }
                    cn.Commit();
                    cn.Close();
                    await Application.Current.MainPage.DisplayAlert("Postes", "Vous avez postulé au poste: " + SelectedPostes.PostesName, "OK");

                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
