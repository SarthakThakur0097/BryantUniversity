using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class Building
    {
        public Building() { }

        public Building(string buildingName, int capacity)
        {
            BuildingName = buildingName;
            Capacity = capacity;
            Rooms = new List<Room>();
        }

        public Building(int id, string buildingName, int capacity)
        {
            Id = id;
            BuildingName = buildingName;
            Capacity = capacity;
            Rooms = new List<Room>();
        }

        public int Id { get; set; }
        [Required]
        public string BuildingName { get; set; }
        public int Capacity { get; set; }
        public virtual List<Room> Rooms { get; set; }

    }
}