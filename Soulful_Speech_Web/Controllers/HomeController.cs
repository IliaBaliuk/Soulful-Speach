using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Soulful_Speech_BLL.Services;
using Soulful_Speech_Core.Entities;
using Soulful_Speech_Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Soulful_Speech_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UserService UserService { get; set; }
        public UserManager<User> UserManager { get; set; }

        public HomeController(ILogger<HomeController> logger,UserService userService, UserManager<User> userManager)
        {
            this.UserService = userService;
            this.UserManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUser = user;
            ViewBag.UserRooms = UserService.GetRoomList(user.Result);
            ViewBag.UserFriends = UserService.GetFriendList(user.Result);
            ViewBag.UserRequests = UserService.GetFriendRequestList(user.Result);
            ViewBag.UserFavoriteFriends = UserService.GetFavoriteFriendList(user.Result);
            ViewBag.UserBlackLiserFriends = UserService.GetBlackFriendList(user.Result);
            return View();
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
