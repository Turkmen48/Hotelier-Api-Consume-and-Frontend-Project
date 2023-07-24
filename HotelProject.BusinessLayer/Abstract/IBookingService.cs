using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
    {
        void TBookingStatusChangeApproved(int id);
        void TBookingStatusChangeRefused(int id);
        void TBookingStatusChangeWaiting(int id);


        int TGetBookingCount();
        public List<Booking> TLast6Booking();

    }
}
