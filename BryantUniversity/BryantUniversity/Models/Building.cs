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

        public int Id { get; set; }
        [Required]
        public string BuildingName { get; set; }
        public int Capacity { get; set; }
        public List<Room> Rooms { get; set; }

    }
}