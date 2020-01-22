using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoManager.Entities;

namespace ToDoManager.ViewModels.Users
{
    public class IndexVM
    {
        public List<User> Items { get; set; }
    }
}