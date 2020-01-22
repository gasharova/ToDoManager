using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoManager.Entities;
using ToDoManager.Filters;
using ToDoManager.Repositories;
using ToDoManager.ViewModels.Users;

namespace ToDoManager.Controllers
{
    [AuthFilter]
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            IndexVM model = new IndexVM();

            ToDoDbContext context = new ToDoDbContext();
            model.Items = context.Users.ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateVM model = new CreateVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User item = new User();
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            ToDoDbContext context = new ToDoDbContext();
            context.Users.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ToDoDbContext context = new ToDoDbContext();
            User item = context.Users
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Users");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Username = item.Username;
            model.Password = item.Password;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User item = new User();
            item.Id = model.Id;
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            ToDoDbContext context = new ToDoDbContext();
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        public ActionResult Delete(int id)
        {
            ToDoDbContext context = new ToDoDbContext();
            User item = context.Users
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault();

            context.Users.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
    }
}