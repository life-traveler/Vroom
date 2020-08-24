using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vroom.Models;
using Vroom.Models.ViewModels;

namespace Vroom.Controllers
{
    public class ModelController : Controller
    {
        private readonly VroomAppDbContext _vroomAppDbContext;

        [BindProperty]
        //when posting or retrieving it automatically bind the property and we do not have to declare object
        public ModelViewModel modelViewModel { get; set; }
        public ModelController(VroomAppDbContext vroomAppDbContext)
        {
            _vroomAppDbContext = vroomAppDbContext;
            ModelViewModel modelViewModel = new ModelViewModel()
            {
                Makes = _vroomAppDbContext.Makes.ToList(),
                Model = new Models.Model()
            };
        }


        public IActionResult CreateModel()
        {
            return View(modelViewModel);
        }

       


        [HttpPost,ActionName("CreateModel")]
        public IActionResult CreatePost()
        {

            if(!ModelState.IsValid)
            {
                return View (modelViewModel);
            }


            _vroomAppDbContext.Add(modelViewModel.Model);
            _vroomAppDbContext.SaveChanges();
            return RedirectToAction(nameof(IndexModel));
        }






    public IActionResult IndexModel()
        {
            //eager loading
            //not using modelviewmodel just the view
            //Include property of EF causes the fields of Make to be included in the model table
          
           //Models is the name od the Model.cs in databse
            var models = _vroomAppDbContext.Models.Include(m => m.Make);
          
            return View(models);
            // return View(_vroomAppDbContext.Models.ToList());
        }
    }
}
