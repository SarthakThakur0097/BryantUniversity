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
                .Include(a => a.Registration.CourseSection.Course)
                .Include(a => a.Registration.CourseSection.Professor)
                .Include(a => a.Registration.CourseSection)
                .Include(a => a.Registration.CourseSection.Course)
                .ToList();
        }

        public IList<Attendance> GetAllAttendanceByUserId(int id)
        {
            return _context.Attendances
                .Include(a => a.Registration.UserId == id)
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