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
using ToDoManager.ViewModels.ToDoLists;

namespace ToDoManager.Controllers
{
    [AuthFilter]
    public class ToDoListsController : Controller
    {
        public ActionResult Index()
        {
            User loggedUser = (User)Session["loggedUser"];

            IndexVM model = new IndexVM();

            ToDoDbContext context = new ToDoDbContext();
            model.Items = context.ToDoLists
                                    .Where(i => i.OwnerId == loggedUser.Id)
                                    .ToList();

            model.Items.AddRange(
                context.SharedToDoLists
                            .Where(i => i.UserId == loggedUser.Id)
                            .Select(i => i.SharedList)
                            .ToList()
            );

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

            User loggedUser = (User)Session["loggedUser"];

            ToDoList item = new ToDoList();
            item.Title = model.Title;
            item.Description = model.Description;
            item.OwnerId = loggedUser.Id;

            ToDoDbContext context = new ToDoDbContext();
            context.ToDoLists.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "ToDoLists");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ToDoDbContext context = new ToDoDbContext();
            ToDoList item = context.ToDoLists
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "ToDoLists");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Title = item.Title;
            model.Description = item.Description;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User loggedUser = (User)Session["loggedUser"];

            ToDoList item = new ToDoList();
            item.Id = model.Id;
            item.Title = model.Title;
            item.Description = model.Description;
            item.OwnerId = loggedUser.Id;

            ToDoDbContext context = new ToDoDbContext();
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index", "ToDoLists");
        }

        public ActionResult Delete(int id)
        {
            ToDoDbContext context = new ToDoDbContext();
            ToDoList item = context.ToDoLists
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault();

            context.ToDoLists.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "ToDoLists");
        }

        [HttpGet]
        public ActionResult Share(int id)
        {
            ToDoDbContext context = new ToDoDbContext();
            ToDoList item = context.ToDoLists
                                        .Where(i => i.Id == id)
                                        .FirstOrDefault();

            ShareVM model = new ShareVM();
            model.List = item;
            model.Users = context.Users.ToList();
            model.Shares = context.SharedToDoLists
                                        .Where(i => i.SharedListId == id)
                                        .ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Share(ShareVM model)
        {
            ToDoDbContext context = new ToDoDbContext();

            SharedToDoList item = new SharedToDoList();
            item.SharedListId = model.ListId;
            item.UserId = model.UserId;

            context.SharedToDoLists.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "ToDoLists");
        }
    }
}