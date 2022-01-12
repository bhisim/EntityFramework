using CrudApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Repository
{
    public class UserRepository : IRepository<User>
    {

        CrudAppDbContext dbContext;
        public UserRepository()
        {
            dbContext = new CrudAppDbContext();//dependency injection mantığı
        }
        public int Create(User item)
        {
            dbContext.Add(item);

            try
            {
                
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public int Delete(User item)
        {
           

            try
            {
                dbContext.Remove(item);
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public User FindById(int Id)
        {
            return dbContext.Kullanici.Find(Id);
        }

        public List<User> List()
        {
            return dbContext.Kullanici.ToList();
        }

        public int Update(User item)
        {
            try
            {
                
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
