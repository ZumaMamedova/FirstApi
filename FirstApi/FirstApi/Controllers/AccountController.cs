using FirstApi.Dtos.Account;
using FirstApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Route("register")]
        [HttpPost]
        //public async Task<IActionResult> Register(RegisterDto registerDto)
        //{
        //    AppUser user =await _userManager.FindByNameAsync(registerDto.UserName);
        //    if (user == null) return BadRequest();
        //    user = new AppUser();
        //    user.Email=registerDto.Email;
        //    user.FullName=registerDto.FullName;
        //    user.UserName=registerDto.UserName;
        //    var result=await  _userManager.CreateAsync(user, registerDto.Password);
        //    if(!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }
        //    result = await _userManager.AddToRoleAsync(user, "Admin");
        //    if(!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }
        //    return StatusCode(201);
        //}

        [HttpGet]
        public async Task<IActionResult> CreateRole() 
        {
            var result = await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            result = await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
            result = await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
            return StatusCode(201);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            AppUser user = await _userManager.FindByNameAsync(login.UserNameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(login.UserNameOrEmail);
                if (user == null)
                {
                    return NotFound();
                }
            }
            var result = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new { token = "", message = "success" });

        }
    }
}
