using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.HotelManagementApp.Data.Model
{
    public class Rooms
    {
        public int RoomNo { get; set; }
        public int TypeId { get; set; }
        public RoomType RoomType { get; set; }
    }
}
