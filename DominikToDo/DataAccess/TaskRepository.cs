using DominikToDo.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DominikToDo.DataAccess
{
    public class TaskRepository
    {
        private readonly ISession _session;
        private ISessionFactory session;

        public TaskRepository(ISession session)
        {
            _session = session;
        }

        public TaskRepository(ISessionFactory session)
        {
            this.session = session;
        }

        public void SaveOrUpdate(Task task)
        {
            _session.SaveOrUpdate(task);

        }

        public void Delete(Task task)
        {
            _session.Delete(task);
        }

        public Task Get(int id)
        {
            var task = _session
                .QueryOver<Task>()
                .Where(x => x.Id == id)
                .SingleOrDefault();

            return task;
        }

        public IEnumerable<Task> GetAll()
        {
            var tasks = _session
                .QueryOver<Task>()
                .List<Task>();

            return tasks;
        }

        public IEnumerable<Task> GetAllBy(DateTime date)
        {
            var tasks = _session
                .QueryOver<Task>()
                .Where(x => x.Date == date) 
                .List<Task>();

            return tasks;
        }



    }
}