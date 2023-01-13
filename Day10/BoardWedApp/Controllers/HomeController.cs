using BoardWedApp.Data;
using BoardWedApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                           WHERE Division = 'Top' 
                        ORDER BY Id DESC";
            profile top = _context.Profiles.FromSqlRaw(query).FirstOrDefault();
            if (top == null)
            {
                top = new profile
                {

                    Title = "공사중입니다",
                    Division = "Top",
                    Description = string.Empty,
                    Url = string.Empty,
                    FileName = "https://placeimg.com/900/400/mg"


                };
            }
            //
            query = @"SELECT TOP 1 *      
                            FROM profiles                             
                           WHERE Division = 'Card1'
                        ORDER BY Id DESC";
                profile card1 = _context.Profiles.FromSqlRaw(query).FirstOrDefault();

            if (card1 == null)
            {
                card1 = new profile
                {

                    Title = "Card1영역",
                    Division = "Card1",
                    Description = "카드영역입니다",
                    Url = string.Empty,
                    FileName = string.Empty


                };
            }
           
            query = @"SELECT TOP 1 *
        
                            FROM profiles                             
                           WHERE Division = 'Card2'
                        ORDER BY Id DESC";
            profile card2 = _context.Profiles.FromSqlRaw(query).FirstOrDefault();

            if (card2 == null)
            {
                card2 = new profile
                {

                    Title = "Card2영역",
                    Division = "Card2",
                    Description = "카드영역입니다",
                    Url = string.Empty,
                    FileName = string.Empty


                };
            }


            query = @"SELECT TOP 1 *        
                            FROM profiles                              
                           WHERE Division = 'Card3'
                        ORDER BY Id DESC";
            profile card3 = _context.Profiles.FromSqlRaw(query).FirstOrDefault();
            if (card3 == null)
            {
                card3 = new profile
                {
                    Title = "Card3영역",
                    Division = "Card3",
                    Description = "카드영역입니다",
                    Url = string.Empty,
                    FileName = string.Empty
                };
            }

            List<profile> list = new List<profile> { top, card1, card2, card3 };
            return View(list);

        }


        [HttpGet]

        public IActionResult About()
        {
           var query = @"SELECT TOP 1 *      
                            FROM profiles                             
                           WHERE Division = 'Card1'
                        ORDER BY Id DESC";
            profile card1 = _context.Profiles.FromSqlRaw(query).FirstOrDefault();

            if (card1 == null)
            {
                card1 = new profile
                {

                    Title = "Card1영역",
                    Division = "Card1",
                    Description = "카드영역입니다",
                    Url = string.Empty,
                    FileName = string.Empty


                };
            }

            query = @"SELECT TOP 1 *
        
                            FROM profiles                             
                           WHERE Division = 'Card2'
                        ORDER BY Id DESC";
            profile card2 = _context.Profiles.FromSqlRaw(query).FirstOrDefault();

            if (card2 == null)
            {
                card2 = new profile
                {

                    Title = "Card2영역",
                    Division = "Card2",
                    Description = "카드영역입니다",
                    Url = string.Empty,
                    FileName = string.Empty


                };
            }


            query = @"SELECT TOP 1 *        
                            FROM profiles                              
                           WHERE Division = 'Card3'
                        ORDER BY Id DESC";
            profile card3 = _context.Profiles.FromSqlRaw(query).FirstOrDefault();
            if (card3 == null)
            {
                card3 = new profile
                {
                    Title = "Card3영역",
                    Division = "Card3",
                    Description = "카드영역입니다",
                    Url = string.Empty,
                    FileName = string.Empty
                };
            }

            List<profile> list = new List<profile> { card1, card2, card3 };
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