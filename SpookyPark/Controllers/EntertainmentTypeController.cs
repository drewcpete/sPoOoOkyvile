using Microsoft.AspNetCore.Mvc;
using SpookyPark.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SpookyPark.Controllers
{
    public class EntertainmentTypesController : Controller
    {
        private readonly SpookyParkContext _db;

        public EntertainmentTypesController(SpookyParkContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<EntertainmentType> model = _db.EntertainmentTypes.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();        
        }

        [HttpPost]
        public ActionResult Create(EntertainmentType ET)
        {
            _db.EntertainmentTypes.Add(ET);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Details(int id)
        {
            EntertainmentType et = _db.EntertainmentTypes.FirstOrDefault(e => e.Id == id);
            return View(et);        
        }

    }
}