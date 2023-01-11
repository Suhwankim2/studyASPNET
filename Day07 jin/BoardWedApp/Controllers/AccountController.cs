using BoardWedApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardWedApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signManager;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
		{
			this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
			this.signManager = signManager ?? throw new ArgumentNullException(nameof(signManager));
		}

		//회원가입 첫화면 들어갈때 액션메서드

		[HttpGet]
	public IActionResult Register() 
		{
			return View();
		}

		//회원가입 버튼 누른 후 DB처리 액션 (메서드)

		[HttpPost]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			if (ModelState.IsValid) // 입력값이 필수라고 한게 하나로 입력만되면 false
			{	
				//ASP.NET Identity만든 유저로 생성
				var user = new IdentityUser
				{
					Id = model.Id,
					UserName= model.UserName,
					Email= model.Email,
					PhoneNumber = model.PhoneNumber,
				};
				
			}
            return View(model);
        }
	}
}
