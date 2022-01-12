using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Models;

namespace CrudApp.Repository
{
    public class CategoriesRepository : IRepository<Categories>
    {
        CrudAppDbContext dbContext;
        public CategoriesRepository()
        {
            dbContext = new CrudAppDbContext();
        }
        public int Create(Categories item)
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

        public int Delete(Categories item)
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

        public Categories FindById(int Id)
        {
            return dbContext.Kategori.Find(Id);
        }

        public List<Categories> List()
        {
            return dbContext.Kategori.ToList();
        }

        public int Update(Categories item)
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
