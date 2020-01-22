using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoManager.Entities;
using ToDoManager.Repositories;
using ToDoManager.ViewModels.Shared;

namespace ToDoManager.Controllers
{
    public class BaseCrudController<E, R, TIndexVM, TEditVM> : Controller
        where E : BaseEntity, new()
        where R : BaseRepository<E>, new()
        where TIndexVM : BaseIndexVM<E>, new()
    {
        public ActionResult Index()
        {
            TIndexVM model = new TIndexVM();

            R repo = new R();
            model.Items = repo.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            R repo = new R();
            E item = id == null
                            ? new E()
                            : repo.GetById(id.Value);

            if (item == null)
                return RedirectToAction("Index");

            TEditVM model = new TEditVM();
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

            UsersRepository repo = new UsersRepository();
            repo.Save(item);

            return RedirectToAction("Index", "Users");
        }

        public ActionResult Delete(int id)
        {
            R repo = new R();

            E item = repo.GetById(id);
            repo.Delete(item);

            return RedirectToAction("Index");
        }
    }
}