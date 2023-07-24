using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        

        public List<AppUser> UserListWithWorkLocation()
        {
            using (var context = new Context())
            {
                return context.Users.Include(x=>x.WorkLocation).ToList();
            }
        }

        int IAppUserDal.AppUserCount()
        {
            using (var context = new Context())
            {
                return context.Users.Count();
            }
        }
    }
}
