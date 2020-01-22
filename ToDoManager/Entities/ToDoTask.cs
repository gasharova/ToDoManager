using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoManager.Entities
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public int ParentListId { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        [ForeignKey("ParentListId")]
        public ToDoList ParentList { get; set; }
    }
}