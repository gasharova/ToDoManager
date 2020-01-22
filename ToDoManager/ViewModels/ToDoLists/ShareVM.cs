using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoManager.Entities;

namespace ToDoManager.ViewModels.ToDoLists
{
    public class ShareVM
    {
        public int ListId { get; set; }
        public int UserId { get; set; }

        public ToDoList List { get; set; }
        public List<SharedToDoList> Shares { get; set; }
        public List<User> Users { get; set; }
    }
}