using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Repository
{
   public interface IRepository<T> where T : class
    {
        int Create(T item);
        int Update(T item);
        int Delete(T item);

        T FindById(int Id);
        List<T> List();
    }
}
