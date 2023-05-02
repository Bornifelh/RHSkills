using Firebase.Database;
using RHSkills.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHSkills.Services
{
    public class PostesItemService
    {
        FirebaseClient client;

        public PostesItemService()
        {
            client = new FirebaseClient("https://rhskillsapp-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Postes>> GetPostesItemsAsync()
        {
            var postes = (await client.Child("Postes")
                .OnceAsync<Postes>())
                .Select(f => new Postes
                {
                  CategoryID = f.Object.CategoryID,
                  PostesID = f.Object.PostesID,
                  PostesName = f.Object.PostesName,
                  DatePublication = f.Object.DatePublication,
                  Societe = f.Object.Societe,
                  VillePoste = f.Object.VillePoste,
                  NbrPoste = f.Object.NbrPoste,
                  ZoneTravail = f.Object.ZoneTravail,
                  Teletravail = f.Object.Teletravail,
                  Metier = f.Object.Metier,
                  Secteur = f.Object.Secteur,
                  ReferencePoste = f.Object.ReferencePoste,
                  DescriptionPoste = f.Object.DescriptionPoste,
                  ProfileRecherche = f.Object.ProfileRecherche,
                  RecruteurPoste = f.Object.RecruteurPoste,
                  LogoRecruteur = f.Object.LogoRecruteur,
                  LogoRh = f.Object.LogoRh,
                  PaysPoste = f.Object.PaysPoste,
                  TypeContrat = f.Object.TypeContrat,
                  ImageUrlPostes = f.Object.ImageUrlPostes,
                  RecruteurID = f.Object.RecruteurID
                }).ToList();
            return postes;
        }

        public async Task<ObservableCollection<Postes>> GetLatestPostesItemsAsync()
        {
            var latestPostesItems = new ObservableCollection<Postes>();
            var items = (await GetPostesItemsAsync()).OrderByDescending(f => f.PostesID).Take(100) ;
            foreach (var item in items)
            {
                latestPostesItems.Add(item);
            }
            return latestPostesItems;
        }
    }
}
