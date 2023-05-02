using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Xamarin.Forms;

namespace RHSkills.Model
{

    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }

        

        private void Initialize()
        {
            server = "https://rh-skills.com/php4wd.php";
            database = "xbczukun_rhskills";
            uid = "xbczukun_derly";
            password = "Decembre@20144";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private async Task<bool> OpenConnectionAsync()
        {
             try
    {
        connection.Open();
        return true;
         
         }
    catch (MySqlException ex)
    {
        //When handling errors, you can your application's response based 
        //on the error number.
        //The two most common error numbers when connecting are as follows:
        //0: Cannot connect to server.
        //1045: Invalid user name and/or password.
        switch (ex.Number)
        {
            case 0:
                await Application.Current.MainPage.DisplayAlert("Erreur","Cannot connect to server.  Contact administrator","OK");
                break;

            case 1045:
                await Application.Current.MainPage.DisplayAlert("Erreur","Invalid username/password, please try again","OK");
                break;
        }
        return false;
    }
        }
    }
}
