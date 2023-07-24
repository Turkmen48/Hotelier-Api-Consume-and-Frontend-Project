using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public void BookingStatusChangeApproved(int id)
        {
            using (var context = new Context())
            {
                var value = context.Bookings.Where(x => x.BookingID == id).FirstOrDefault();
                value.Status = "Onaylandı";
                context.SaveChanges();

            }
        }

        public void BookingStatusChangeRefused(int id)
        {
            using (var context = new Context())
            {
                var value = context.Bookings.Where(x => x.BookingID == id).FirstOrDefault();
                value.Status = "İptal Edildi";
                context.SaveChanges();

            }
        }

        public void BookingStatusChangeWaiting(int id)
        {
            using (var context = new Context())
            {
                var value = context.Bookings.Where(x => x.BookingID == id).FirstOrDefault();
                value.Status = "Bekliyor";
                context.SaveChanges();

            }
        }

        public int GetBookingCount()
        {
            using (var context = new Context())
            {
                return context.Bookings.Count();

            }
        }

        public List<Booking> Last6Booking()
        {
            using (var context = new Context())
            {
                return context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();

            }
        }
    }
}
