using DogApp.Data;
using DogApp.Domain;
using DogApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Controllers
{
    public class DogsController : Controller
    {
        private readonly ApplicationDbContext context;
        public DogsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dogFormDb = new Dog
                {
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    ImageUrl = bindingModel.ImageUrl,
                };
                context.Dogs.Add(dogFormDb);
                context.SaveChanges();
                return this.RedirectToAction("Success");
            }
            return this.View();
        }
        public IActionResult Success()
        {
            return this.View();
        }
        public IActionResult All(string searchStringBreed)
        {
            List<DogAllViewModel> dogs = context.Dogs
                .Select(dogFromDb => new DogAllViewModel
                {
                    Id=dogFromDb.Id,
                    Name = dogFromDb.Name,
                    Age = dogFromDb.Age,
                    Breed = dogFromDb.Breed,
                    ImageUrl = dogFromDb.ImageUrl
                }).ToList();
            if (!String.IsNullOrEmpty(searchStringBreed))
            {
                dogs = dogs.Where(x => x.Breed.ToLower() == searchStringBreed.ToLower())
               .ToList();
            }
            return this.View(dogs);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogCreateViewModel dog = new DogCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                ImageUrl = item.ImageUrl
            };
            return View(dog);
        }
        [HttpPost]
public IActionResult Edit(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dog = new Dog
                {
                    Id = bindingModel.Id,
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    ImageUrl = bindingModel.ImageUrl
                };
                context.Dogs.Update(dog);
                context.SaveChanges();
                return this.RedirectToAction("All");
            }
            return View(bindingModel);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogCreateViewModel dog = new DogCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                ImageUrl = item.ImageUrl
            };
            return View(dog);
        }
        [HttpPost]

        public IActionResult Delete(int id)
        {
            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            context.Dogs.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Dogs");
        }
    }
}

