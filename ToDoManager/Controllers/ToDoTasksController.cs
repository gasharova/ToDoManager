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
using ToDoManager.ViewModels.ToDoTasks;

namespace ToDoManager.Controllers
{
    [AuthFilter]
    public class ToDoTasksController : Controller
    {
        public ActionResult Index(int id)
        {
            ToDoDbContext context = new ToDoDbContext();

            IndexVM model = new IndexVM();
            model.List = context.ToDoLists
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault();
            model.Items = context.ToDoTasks
                                    .Where(i => i.ParentListId == id)
                                    .ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            CreateVM model = new CreateVM();
            model.ParentListId = id;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            ToDoTask item = new ToDoTask();
            item.Description = model.Description;
            item.ParentListId = model.ParentListId;
            item.IsDone = model.IsDone;

            ToDoDbContext context = new ToDoDbContext();
            context.ToDoTasks.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "ToDoTasks", new { Id = item.ParentListId } );
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ToDoDbContext context = new ToDoDbContext();
            ToDoTask item = context.ToDoTasks
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "ToDoTasks");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.ParentListId = item.ParentListId;
            model.Description = item.Description;
            model.IsDone = item.IsDone;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            ToDoTask item = new ToDoTask();
            item.Id = model.Id;
            item.ParentListId = model.ParentListId;
            item.Description = model.Description;
            item.IsDone = model.IsDone;

            ToDoDbContext context = new ToDoDbContext();
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index", "ToDoTasks", new { Id = item.ParentListId });
        }

        public ActionResult Delete(int id)
        {
            ToDoDbContext context = new ToDoDbContext();
            ToDoTask item = context.ToDoTasks
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault();

            context.ToDoTasks.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "ToDoTasks", new { Id = item.ParentListId });
        }

        public ActionResult Complete(int id)
        {
            ToDoDbContext context = new ToDoDbContext();
            ToDoTask item = context.ToDoTasks
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault();
            item.IsDone = true;
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index", "ToDoTasks", new { Id = item.ParentListId });
        }

        public ActionResult Reopen(int id)
        {
            ToDoDbContext context = new ToDoDbContext();
            ToDoTask item = context.ToDoTasks
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault();
            item.IsDone = false;
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index", "ToDoTasks", new { Id = item.ParentListId });
        }
    }
}