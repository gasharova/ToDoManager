using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoManager.Entities;

namespace ToDoManager.ViewModels.Shared
{
    public class BaseIndexVM<E>
        where E : BaseEntity
    {
        public List<E> Items { get; set; }
    }
}