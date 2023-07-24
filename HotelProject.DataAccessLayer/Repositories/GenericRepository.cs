using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using (var c = new Context())
            {
                c.Remove(t);
                c.SaveChanges();
            }
        }

        public T GetById(int id)
        {
            using (var c = new Context())
            {
                return c.Set<T>().Find(id);
                
            }
        }

        public List<T> GetList()
        {
            using (var c = new Context())
            {
                return c.Set<T>().ToList();

            }
        }

        public void Insert(T t)
        {
            using (var c = new Context())
            {
                c.Set<T>().Add(t);
                c.SaveChanges();

            }
        }

        public void Update(T t)
        {
            using (var c = new Context())
            {
                 c.Set<T>().Update(t);
                c.SaveChanges();

            }
        }
    }
}
