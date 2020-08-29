using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Vroom.Models;

namespace Vroom.Controllers
{
    public class MakeController : Controller

    {
        private readonly VroomAppDbContext _vroomAppDbContext;

        public MakeController(VroomAppDbContext vroomAppDbContext)
        {
            _vroomAppDbContext = vroomAppDbContext;
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var make = _vroomAppDbContext.Makes.Find(Id);
            if (make == null)
            {
                return View(NotFound());
            }
            return View(make);
        }


        [HttpPost]
        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {

                _vroomAppDbContext.Update(make);
                _vroomAppDbContext.SaveChanges();
                return RedirectToAction(nameof(IndexMakeList));

            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var user = _vroomAppDbContext.Makes.Find(Id);

            if (user == null)
            {
                return (NotFound());
            }
           

            _vroomAppDbContext.Makes.Remove(user);
            _vroomAppDbContext.SaveChanges();
            return RedirectToAction(nameof(IndexMakeList));
        }



        [HttpGet]
        public  IActionResult Create()
        {
            
         
            return View();
        }

        [HttpPost]

        public IActionResult Create(Make make)
        {
            if(ModelState.IsValid)
            {
                Make newMake = new Make()
                {
                    Name = make.Name
                };
                _vroomAppDbContext.Add(newMake);
                _vroomAppDbContext.SaveChanges();
                //return RedirectToAction("make" , new {id = newMake.Id});
                return RedirectToAction(nameof(IndexMakeList));
            }

           
            return View(make);
        }




        //return all the makes as list
        //we have to go to the database , hence makes
        public  IActionResult IndexMakeList()
        {
            return View(_vroomAppDbContext.Makes.ToList());
        }

        //[Route("make")]
        //[Route("Make/Bikes")]
        //public IActionResult Bikes()
        //{
        //    Make make = new Make { Id = 1, Name = "HD" };
        //    return View(make);
        //}

        //[Route("make/bikes/{year:int:length(4)}/{month:int:range(1,12)}")]
        //public IActionResult ByYearMonth(int year, int month)
        //{
        //    return Content(year + " ," + month);
        //}
    }
}
