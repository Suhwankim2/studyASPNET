using Microsoft.AspNetCore.Mvc;
using BoardWebApp.Models;
using BoardWebApp.data;

namespace BoardWebApp.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Note> list = _context.Notes.ToList(); // DB에 데이터 가져와서
            return View(list);
        }

        // <summary>
        // POST 액션(메서드)
        // GET 액션(메서드)
        // </summary>
        // <returns></returns>

        public IActionResult Create()
        {
            return View();
        }



        // <summary>
        // POST 액션(메서드)
        // GET 액션(메서드)
        // </summary>
        // <Param
        // <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Note note)
        {
            _context.Notes.Add(note); //INSERT 쿼리 실행
            _context.SaveChanges(); // 트랜젝션 commit

            return RedirectToAction("Index", "Note");
        }

		// <summary>
		// POST 액션(메서드)
		// GET 액션(메서드)
		// </summary>
		// <Param name=
		// <returns></returns>



		[HttpGet]

		public IActionResult Edit(int? id)
        {
            if(id is null) { return NotFound(); }

            var note = _context.Notes.Find(id);
            if (note == null) { return NotFound(); }

            return View(note);
        }
		
        
        [HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Edit(Note note)
		{
			_context.Notes.Update(note);
            _context.SaveChanges();

            return RedirectToAction("Index", "Note");
		}

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) { return NotFound();  }
            var note = _context.Notes.Find(id);
            if (note == null) { return NotFound(); }
        
            _context.Notes.Remove(note);
            _context.SaveChanges();

            return RedirectToAction("Note", "Index");
		}



		// <summary>
		// 상세보기
		// </summary>
		// <Param name="이름"> 게시글번호</param>
		// <returns></returns>
		[HttpGet]
        public IActionResult Detail(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var note = _context.Notes.Find(id); //SELECT 쿼리
            if (note == null){ return NotFound(); }


            note.ReadCount++;
            _context.Notes.Update(note); // update 쿼리
            _context.SaveChanges();


            return View(note);
        }



        
    }
}
