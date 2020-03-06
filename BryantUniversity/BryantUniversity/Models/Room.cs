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

        public Room(string buildingName, string roomType, Building building)
        {
            BuildingName = buildingName;
            RoomType = roomType;
            Building = building; 
        }

        public int Id { get; set; }
        [Required]
        public string BuildingName { get; set; }
        [Required]
        public string RoomType { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
