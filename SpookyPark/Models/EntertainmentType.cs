using System;
using System.Collections.Generic;


namespace SpookyPark.Models
{
    public class EntertainmentType
    {
        public EntertainmentType ()
        {
            this.Attractions = new HashSet<Attraction>();
        }

        
        public string Name { get; set; }
        public int Price { get; set; }
        public bool AgeRestriction {get; set;}
        public int Id { get; set; }
        public virtual ICollection<Attraction> Attractions { get; set; }
   }
}