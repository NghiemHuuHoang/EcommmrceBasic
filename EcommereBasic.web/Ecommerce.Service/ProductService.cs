using Ecommerce.Database;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    public class ProductService
    {
        public List<Product> Products()
        {
            using (var context = new CBContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProduct(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Products.Find(ID);
            }
        }

        public void SaveProduct(Product product)
        {
            using (var context=new CBContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        
        public void UpdateProduct(Product product)
        {
            using (var context=new CBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using (var context = new CBContext())
            {
               var delete= context.Products.Find(ID);
                context.Products.Remove(delete);
                context.SaveChanges();
            }
        }
    }
}
