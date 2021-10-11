using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.HotelManagementApp.Data.Model
{
    public class Service
    {
        public int Id { get; set; }
        public int RoomNo { get; set; }
        public decimal Amount { get; set; }
        public Rooms room { get; set; }
    }   
}
