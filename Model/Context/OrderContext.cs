using Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class OrderContext : IDB<Order, string>
    {
        private ShopContext context;

        public OrderContext(ShopContext context)
        {
            this.context = context;
        }

        public void Create(Order item)
        {
            this.context.Orders.Add(item);
            this.context.SaveChanges();
        }

        public void Delete(string key)
        {
            Order order = this.context.Orders.Find(key);

            if (order == null)
            {
                throw new ArgumentException("Such order doesn't exist");
            }

            this.context.Orders.Remove(order);
            this.context.SaveChanges();
        }

        public Order Read(string key)
        {
            Order order = this.context.Orders.Find(key);

            if (order == null)
            {
                throw new ArgumentException("Such order doesn't exit");
            }

            return order;
        }

        public ICollection<Order> ReadAll()
        {
            List<Order> orders = this.context.Orders.ToList();

            if (orders.Count == 0)
            {
                throw new ArgumentException("No orders in the DB!");
            }

            return orders;
        }
        public void Update(Order item)
        {
            Order orderFromDB = context.Orders.Find(item.Id);

            context.Entry<Order>(orderFromDB).CurrentValues.SetValues(item);

            context.SaveChanges();

        }

        public ICollection<Order> Find(int id)
        {
            ICollection<Order> orderFromDB;

            orderFromDB = context.Orders.Where(order => order.Id == id).ToList();

            if (orderFromDB == null)
            {
                throw new ArgumentException("There is no order with that ID!");
            }

            return orderFromDB;
        }
    }
}
