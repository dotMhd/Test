using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CSharpFeatures.Models;
using System.Text;
namespace CSharpFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public String Index()
        {
            return "Navigate to a URL to show an example";
        }

        public ActionResult AutoProperty() 
        {
            Product product = new Product();
            product.Name = "Kayat";
            product.Product_id = "153264";

            return View("Result", (Object)String.Format("Product Name : {0}", product.Product_id));
        }

        public ActionResult createProduct() 
        {
            Product myProduct = new Product { Product_id="100", Name="Toast", Description="Just Discrption here" 
            , category="Computers", price=2.352M};
            return View("Result",(Object)String.Format("Price is {0} for product name {1}",myProduct.price,myProduct.Name));
        }

        public ActionResult CalculatePrice() 
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name="Iphone",price=2.36M},
                    new Product {Name="Nokia", price=3.25M},
                    new Product{Name="Samsung", price=783.2M},
                    new Product{Name="google",price=412M}
                }
            };

           decimal totalPrice = cart.CalculatePrice();

           return View("Result", (Object)String.Format("Total Price is {0}", totalPrice));
        }

        public ActionResult CalcualePriceByCategory() 
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name="Iphone",price=50M,category="aa"},
                    new Product {Name="Nokia", price=50M,category="aa"},
                    new Product{Name="Samsung", price=60M,category="bb"},
                    new Product{Name="google",price=60M,category="bb"}
                }
            };

            decimal totalPRice = 0;
            IEnumerable<Product> prods = products.CalcualePriceByCategory("aa");
            foreach (var prodcut in prods)
            {
                totalPRice += prodcut.price;
            }

            return View("Result", (Object)String.Format("Total Price for aa Category is {0}", totalPRice));
        }

        public ActionResult FilterByCatergoryBB() 
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name="Iphone",price=50M,category="aa"},
                    new Product {Name="Nokia", price=50M,category="aa"},
                    new Product{Name="Samsung", price=60M,category="bb"},
                    new Product{Name="google",price=60M,category="bb"}
                }
            };

            Func<Product, bool> selectorFilter = delegate(Product prod) { return prod.category == "bb"; };
            IEnumerable<Product> filterdProducts = products.Filter(selectorFilter);
            decimal totalPrice = 0m;
            foreach (var item in filterdProducts)
	        {
                totalPrice += item.price;
	        }

            return View("Result", (Object)String.Format("Total PRice using Selector filter is " + totalPrice));
        }

        public ActionResult CreateArrayAnon() 
        {
            var anonArray = new[] {
             new {Name="MVC",Category="Book"},
             new {Name="PHP",Category="Book"},
             new {Name="ASP",Category="Book"}
            };

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in anonArray)
            {
                stringBuilder.Append(item.Name).Append(" ");
            }

            return View("Result", (Object)stringBuilder.ToString());
        }

        public ActionResult FindProducts() 
        {
            Product[] products = new Product[]
            {
                new Product{Name="ASP.Net",category="Books",price=500M},
                new Product{Name="MVC",category="Books",price=600M},
                new Product{Name="ASP",category="Books",price=400M},
                new Product{Name="Data",category="Books",price=800M},
                new Product{Name="Desgin Pattern",category="Books",price=750M},
            };

            Product[] topProducts = new Product[3];

            Array.Sort(products, (items1, items2) => 
            {
                return -1*Comparer<decimal>.Default.Compare(items1.price, items2.price);
            });

            Array.Copy(products, topProducts, 3);

            StringBuilder result = new StringBuilder();
            foreach (var item in topProducts)
            {
                result.AppendFormat("Name: {0}, Price: {1}", item.Name, item.price).Append("\n");
            }

            return View("result", (Object)result.ToString());
        }

        public ActionResult FindProductsLINQ()
        {
            Product[] products = new Product[]
            {
                new Product{Name="ASP.Net",category="Books",price=500M},
                new Product{Name="MVC",category="Books",price=600M},
                new Product{Name="ASP",category="Books",price=400M},
                new Product{Name="Data",category="Books",price=800M},
                new Product{Name="Desgin Pattern",category="Books",price=750M},
            };

            var foundProducts = from items in products
                                orderby items.price descending
                                select new { items.price, items.Name };

            int count = 0;
            StringBuilder result = new StringBuilder();
            foreach (var item in foundProducts)
            {
                if (++count <= 3)
                    result.AppendFormat("Name: {0} Price: {1} ",item.Name,item.price);
            }

            return View("result", (Object)result.ToString());

        }
    }
}