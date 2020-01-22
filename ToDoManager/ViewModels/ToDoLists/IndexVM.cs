using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoManager.Entities;

namespace ToDoManager.ViewModels.ToDoLists
{
    public class IndexVM
    {
        public List<ToDoList> Items { get; set; }
    }
}