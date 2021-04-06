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
                context.Rooms.Insert(new Room()
                {
                    Name = room.Name,
                    Theme = room.Theme,
                });
                foreach (var tag in tags)
                {

                    context.TagsInRoom.Insert(new TagInRoom()
                    {
                        Tag = tag,
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
    }
}
