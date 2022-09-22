using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
using SocialNetworkAPI.Models;
using System.Text.Json;

namespace SocialNetworkAPI.Controllers
{
	public class UserController : Controller
	{
		ApplicationContext _database;
		IConfiguration _configuration;
		public UserController(ApplicationContext context, IConfiguration configuration)
		{
			_database = context;
			_configuration = configuration;
		}
		public async Task<JsonResult> Index(Guid id)
		{
			var user = await _database.Users.FirstOrDefaultAsync<User>(v => v.Id == id);
			return Json(user);
		}
	}
}
