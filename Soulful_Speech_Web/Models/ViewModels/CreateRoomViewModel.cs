using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soulful_Speech_Web.Models.ViewModels
{
    public class CreateRoomViewModel
    {
        [Required]
        public string RoomName { get; set; }
        [Required]
        public string Tags { get; set; }
    }
}
