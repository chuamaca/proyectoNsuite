using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace proyecto.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        // GET: Admin/City
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(string PrefixCity)
        {
            //Note : you can bind same list from database
            List<City> ObjList = new List<City>()
            {

                new City {Idcity=1,NameCity="Latur" },
                new City {Idcity=2,NameCity="Mumbai" },
                new City {Idcity=3,NameCity="Pune" },
                new City {Idcity=4,NameCity="Delhi" },
                new City {Idcity=5,NameCity="Dehradun" },
                new City {Idcity=6,NameCity="Noida" },
                new City {Idcity=7,NameCity="New Delhi" }

        };
            //Searching records from list using LINQ query
            var CityName = (from N in ObjList
                            where N.NameCity.StartsWith(PrefixCity)
                            select new { N.NameCity });
            return Json(CityName, JsonRequestBehavior.AllowGet);
        }


    }
}