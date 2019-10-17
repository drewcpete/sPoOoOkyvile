using Microsoft.AspNetCore.Mvc;
using SpookyPark.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace SpookyPark.Controllers
{
    public class AttractionsController : Controller
    {
        private readonly SpookyParkContext _db;

        public AttractionsController(SpookyParkContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Attraction> model = _db.Attractions.Include(a => a.EntertainmentType).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.EntertainmentTypeId = new SelectList(_db.EntertainmentTypes, "EntertainmentTypeId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Attraction attraction)
        {
            _db.Attractions.Add(attraction);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            Attraction attraction = _db.Attractions.FirstOrDefault(a => a.AttractionId == id);

            var thisET = _db.EntertainmentTypes.FirstOrDefault(e => e.EntertainmentTypeId == attraction.EntertainmentTypeId);
            // This line is super important for unknown reasons.  it allows @Model.EntertainmentType.Name to display in the details



            ViewBag.EntertainmentTypeName = thisET.Name;
            return View(attraction);
        }

        public ActionResult Edit(int id)
        {
            var thisAttraction = _db.Attractions.FirstOrDefault(e => e.AttractionId == id);
            return View(thisAttraction);
        }

        [HttpPost]
        public ActionResult Edit(Attraction attraction)
        {
            Console.WriteLine(attraction.Name);
            _db.Entry(attraction).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

             
        public ActionResult Delete(int id)
        {
            var thisAttraction = _db.Attractions.FirstOrDefault(attractions => attractions.AttractionId == id);
            _db.Attractions.Remove(thisAttraction);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}