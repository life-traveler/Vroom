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
        //when posting or retrieving it automatically bind the property and we do not have to exclusively pass an object
       // new PropertyAccessMode of type ModelViewModel
        public ModelViewModel modelViewModel { get; set; }

        //initialize the constructor of controller
        public ModelController(VroomAppDbContext vroomAppDbContext)
        {
            _vroomAppDbContext = vroomAppDbContext;
            //initialize modelViewModel with new ModelViewModel
             modelViewModel = new ModelViewModel()
            {
                 //assign makes from databse
                Makes = _vroomAppDbContext.Makes.ToList(),
                //assign new model
                Model = new Models.Model()
            };
        }



        public IActionResult Delete(int id)
        {
            Model modelUser = _vroomAppDbContext.Models.Find(id);

            _vroomAppDbContext.Remove(modelUser);
            _vroomAppDbContext.SaveChanges();
            return View(nameof(IndexModel));
        }


        [HttpGet]
        public IActionResult EditModel(int Id)
        {
            modelViewModel.Model = _vroomAppDbContext.Models.Include(m => m.Make).SingleOrDefault(m => m.Id == Id);
            return View(modelViewModel);
        }

        //because we have done BindProperty we, do not hav eto passthe model here
        //public ModelViewModel modelViewModel { get; set; } as
        //public IActionResult EditModelPost( ModelViewModel modelViewModel)
        [HttpPost, ActionName("EditModel")]
        public IActionResult EditModelPost()
        {
            if (!ModelState.IsValid)
            {
                return View(modelViewModel);
            }

            _vroomAppDbContext.Update(modelViewModel.Model);
            _vroomAppDbContext.SaveChanges();
           
            return RedirectToAction(nameof(IndexModel));
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
          //FK refrence of makes in model, so eager loading acn be used
           //Models is the name od the Model.cs in database
            var models = _vroomAppDbContext.Models.Include(m => m.Make);
          
            return View(models);
            // return View(_vroomAppDbContext.Models.ToList());
        }
    }
}
