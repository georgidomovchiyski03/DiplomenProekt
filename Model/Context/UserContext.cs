using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Context
{
    public class UserContext : IDB<User, string>
    {
        private ShopContext context;

        public UserContext(ShopContext context)
        {
            this.context = context;
        }

        public void Create(User item)
        {
            this.context.Users.Add(item);
            this.context.SaveChanges();
        }

        public void Delete(string key)
        {
            User user = this.context.Users.Find(key);

            if (user == null)
            {
                throw new ArgumentException("Such user doesn't exist");
            }

            this.context.Users.Remove(user);
            this.context.SaveChanges();
        }

        public User Read(string key)
        {
            User user = this.context.Users.Find(key);

            if (user == null)
            {
                throw new ArgumentException("Such order doesn't exit");
            }

            return user;
        }

        public ICollection<User> ReadAll()
        {
            List<User> users = this.context.Users.ToList();

            if (users.Count == 0)
            {
                throw new ArgumentException("No orders in the DB!");
            }

            return users;
        }
        public void Update(User item)
        {
            User orderFromDB = context.Users.Find(item.Id);

            context.Entry<User>(orderFromDB).CurrentValues.SetValues(item);

            context.SaveChanges();

        }

        public ICollection<User> Find(int id)
        {
            ICollection<User> userFromDB;

            userFromDB = context.Users.Where(user => user.Id == id).ToList();

            if (userFromDB == null)
            {
                throw new ArgumentException("There is no user with that ID!");
            }

            return userFromDB;
        }
    }
}
