using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.HotelManagementApp.Data.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoomNo { get; set; }
        public int DaysOfStay { get; set; }
        public Rooms Room { get; set; }
    }
}
