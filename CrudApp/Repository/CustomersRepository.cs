using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Models;

namespace CrudApp.Repository
{
    public class CustomersRepository : IRepository<Customer>
    {

        CrudAppDbContext dbContext;
        public CustomersRepository()
        {
            dbContext = new CrudAppDbContext();
        }

        public int Create(Customer item)
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

        public int Delete(Customer item)
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

        public Customer FindById(int Id)
        {
            return dbContext.Musteri.Find(Id);
        }

        public List<Customer> List()
        {
            return dbContext.Musteri.ToList();
        }

        public int Update(Customer item)
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
