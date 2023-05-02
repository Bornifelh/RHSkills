using RHSkills.Model;
using Firebase.Database;
using System;
using System.Linq;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace RHSkills.Services
{
    public class UserServices
    {
        FirebaseClient client;

        public UserServices()
        {
            client = new FirebaseClient("https://rhskillsapp-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> IsUserExist(string uname)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where( u => u.Object.EmailUser == uname).FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> RegisterUser(string uname, string passwd, string phone, string nomPrenom, string quartier, string Imageprofile, string Indicatif, string Ville, string Pays, string Matricule, string sexe, string datenaissance)
        {
            if (await IsUserExist(uname) == false)
            {
                await client.Child("Users")
            .PostAsync(new User()
            {
                EmailUser = uname,
                Password = passwd,
                Phone = phone,
                NomPrenom = nomPrenom,
                Quartier = quartier,
                ImageProfile = Imageprofile,
                Indicatif = Indicatif,
                Pays = Pays,
                Matricule = Matricule,
                VilleUser = Ville,
                sexe = sexe,
                DateNaissance = datenaissance

            });
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public async Task<bool>LoginUser(string uname, string passwd)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where( u => u.Object.EmailUser == uname)
                .Where(u => u.Object.Password == passwd).FirstOrDefault();

            return (user != null);
        }
    }
}
