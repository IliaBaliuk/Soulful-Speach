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
    public class UserService
    {
        private IUnitOfWork context;

        public UserService(IUnitOfWork context)
        {
            this.context = context;
        }

        public bool SendFriendRequest(User fromUser, User toUser)
        {
            try
            {
                context.FriendRequests.Insert(new FriendRequest()
                {
                    FromId = fromUser.Id,
                    ToId = toUser.Id,
                    isDecline = false
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<FriendRequest> GetFriendRequestList(User user)
        {
            return context.FriendRequests.GetList(u => u.ToId == user.Id);
        }

        public bool AcceptFriendRequest(User receivingUser, User requestingUser)
        {
            try
            {
                context.Friends.Insert(new Friend()
                {
                    UserMainId = receivingUser.Id,
                    UserSubId = requestingUser.Id,
                    IsIgnore = false,
                    IsSelect = false
                });
                context.Friends.Insert(new Friend()
                {

                    UserMainId = requestingUser.Id,
                    UserSubId = receivingUser.Id,
                    IsIgnore = false,
                    IsSelect = false
                });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IList<Friend> GetFriendList(User user)
        {
            return context.Friends.GetList(u => u.UserMainId == user.Id);
        }

        public IList<Room> GetRoomList(User user)
        {
            return context.Rooms.GetList(r => r.UserRooms.Where(ur => ur.UserId == user.Id).Any());
            //return UserRoomRepository.GetList(ur => ur.UserId == user.Id)
            //    .Join(RoomRepository.GetList(),
            //    userRoom => userRoom.Id,
            //    room => room.Id,
            //    (userRoom, room) => room );
        }

        public IList<Friend> GetFavoriteFriendList(User user)
        {
            Message msg = new Message();
            return context.Friends.GetList(u => u.UserMainId == user.Id && u.IsSelect == true);
        }

        public IList<Friend> GetBlackFriendList(User user)
        {
            return context.Friends.GetList(u => u.UserMainId == user.Id && u.IsIgnore == true);
        }

        public IList<Room> SearchRoom(string userId,string name, List<Tag> tags)
        {
            return context.Rooms.GetList(r => r.TagsInRoom.Where(tir => tags.Contains(tir.Tag) || r.Name == name).Any() && !r.UserRooms.Where(u => u.UserId== userId).Any()).ToList();
        }
    }
}
