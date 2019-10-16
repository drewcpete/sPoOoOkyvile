using System;
using System.Collections.Generic;


namespace SpookyPark.Models
{
    public class Attraction
    {
        public string Name { get; set; }
        public string Desc { get ; set; }
        public string Location { get; set; }
        public int Id { get; set; }
        public int ETid { get; set; }
        public virtual EntertainmentType EntertainmentType { get; set; }



        public float DeathCount { get; set; }
    }

}