using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UygulamaHavuzu.Web.Models;

namespace UygulamaHavuzu.Web.Controllers
{
    public class ToDoController : Controller
    {

        private readonly AppDbContext _context;

        public ToDoController(AppDbContext context)
        {
            _context = context;



            _context.ToDo.RemoveRange();


        }

        public IActionResult Index()
        {

            var toDoList = _context.ToDo.ToList();

            return View(toDoList);
        }

        [HttpPost]
        public IActionResult Create(ToDoModel todo)
        {


            if (ModelState.IsValid)
            {
                _context.ToDo.Add(todo);
                _context.SaveChanges();
                return Json(todo);
            }

            return BadRequest();

        }


        [HttpPost]
        public IActionResult ToggleIsDone(int id, bool isDone)
        {
            var todo = _context.ToDo.Find(id);
            if (todo != null)
            {
                todo.IsDone = isDone;
                _context.SaveChanges();
                return Ok(); // İşlem başarılı olduğunda 200 OK dönebilirsiniz
            }

            return BadRequest(); // Hata oluştuğunda 400 Bad Request dönebilirsiniz
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var todo = _context.ToDo.Find(id);
            if (todo != null)
            {
                _context.ToDo.Remove(todo);
                _context.SaveChanges();
                return Ok(); // İşlem başarılı olduğunda 200 OK dönebilirsiniz
            }

            return BadRequest(); // Hata oluştuğunda 400 Bad Request dönebilirsiniz
        }




    }
}
