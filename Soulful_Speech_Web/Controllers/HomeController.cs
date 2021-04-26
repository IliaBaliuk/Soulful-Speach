using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Soulful_Speech_BLL.Services;
using Soulful_Speech_Core.Entities;
using Soulful_Speech_Web.Models;
using Soulful_Speech_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Soulful_Speech_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UserService UserService { get; set; }
        public RoomService RoomService { get; set; }
        public MessageService MessageService { get; set; }
        public UserManager<User> UserManager { get; set; }

        public HomeController(ILogger<HomeController> logger,UserService userService, UserManager<User> userManager, RoomService roomService,
            MessageService messageService)
        {
            this.UserService = userService;
            this.RoomService = roomService;
            this.UserManager = userManager;
            this.MessageService = messageService;
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUser = user.Result;
            ViewBag.UserRooms = UserService.GetRoomList(user.Result);
            ViewBag.UserFriends = UserService.GetFriendList(user.Result);
            ViewBag.UserRequests = UserService.GetFriendRequestList(user.Result);
            ViewBag.UserFavoriteFriends = UserService.GetFavoriteFriendList(user.Result);
            ViewBag.UserBlackLiserFriends = UserService.GetBlackFriendList(user.Result);
            return View();
        }

        [HttpPost]
        public IActionResult CreateRoom(CreateRoomViewModel model)
        {
            List<Tag> tags = new List<Tag>();
            foreach (var tag in model.Tags.Trim().ToLower().Split(',').ToList())
            {
                tags.Add(new Tag()
                {
                    Name = tag
                });
            }
            var user = UserManager.FindByNameAsync(User.Identity.Name);
            var room = new Room()
            {
                Name = model.RoomName,
            };
            RoomService.CreateRoom(user.Result, tags, room, RoomService.GetUserRoomRoleByName("Admin"));
            return Redirect("Index");
        }
        [HttpPost]
        public void AddRoom(string roomId)
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            RoomService.AddUserRoom(user.Id, roomId);
        }
        [HttpPost]
        public void AddUser()
        {
            throw new Exception();
        }

        public IActionResult OpenRoom(string roomId) 
        {
            ViewBag.RoomUsers = RoomService.GetRoomUsers(roomId);
            ViewBag.RoomMessages = RoomService.GetRoomMessages(roomId);
            ViewBag.CurrentRoom = RoomService.GetRoomById(roomId);
            return PartialView("ChatRoom");
        }

        public IActionResult GetFoundRooms(SearchRoomViewModel model)
        {
            List<Tag> tags = new List<Tag>();
            if (model.Tags != null)
            {  
                foreach (var tag in model.Tags.Trim().Split(',').ToList())
                {
                    tags.Add(new Tag()
                    {
                        Name = tag
                    });
                }
            }
            if (model.Name != null || model.Tags != null)
            {
                var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
                ViewBag.FoundRooms = UserService.SearchRoom(user.Id, model.Name, tags);
            }
            return PartialView("FoundRooms");
        }

        public MessageInfoViewModel SendMessage(string roomId, string message)
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            if (MessageService.SendRoomMessage(user, roomId, message))
            {
                var date = DateTime.Now.ToString("dddd, dd MMMM yyyy H:mm");
                return new MessageInfoViewModel() {DateTime = date,Message = message, UserName = user.UserName };
            }
            return null;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
