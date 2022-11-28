using System;
using System.ComponentModel.DataAnnotations;

namespace GroceryApi.Models
{
    public class Grocery
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public Info? Info { get; set; }
    }
}
