using System;
using System.Collections.Generic;

namespace VehicleDB.Models
{
    public class Store
    {
        public int StoreID { get; set; }
        public string Location { get; set; }
        public StoreHours Hours { get; set; }
    }

    public class StoreHours
    {
        public DayOfWeek Day { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
    }
}
