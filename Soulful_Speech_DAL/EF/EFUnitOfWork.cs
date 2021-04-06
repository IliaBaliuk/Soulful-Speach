using Soulful_Speech_Core.Entities;
using Soulful_Speech_Core.Interfaces;
using Soulful_Speech_DAL.EF.Repository;
using Soulful_Speech_DAL.Interfaces;
using Soulful_Speech_DAL.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private SSContext db = new SSContext();

        private IUserRepository userRepository;
        private IFriendRepository friendRepository;
        private IFriendRequestRepository friendRequestRepository;
        private IMessageRepository messageRepository;
        private IPersonalMessageRepository personalMessageRepository;
        private IRoleRepository roleRepository;
        private IRoomRepository roomRepository;
        private ITagRepository tagRepository;
        private ITagInRoomRepository tagInRoomRepository;
        private IUserRoomRepository userRoomRepository;
        private IUserRoomRoleRepository userRoomRoleRepository;

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new EFUserRepository(db);
                return userRepository;
            }
        }
        public IFriendRepository Friends
        {
            get
            {
                if (friendRepository == null)
                    friendRepository = new EFFriendRepository(db);
                return friendRepository;
            }
        }
        public IFriendRequestRepository FriendRequests
        {
            get
            {
                if (friendRequestRepository == null)
                    friendRequestRepository = new EFFriendRequestRepository(db);
                return friendRequestRepository;
            }
        }
        public IMessageRepository Messages
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new EFMessageRepository(db);
                return messageRepository;
            }
        }
        public IPersonalMessageRepository PersonalMessages
        {
            get
            {
                if (personalMessageRepository == null)
                    personalMessageRepository = new EFPersonalMessageRepository(db);
                return personalMessageRepository;
            }
        }
        public IRoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new EFRoleRepository(db);
                return roleRepository;
            }
        }
        public IRoomRepository Rooms
        {
            get
            {
                if (roomRepository == null)
                    roomRepository = new EFRoomRepository(db);
                return roomRepository;
            }
        }
        public ITagRepository Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new EFTagRepository(db);
                return tagRepository;
            }
        }
        public ITagInRoomRepository TagsInRoom
        {
            get
            {
                if (tagInRoomRepository == null)
                    tagInRoomRepository = new EFTagInRoomRepository(db);
                return tagInRoomRepository;
            }
        }
        public IUserRoomRepository UserRooms
        {
            get
            {
                if (userRoomRepository == null)
                    userRoomRepository = new EFUserRoomRepository(db);
                return userRoomRepository;
            }
        }
        public IUserRoomRoleRepository UserRoomRoles
        {
            get
            {
                if (userRoomRoleRepository == null)
                    userRoomRoleRepository = new EFUserRoomRoleRepository(db);
                return userRoomRoleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
