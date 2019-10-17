using Microsoft.AspNetCore.Mvc;
using SpookyPark.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;



namespace SpookyPark.Models
{

    public class Attraction
    {
        public string Name { get; set; }
        public string Desc { get ; set; }
        public string Location { get; set; }
        public int AttractionId { get; set; }
        public int EntertainmentTypeId { get; set; }
        public virtual EntertainmentType EntertainmentType { get; set; }

        public float DeathCount { get; set; }
    }
}