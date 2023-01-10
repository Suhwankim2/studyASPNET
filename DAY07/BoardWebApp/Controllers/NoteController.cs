using Microsoft.AspNetCore.Mvc;
using BoardWebApp.Models;
using BoardWebApp.data;
using Microsoft.EntityFrameworkCore;

namespace BoardWebApp.Controllers
{
	public class NoteController : Controller
	{
		private readonly ApplicationDbContext _context;

		public NoteController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index(int page = 1)
        {   
			
			// EntityFramework로 쿼리를 연다
			// IEnumerable<Note> list = _context.Notes.ToList(); // DB에 데이터 가져와서
            // var list= _context.Notes.FromSqlRaw($"Select Top 5* FROM Notes").ToList();
			int totalCount = _context.Notes.FromSqlRaw($"SELECT *FROM Notes").Count();
			int countNum = 10; // 게시판 한페이지에 뿌릴 글 갯수
            int totalPage = totalCount / countNum;
            if (totalCount % countNum > 0) totalPage++;
            if (totalPage < page) page = totalPage;

         
            int startPage = ((page - 1) / countNum) * countNum + 1;
            int endPage = startPage + countNum - 1;
            if (totalPage < endPage) endPage = totalPage;

			int startCount = ((page - 1) * countNum) + 1;
            int endCount = startCount + 9;


            ViewBag.StartPage = startPage;
            ViewBag.EndPage = endPage;
            ViewBag.Page = page;
            ViewBag.TotalPage = totalPage;


            //ViwData는 백엔드/프론트엔 어디서든지 슬 수 있음			
            ViewData["Title"] = "컬트롤러에서 온게시판";
			
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

			TempData["success"] = "성공적으로 저장되엇습니다.";

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
			if (id is null) { return NotFound(); }

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


			TempData["success"] = "수정되었습니다.";
			return RedirectToAction("Index", "Note");
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id is null) { return NotFound(); }
			var note = _context.Notes.Find(id);
			if (note == null) { return NotFound(); }

			return View(note);
		}
		

		//Action이름이 Delete가 아니지만 Delete로 동작하게 해주는 기능
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int? id)
		{
            if (id is null) { return NotFound(); }
            var note = _context.Notes.Find(id);
            if (note == null) { return NotFound(); }

            _context.Notes.Remove(note);
            _context.SaveChanges();

            TempData["success"] = "삭제되었습니다.";

            return RedirectToAction("Index", "Note");

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
			if (note == null) { return NotFound(); }


			note.ReadCount++;
			_context.Notes.Update(note); // update 쿼리
			_context.SaveChanges();


			return View(note);
		}




	}
}
