﻿using HotelProject.DataAccessLayer.Abstract;
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
    public class EfRoomDal : GenericRepository<Room>, IRoomDal
    {
        public int RoomCount()
        {
            using (var context = new Context())
            {
                return context.Rooms.Count();
            }
        }
    }
}
