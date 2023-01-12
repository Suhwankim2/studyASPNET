using BoardWedApp.Data;
using BoardWedApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BoardWedApp.Controllers
{
    public class HomeController : Controller
    {
 
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            //DB에서 데이터 로드
            var query = @"SELECT TOP 1 *
                            FROM profiles 
                           WHERE Division = 'TOP' 
                        ORDER BY Id DESC";
            profile top = _context.Profiles.FromSqlRaw(query).FirstOrDefault();
            if (top == null)
            {
                top = new profile
                {

                    Title = "공사중입니다",
                    Description = string.Empty,
                    Url = string.Empty,
                    FileName = string.Empty


                };
            }
            query = @"SELECT TOP 1 *
        
                            FROM profiles 
                              
                           WHERE Division = 'TOP'
                        ORDER BY Id DESC";
                profile card1 = _context.Profiles.FromSqlRaw(query).FirstOrDefault();

            if (card1 == null)
            {
                card1 = new profile
                {

                    Title = "공사중입니다",
                    Description = string.Empty,
                    Url = string.Empty,
                    FileName = string.Empty


                };
            }
            List<profile> list = new List<profile>();
            list.Add(top);
            list.Add(card1);

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}