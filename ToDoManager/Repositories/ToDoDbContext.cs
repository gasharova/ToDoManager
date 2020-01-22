using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToDoManager.Entities;

namespace ToDoManager.Repositories
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public DbSet<SharedToDoList> SharedToDoLists { get; set; }

        public ToDoDbContext()
            : base(@"Server=localhost;Database=tododb;Trusted_Connection=True;")
        {
            Users = this.Set<User>();
            ToDoLists = this.Set<ToDoList>();
            ToDoTasks = this.Set<ToDoTask>();
            SharedToDoLists = this.Set<SharedToDoList>();
        }
    }
}