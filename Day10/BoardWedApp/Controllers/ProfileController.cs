using BoardWedApp.Data;
using BoardWedApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardWedApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        // 파일 업로드 웹환경
        private readonly IWebHostEnvironment _environment;
        

        public ProfileController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
           var list = _context.Profiles.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TempProfile Temp)
        {
            if(ModelState.IsValid)
            {

                // 파일 업로드

                string upFileName = UploadImageFile(Temp);

                // 파일명 받아서 Profile에 할당!
                profile profile = new profile
                {
                    Division = Temp.Division,
                    Title = Temp.Title,
                    Description = Temp.Description,
                    Url = Temp.Url,
                    FileName = upFileName

                };
                    

                _context.Profiles.Add(profile);
                _context.SaveChanges();

                TempData["success"] = "프로필 계정완료!" ;


                return RedirectToAction("Index","ProFile");
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id is null) { return NotFound(); }

            var profile = _context.Profiles.Find(id);
            if (profile == null) { return NotFound(); }

            TempProfile temp = new TempProfile
            {
                Division = profile.Division,
                Title = profile.Title,
                Description = profile.Description,
                Url = profile.Url,
                FileName = profile.FileName
            };

            return View(temp);
        }

        [HttpPost]
        public IActionResult Edit (TempProfile temp)
        {
            if (ModelState.IsValid)
            {
                // 파일 업로드
                string upFileName = UploadImageFile(temp);

                // 새로 업로드된 파일이 없고, 이전 파일명이 있으면
                // 그 파일명을 그대로 사용!
                if (upFileName == string.Empty && temp.FileName != string.Empty)
                {
                    upFileName = temp.FileName;
                }

                



                // 파일명 받아서 TempProfile  -> Profile
                profile profile = new profile
                {

                    Id = temp.Id,
                    Division = temp.Division,
                    Title = temp.Title,
                    Description = temp.Description,
                    Url = temp.Url,
                    FileName = upFileName

                };

                _context.Profiles.Update(profile);
                _context.SaveChanges();

                TempData["success"] = "프로필 수정완료!";

                return RedirectToAction("Index", "ProFile");
            }

            return View(temp);

        }
        [HttpGet]

        public IActionResult Delete (int? id)
        {
            if(id is null) { return NotFound(); }
            var profile = _context.Profiles.Find(id);
            if (profile is null) { return NotFound(); }


            _context.Profiles.Remove(profile);
            _context.SaveChanges();

            TempData["success"] = "프로필 삭제완료!";

            return RedirectToAction("Index", "ProFile");
        }

        #region'업로드 메서드 - Routing에 관련없음'

        //



        private string UploadImageFile(TempProfile Temp)
        {
            var resultFileName = string.Empty;

            if (Temp.ProfileImage != null)
            {
                string uploadFolder = Path.Combine(_environment.WebRootPath, "Uploads");
                resultFileName = Guid.NewGuid() + "_" + Temp.ProfileImage.FileName;
                string filePath = Path.Combine(uploadFolder, resultFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Temp.ProfileImage.CopyTo(fileStream);
                }
            }
            return resultFileName;
        }

        #endregion


    }
}
