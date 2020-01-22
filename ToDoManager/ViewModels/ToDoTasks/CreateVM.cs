using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoManager.ViewModels.ToDoTasks
{
    public class CreateVM
    {
        public int ParentListId { get; set; }

        [DisplayName("Description: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Description { get; set; }

        [DisplayName("Is Done: ")]
        public bool IsDone { get; set; }
    }
}