using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RHSkills.Model
{
    [Table("CartItem")]
    public class CartItem
    {
        [AutoIncrement, PrimaryKey]
        public int CartItemId { get; set; }
        public int PostesID { get; set; }
        public string PostesName { get; set; }
        public string Pays { get; set; }
        public string Recruteur { get; set; }
    }
}
