using Soulful_Speech_Core.Entities;
using Soulful_Speech_DAL.EF;
using Soulful_Speech_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_BLL.Services
{
    public class RoomService
    {
        IUnitOfWork context;
        public RoomService(IUnitOfWork context)
        {
            this.context = context;
        }

        public bool CreateRoom(User user, List<Tag> tags, Room room, UserRoomRole roomRole)
        {
            try
            {
                context.Rooms.Insert(room);      
                foreach (var tag in tags)
                {
                    context.Tags.Insert(tag);
                    context.TagsInRoom.Insert(new TagInRoom()
                    {
                        TagId = tag.Name,
                        RoomId = room.Id,
                    });
                }
                context.UserRooms.Insert(new UserRoom()
                {
                    UserId = user.Id,
                    RoomId = room.Id,
                    UserRoomRoleId = roomRole.Id,
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddUserRoom(string userId, string roomId)
        {
            try
            {
                context.UserRooms.Insert(new UserRoom()
                {
                    RoomId = roomId,
                    UserId = userId
                });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Role GetUserRoleByName(string name)
        {
            try
            {
                return context.Roles.GetList(r => r.Name == name).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserRoomRole GetUserRoomRoleByName(string name)
        {
            try
            {
                return context.UserRoomRoles.GetList(r => r.Name == name).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Room GetRoomdByName(string name)
        {
            try
            {
                return context.Rooms.GetList(r => r.Name == name).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Room GetRoomById(string id)
        {
            try
            {
                return context.Rooms.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Message> GetRoomMessages(string roomId, int numberOfPostedMessages)
        {
            return context.Messages.GetList(m => m.RoomId == roomId).Skip(numberOfPostedMessages).Take(30).OrderBy(m => m.DateTime).ToList();
        }

        public List<User> GetRoomUsers(string roomId)
        {
            return context.Users.GetList(u => u.UserRooms.Where(ur => ur.RoomId == roomId).Any()).ToList();

        }

        public bool IsUserAddedRoom(User user, string roomId)
        {
            var text = context.UserRooms.GetList(ur => ur.RoomId == roomId && ur.UserId == user.Id);
            if (context.UserRooms.GetList(ur => ur.RoomId == roomId && ur.UserId == user.Id).Count != 0)
            {
                return true;
            }
            return false;
        }
    }
}
