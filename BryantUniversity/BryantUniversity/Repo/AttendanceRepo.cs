using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BryantUniversity.Repo
{
    public class AttendanceRepo
    {
        public Context _context;

        public AttendanceRepo(Context context)
        {
            _context = context;
        }

        public IList<Attendance> GetAllAttendances()
        {
            return _context.Attendances
                .Include(a => a.Course)
                .Include(a => a.User)
                .ToList();

        }

        public void Insert(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
        }

        public Building GetById(int buildingId)
        {
            return _context.Buildings.FirstOrDefault(c => c.Id == buildingId);
        }


        public void Update(Building building)
        {
            _context.Buildings.Attach(building);
            _context.Entry(building).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }


    }
}