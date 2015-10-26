using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Todo.Models;

namespace Todo.Controllers
{
    public class TodoController : Controller
    {

        private TodoContext db = new TodoContext();

        public ActionResult Index()
        {
            return View(db.TodoList.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TodoList todolist = db.TodoList.Find(id);

            if (todolist == null)
            {
                return HttpNotFound();
            }

            return View(todolist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TodoList todolist)
        {
            if (ModelState.IsValid)
            {
                db.TodoList.Add(todolist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todolist);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TodoList todolist = db.TodoList.Find(id);

            if (todolist == null)
            {
                return HttpNotFound();
            }

            return View(todolist);
        }

        [HttpPost]
        public ActionResult Edit(TodoList todolist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todolist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todolist);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TodoList todolist = db.TodoList.Find(id);

            if (todolist == null)
            {
                return HttpNotFound();
            }

            return View(todolist);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            TodoList todolist = db.TodoList.Find(id);
            db.TodoList.Remove(todolist);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}