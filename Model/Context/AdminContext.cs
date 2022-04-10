using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Context
{
    public class AdminContext : IDB<Admin, string>
    {
        private ShopContext context;

        public AdminContext(ShopContext context)
        {
            this.context = context;
        }

        public void Create(Admin item)
        {
            this.context.Admins.Add(item);
            this.context.SaveChanges();
        }

        public void Delete(string key)
        {
            Admin admin = this.context.Admins.Find(key);

            if (admin == null)
            {
                throw new ArgumentException("Such admin doesn't exist");
            }

            this.context.Admins.Remove(admin);
            this.context.SaveChanges();
        }

        public Admin Read(string key)
        {
            Admin admin = this.context.Admins.Find(key);

            if (admin == null)
            {
                throw new ArgumentException("Such admin doesn't exit");
            }

            return admin;
        }

        public ICollection<Admin> ReadAll()
        {
            List<Admin> admins = this.context.Admins.ToList();

            if (admins.Count == 0)
            {
                throw new ArgumentException("No orders in the DB!");
            }

            return admins;
        }
        public void Update(Admin item)
        {
            Admin adminFromDB = context.Admins.Find(item.Id);

            context.Entry<Admin>(adminFromDB).CurrentValues.SetValues(item);

            context.SaveChanges();

        }

        public ICollection<Admin> Find(int id)
        {
            ICollection<Admin> adminFromDB;

            adminFromDB = context.Admins.Where(order => order.Id == id).ToList();

            if (adminFromDB == null)
            {
                throw new ArgumentException("There is no order with that ID!");
            }

            return adminFromDB;
        }
    }
}
