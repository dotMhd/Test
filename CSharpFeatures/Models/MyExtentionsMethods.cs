using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpFeatures.Models
{
    public static class MyExtentionsMethods
    {
        public static decimal CalculatePrice(this ShoppingCart shoppingCartParm) 
        {
            decimal totalPrice = 0;
            foreach (var product in shoppingCartParm.Products)
            {
                totalPrice += product.price;
            }

            return totalPrice;
        }

        public static decimal CalculatePriceUsingInterface(this IEnumerable<Product> shoppingCartParm)
        {
            decimal totalPrice = 0;
            foreach (var product in shoppingCartParm)
            {
                totalPrice += product.price;
            }

            return totalPrice;
        }

        public static IEnumerable<Product> CalcualePriceByCategory(this IEnumerable<Product> shoppingCartParm, String category) 
        {
            foreach (var product in shoppingCartParm)
            {
                if (product.category == category)
                    yield return product;
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> ShoppingCartParm, Func<Product,bool> selectorParm)
        {
            foreach (var product in ShoppingCartParm)
            {
                if (selectorParm(product))
                    yield return product;
            }
        }
    }
}