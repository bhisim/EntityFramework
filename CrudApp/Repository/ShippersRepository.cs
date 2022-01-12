using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Models;

namespace CrudApp.Repository
{
    public class ShippersRepository : IRepository<Shippers>
    {
        CrudAppDbContext dbContext;
        public ShippersRepository()
        {
            dbContext = new CrudAppDbContext();//dependency injection mantığı
        }
        public int Create(Shippers item)
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

        public int Delete(Shippers item)
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

        public Shippers FindById(int Id)
        {
            return dbContext.Nakliyeci.Find(Id);
        }

        public List<Shippers> List()
        {
            return dbContext.Nakliyeci.ToList();
        }

        public int Update(Shippers item)
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
