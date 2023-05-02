using RHSkills.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RHSkills.Helpers
{

    public class PostesItemData
    {
        public List<Postes> PostesItems { get; set; }

        FirebaseClient Client;
        public PostesItemData()
        {
            Client = new FirebaseClient("https://rhskillsapp-default-rtdb.firebaseio.com/");

            PostesItems = new List<Postes>()
            {
                new Postes()
                {
                    PostesID = 1,
                    CategoryID = "1",
                    ImageUrlPostes = "",
                    PostesName = "Complet Burger et Pizza",
                    DescriptionPoste = "Burger - Pizza - Breakfast",
                    DatePublication = "20221110",
                    Societe = " Best Informatique Solution",
                    Secteur = "Informatique",
                    ReferencePoste = "R01INFORMATIQUE",
                    LogoRecruteur = "",
                    LogoRh = "",
                    ZoneTravail = "",
                    Teletravail = "",
                    ProfileRecherche = "",
                    PaysPoste = "",
                    TypeContrat = "CDD",
                    Metier = "",
                    NbrPoste = "",
                    RecruteurID = "",
                    VillePoste = ""



                },
            };
        }

        public async Task AddPostesItemSync()
        {
            try
            {
                foreach (var item in PostesItems)
                {
                    await Client.Child("Postes").PostAsync(new Postes()
                    {
                        CategoryID = item.CategoryID,
                        PostesID = item.PostesID,
                        DescriptionPoste = item.DescriptionPoste,
                        ImageUrlPostes = item.ImageUrlPostes,
                        PostesName = item.PostesName,
                        DatePublication = item.DatePublication,
                        Societe = item.Societe,
                        Secteur = item.Secteur,
                        ReferencePoste = item.ReferencePoste,
                        LogoRecruteur = item.LogoRecruteur,
                        LogoRh = item.LogoRh,
                        ZoneTravail = item.ZoneTravail,
                        Teletravail = item.Teletravail,
                        ProfileRecherche = item.Teletravail,
                        PaysPoste = item.PaysPoste,
                        TypeContrat = item.TypeContrat,
                        Metier = item.Metier,
                        NbrPoste = item.NbrPoste,
                        RecruteurID = item.RecruteurID,
                        VillePoste = item.VillePoste
                    });
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", ex.Message, "OK");
            }
        }
    }
}
