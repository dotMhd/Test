using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpFeatures.Models
{
    public class Product
    {
        private string product_id;
        public String Name { get; set; }
        public String Product_id 
        { 
            get { return Name + " " + product_id; }
            set { product_id = value; } 
        }
        public String Description { get; set; }
        public decimal price { get; set; }
        public String category { get; set; }

    }
}