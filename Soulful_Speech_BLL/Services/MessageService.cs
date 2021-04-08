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
    public class MessageService
    {
        private IUnitOfWork context;

        public MessageService(IUnitOfWork context)
        {
            this.context = context;
        }

        public bool SendPersonalMessage(User fromUser, User toUser, string text)
        {
            try
            {
                context.PersonalMessages.Insert(new PersonalMessage()
                {
                    FromId = fromUser.Id,
                    ToId = toUser.Id,
                    MessageText = text
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SendRoomMessage(User user, Room room, string text)
        {
            try
            {
                context.Messages.Insert(new Message()
                {
                    UserId = user.Id,
                    RoomId = room.Id,
                    MessageText = text,
                    DateTime = DateTime.Now
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
