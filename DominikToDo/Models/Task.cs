using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DominikToDo.Models
{
    public class Task
    {
        public virtual int Id{ get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual bool IsDone { get; set; }
    }
}