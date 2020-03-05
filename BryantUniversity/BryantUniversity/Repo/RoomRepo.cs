﻿using BryantUniversity.Data;
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
            return _context.Rooms.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Room room)
        {
            _context.Rooms.Attach(room);
            _context.Entry(room).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Insert(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

    }
}