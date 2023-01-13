using BoardWedApp.Data;
using BoardWedApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BoardWedApp.Controllers
{
	public class NoteController : Controller
	{
		private readonly ApplicationDbContext _context;

		public NoteController(ApplicationDbContext context)
		{
			_context = context;
		}
		/// <summary>
		/// 기본 리스트 조회화면
		/// </summary>
		/// <returns></returns>

		public IActionResult Index(int page = 1)
		{
			// EntityFramework로 쿼리없지
			//IEnumerable<Note> list = _context.Notes.ToList(); //DB에서 데이터를 가져와서

			//var list = _context.Notes.FromSqlRaw($"SELECT TOP 5 * FROM Notes").ToList();
			int totalCount = _context.Notes.FromSqlRaw($"SELECT * FROM Notes").Count(); //12개
			int countNum = 10; // 게시판 한페이지에 뿌릴 글 갯수
			int totalPage = totalCount / countNum;

			if (totalCount % countNum > 0) totalPage++;  // 페이지수를 하나더 증가
			if (totalPage < page) page = totalPage;

			int startpage = ((page - 1) / countNum) * countNum + 1;
			int endpage = startpage + countNum - 1; // 10
			if (totalPage < endpage) endpage = totalPage;

			int startCount = ((page - 1) * countNum) + 1;
			int endCount = startCount + 9; // 10,20

			ViewBag.StartPage = startpage;
			ViewBag.EndPage = endpage;
			ViewBag.Page = page;
			ViewBag.TotalPage = totalPage;


            var list = _context.Notes.FromSqlRaw($"EXECUTE dbo.USP_PagingNotes @StartCount={startCount}, @EndCount = {endCount}").ToList();

            // ViewDate는 백앤드/프론트앤드 어디서든지 쓸수 있음.
            ViewData["Title"] = "컨트롤러에서 온 게시판"; 

			
			return View(list);
		}

		/// <summary>
		/// GET 액션(메서드)
		/// dssd
		/// </summary>
		/// <returns></returns>
		public IActionResult Create()
		{
			return View();
		}

		/// <summary>
		/// POST 액션(메서드)
		/// </summary>
		/// <param name="note">프론트앤드에서 작성한 모델</param>
		/// <returns>리스트로 다시 돌아감</returns>
		[HttpPost]
		[ValidateAntiForgeryToken] //크로스사이트 요청 위조 막는 부분
		public IActionResult Create(Note note)
		{
			_context.Notes.Add(note); //Insert 쿼리 실행
			_context.SaveChanges(); //트랜잭션 commit

			//처리 메세지 추가
			TempData["success"] = "저장되었습니다.";

			return RedirectToAction("Index", "Note");
		}

		/// <summary>
		/// Edit 액션
		/// </summary>
		/// <param name="id">수정할 글 아이디</param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id is null) { return NotFound(); }

			var note = _context.Notes.Find(id);

			return View(note);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Note note)
		{
			_context.Notes.Update(note);
			_context.SaveChanges();

			//수정메세지
			TempData["success"] = "수정되었습니다.";

			return RedirectToAction("Index", "Note");
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id is null) { return NotFound(); }

			var note = _context.Notes.Find(id);

			if (note is null) { return NotFound(); }

			return View(note);
		}

		// Action 이름이 Delete 가 아니지만 Delete 로 동작하게 해주는 기능
		[HttpPost , ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int? id)
		{
			if (id is null) { return NotFound(); }

			var note = _context.Notes.Find(id);

			if (note is null) { return NotFound(); }

			_context.Notes.Remove(note); //DELETE 쿼리
			_context.SaveChanges();

			//삭제 메세지
			TempData["success"] = "삭제 되었습니다";

			return RedirectToAction("Index", "Note");
		}

		/// <summary>
		/// 상세보기
		/// </summary>
		/// <param name="id">게시글 번호</param>
		/// <returns></returns>
		[HttpGet] // Default 값임. 안써도 상관 없다.
		public IActionResult Detail(int? id)
		{            //null 처리
			if (id is null) { return NotFound(); }

			var note = _context.Notes.Find(id);  //SELECT 쿼리
			if (note == null) { return NotFound(); }

			note.ReadCount += 1;
			_context.Notes.Update(note); // UPDATE 쿼리
			_context.SaveChanges();

			return View(note);
		}

	}
}

