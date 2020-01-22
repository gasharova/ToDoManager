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
    public class UsersController : BaseCrudController<User, UsersRepository, IndexVM>
    {

    }
}