using Soulful_Speech_DAL.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users {get; }
        public IFriendRepository Friends { get; }
        public IFriendRequestRepository FriendRequests { get; }
        public IMessageRepository Messages { get; }
        public IPersonalMessageRepository PersonalMessages { get; }
        public IRoleRepository Roles { get; }
        public IRoomRepository Rooms { get; }
        public ITagRepository Tags { get; }
        public ITagInRoomRepository TagsInRoom { get; }
        public IUserRoomRepository UserRooms { get; }
        public IUserRoomRoleRepository UserRoomRoles{ get; }

        public void Save();
    }
}
