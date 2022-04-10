using Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class PackegedContext : IDB<PackegedProduct, string>
    {
            private ShopContext context;

            public PackegedContext(ShopContext context)
            {
                this.context = context;
            }

            public void Create(PackegedProduct item)
            {
                this.context.PackegedProducts.Add(item);
                this.context.SaveChanges();
            }

            public void Delete(string key)
            {
                PackegedProduct packeged = this.context.PackegedProducts.Find(key);

                if (packeged == null)
                {
                    throw new ArgumentException("Such a product doesn't exist");
                }

                this.context.PackegedProducts.Remove(packeged);
                this.context.SaveChanges();
            }

            public PackegedProduct Read(string key)
            {
                PackegedProduct packeged = this.context.PackegedProducts.Find(key);

                if (packeged == null)
                {
                    throw new ArgumentException("Such product doesn't exit");
                }

                return  packeged;
            }

            public ICollection<PackegedProduct> ReadAll()
            {
                List<PackegedProduct> packegedProducts = this.context.PackegedProducts.ToList();

                if (packegedProducts.Count == 0)
                {
                    throw new ArgumentException("No products in the DB!");
                }

                return packegedProducts;
            }

        public void Update(PackegedProduct item)
        {
            PackegedProduct packegedFromDB = context.PackegedProducts.Find(item.Id);

            context.Entry<PackegedProduct>(packegedFromDB).CurrentValues.SetValues(item);
            
            context.SaveChanges();
            
        }

        public ICollection<PackegedProduct> Find(int id)
        {
            ICollection<PackegedProduct> packegedFromDB;

            
            
            packegedFromDB = context.PackegedProducts.Where(packeged => packeged.Id == id).ToList();
           

            if (packegedFromDB == null)
            {
                throw new ArgumentException("There is no product with that ID!");
            }

            return packegedFromDB;
        }

    }
}
