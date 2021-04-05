using Soulful_Speech_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_DAL.EF
{
    public class UnitOfWork : IDisposable
    {
        private SSContext db = new SSContext();

        private Repository<User> userRepository;
        private Repository<Friend> friendRepository;
        private Repository<FriendRequest> friendRequestRepository;
        private Repository<Message> messageRepository;
        private Repository<PersonalMessage> personalMessageRepository;
        private Repository<Role> roleRepository;
        private Repository<Room> roomRepository;
        private Repository<Tag> tagRepository;
        private Repository<TagInRoom> tagInRoomRepository;
        private Repository<UserRoom> userRoomRepository;
        private Repository<UserRoomRole> userRoomRoleRepository;

        public Repository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new Repository<User>(db);
                return userRepository;
            }
        }
        public Repository<Friend> Friends
        {
            get
            {
                if (friendRepository == null)
                    friendRepository = new Repository<Friend>(db);
                return friendRepository;
            }
        }
        public Repository<FriendRequest> FriendRequests
        {
            get
            {
                if (friendRequestRepository == null)
                    friendRequestRepository = new Repository<FriendRequest>(db);
                return friendRequestRepository;
            }
        }
        public Repository<Message> Messages
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new Repository<Message>(db);
                return messageRepository;
            }
        }
        public Repository<PersonalMessage> PersonalMessages
        {
            get
            {
                if (personalMessageRepository == null)
                    personalMessageRepository = new Repository<PersonalMessage>(db);
                return personalMessageRepository;
            }
        }
        public Repository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new Repository<Role>(db);
                return roleRepository;
            }
        }
        public Repository<Room> Rooms
        {
            get
            {
                if (roomRepository == null)
                    roomRepository = new Repository<Room>(db);
                return roomRepository;
            }
        }
        public Repository<Tag> Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new Repository<Tag>(db);
                return tagRepository;
            }
        }

        public Repository<TagInRoom> TagsInRoom
        {
            get
            {
                if (tagInRoomRepository == null)
                    tagInRoomRepository = new Repository<TagInRoom>(db);
                return tagInRoomRepository;
            }
        }

        public Repository<UserRoom> UserRooms
        {
            get
            {
                if (userRoomRepository == null)
                    userRoomRepository = new Repository<UserRoom>(db);
                return userRoomRepository;
            }
        }

        public Repository<UserRoomRole> UserRoomRoles
        {
            get
            {
                if (userRoomRoleRepository == null)
                    userRoomRoleRepository = new Repository<UserRoomRole>(db);
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
