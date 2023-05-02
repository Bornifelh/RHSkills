using RHSkills.Services;
using RHSkills.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Application = Xamarin.Forms.Application;

namespace RHSkills.ViewModels
{
    public class LoginVewModel : BaseViewModel
    {
        private string _EmailUser;
        public string EmailUser
        {
            set
            {
                this._EmailUser = value;
                OnPropertyChanged();
            }
            get
            {
                return this._EmailUser;
            }
        }

        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Password;
            }
        }

        private string _Phone;
        public string Phone
        {
            set
            {
                this._Phone = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Phone;
            }
        }



        private string _nomPrenom;
        public string nomPrenom
        {
            set
            {
                this._nomPrenom = value;
                OnPropertyChanged();
            }
            get
            {
                return this._nomPrenom;
            }
        }


        private string _quartier;
        public string quartier
        {
            set
            {
                this._quartier = value;
                OnPropertyChanged();
            }
            get
            {
                return this._quartier;
            }
        }

        private string _Imageprofile;
        public string Imageprofile
        {
            set
            {
                this._Imageprofile = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Imageprofile;
            }
        }


        private string _DateNaissance;
        public string Datenaissance
        {
            set
            {
                this._DateNaissance = value;
                OnPropertyChanged();
            }
            get
            {
                return this._DateNaissance;
            }
        }


        private string _Matricule;
        public string Matricule
        {
            set
            {
                this._Matricule = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Matricule;
            }
        }


        private string _Pays;
        public string Pays
        {
            set
            {
                this._Pays = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Pays;
            }
        }


        private string _sexe;
        public string sexe
        {
            set
            {
                this._sexe = value;
                OnPropertyChanged();
            }
            get
            {
                return this._sexe;
            }
        }

        private string _Indicatif;
        public string Indicatif
        {
            set
            {
                this._Indicatif = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Indicatif;
            }

        }


        private string _Ville;
        public string Ville
        {
            set
            {
                this._Ville = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Ville;
            }
        }



        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return this._IsBusy;
            }
        }

        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        public LoginVewModel()
        {

            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());


        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userServices = new UserServices();
                Result = await userServices.RegisterUser(EmailUser, Password, Phone, nomPrenom, quartier, Imageprofile, Indicatif, Ville, Pays, Matricule, sexe, Datenaissance);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Félicitation", "Utilisateur enregistré", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("ERREUR",
                        "L'utilisateur existe dans la base", "OK");


            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }



        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var UserServices = new UserServices();
                Result = await UserServices.LoginUser(EmailUser, Password);
                if ( Result)
                {
                    Preferences.Set("Username", EmailUser);
                    Preferences.Set("nomPrenom", nomPrenom);
                    Preferences.Set("numTel", Phone);
                    Preferences.Set("Quartier", quartier);
                    Preferences.Set("Imageprofile", Imageprofile);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new PageMain());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erreur", "Utilisateur ou Mot de passe Invalide", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", ex.Message, "ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
