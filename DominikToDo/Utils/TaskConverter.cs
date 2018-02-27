using DominikToDo.Models;
using DominikToDo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DominikToDo.Utils
{
    public static class TaskConverter
    {
        public static Task ToModel(this TaskViewModel model)
        {
            return new Task()
            {
                Content = model.Content,
                Date = model.Date,
                IsDone = model.IsDone
            };
        }
    }
}