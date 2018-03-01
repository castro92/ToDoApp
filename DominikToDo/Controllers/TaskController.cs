using DominikToDo.DataAccess;
using DominikToDo.Models;
using DominikToDo.Services;
using DominikToDo.Utils;
using DominikToDo.ViewModels;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DominikToDo.Controllers
{
    public class TaskController : Controller
    {
        private TasksService tasksService;
        public TaskController()
        {
            var nhSessionDb = new NhSessionDb(App.ConnectionString);

            tasksService = new TasksService(nhSessionDb);
        }

        // GET: Task
        public ActionResult Index()
        {
            var tasks = tasksService.GetAll();
            return View(tasks);

        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                var task = model.ToModel();
                tasksService.Add(task);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 
        public ActionResult MarkTaskAsDone(int id)
        {
            var task = tasksService.Get(id);

            if (task.IsDone == false)
                task.IsDone = true;
            else
                task.IsDone = false;

            tasksService.Add(task);

            return RedirectToAction("Index");
        }


        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            var task = tasksService.Get(id);
            return View(task.ToViewModel());
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var task = tasksService.Get(id);

                task.Content = collection["Content"];
                task.Date = Convert.ToDateTime(collection["Date"]);
                if (collection["IsDone"].Equals("false"))
                    task.IsDone = false;
                else
                    task.IsDone = true;

                tasksService.Add(task);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add insert logic here
                var task = tasksService.Get(id);
                tasksService.Delete(task);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
