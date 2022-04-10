using Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class BulkContext : IDB<BulkProduct, string>
    {
            private ShopContext context;

            public BulkContext(ShopContext context)
            {
                this.context = context;
            }

            public void Create(BulkProduct item)
            {
                this.context.BulkProducts.Add(item);
                this.context.SaveChanges();
            }

            public void Delete(string key)
            {
                BulkProduct bulk = this.context.BulkProducts.Find(key);

                if (bulk == null)
                {
                    throw new ArgumentException("Such product doesn't exist");
                }

                this.context.BulkProducts.Remove(bulk);
                this.context.SaveChanges();
            }

            public BulkProduct Read(string key)
            {
                BulkProduct bulk = this.context.BulkProducts.Find(key);

                if (bulk == null)
                {
                    throw new ArgumentException("Such product doesn't exit");
                }

                return bulk;
            }

            public ICollection<BulkProduct> ReadAll()
            {
                List<BulkProduct> bulks = this.context.BulkProducts.ToList();

                if (bulks.Count == 0)
                {
                    throw new ArgumentException("No products in the DB!");
                }

                return bulks;
            }
        public void Update(BulkProduct item)
        {
            BulkProduct bulkFromDB = context.BulkProducts.Find(item.Id);

            context.Entry<BulkProduct>(bulkFromDB).CurrentValues.SetValues(item);

            context.SaveChanges();
            
        }

        public ICollection<BulkProduct> Find(int id)
        {
            ICollection<BulkProduct> bulkFromDB;



            bulkFromDB = context.BulkProducts.Where(bulk => bulk.Id == id).ToList();


            if (bulkFromDB == null)
            {
                throw new ArgumentException("There is no product with that ID!");
            }

            return bulkFromDB;
        }

    }
}
