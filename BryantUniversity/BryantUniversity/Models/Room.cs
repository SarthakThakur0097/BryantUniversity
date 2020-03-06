using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class Room
    {
        public Room() { }

        public Room( string roomType, int roomCapacity, Building building)
        {           
            RoomType = roomType;
            Building = building;
            RoomCapacity = roomCapacity; 
        }

        public int Id { get; set; }
        public int RoomCapacity { get; set; }
       
        [Required]
        public string RoomType { get; set; }
        public Building Building { get; set; }
    }
}
