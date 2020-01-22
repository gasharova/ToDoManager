using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoManager.Entities;

namespace ToDoManager.ViewModels.ToDoTasks
{
    public class IndexVM
    {
        public ToDoList List { get; set; }
        public List<ToDoTask> Items { get; set; }
    }
}