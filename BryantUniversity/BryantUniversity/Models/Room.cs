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

        public Room(string roomType, int roomCapacity, int buildingId)
        {
            RoomType = roomType;
            BuildingId = buildingId;
            RoomCapacity = roomCapacity;
        }

        public Room(int id, string roomType, int roomCapacity, int buildingId)
        {
            Id = id;
            RoomType = roomType;
            BuildingId = buildingId;
            RoomCapacity = roomCapacity;
        }
        public Room( string roomType, int roomCapacity, Building building)
        {           
            RoomType = roomType;
            Building = building;
            RoomCapacity = roomCapacity; 
        }

        public int Id { get; set; }
        [Required]
        public string RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
