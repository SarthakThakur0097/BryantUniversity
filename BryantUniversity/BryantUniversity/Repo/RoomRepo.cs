using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BryantUniversity.Repo
{
    public class RoomRepo
    {
        private Context _context;

        public RoomRepo(Context context)
        {
            _context = context;
        }

        public IList<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            return _context
                        .Rooms
                        .SingleOrDefault(c => c.Id == id);
        }

        public IList<Room> GetByBuildingId(int buildingId)
        {
            return _context
                        .Rooms
                        .Include(r => r.Building)
                        .Where(c => c.Building.Id == buildingId)
                        .ToList();
        }

        public void Update(Room room)
        {
            _context.Rooms.Attach(room);
            _context.Entry(room).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Insert(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

    }
}