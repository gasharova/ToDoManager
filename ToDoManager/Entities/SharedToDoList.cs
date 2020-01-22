using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoManager.Entities
{
    public class SharedToDoList : BaseEntity
    {
        public int SharedListId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("SharedListId")]
        public ToDoList SharedList { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}