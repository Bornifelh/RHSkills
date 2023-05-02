using RHSkills.Model;
using System;
using Xamarin.Forms;

namespace RHSkills.ViewModel
{
    public class CartItemService
    {


        public void RemoveItemsFromCart()
        {

            var cn = DependencyService.Get<ISQLite>().GetConnection();
            cn.DeleteAll<CartItem>();
            cn.Close();
        }

        public int GetUserCartCount()
        {
            try
            {
                var cn = DependencyService.Get<ISQLite>().GetConnection();
                var count = cn.Table<CartItem>().Count();
                return count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }

}