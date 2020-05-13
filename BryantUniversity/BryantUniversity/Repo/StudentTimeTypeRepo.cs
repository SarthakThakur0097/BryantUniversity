using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace BryantUniversity.Repo
{
    public class StudentTimeTypeRepo
    {
        public Context _context;

        public StudentTimeTypeRepo(Context context)
        {
            _context = context;
        }

        public StudentTimeType GetStudentTimeTypeUserId(int id)
        {
            return _context.StudentsTimeType
                .Include(u => u.TimeTypes)
                .FirstOrDefault(u => u.UserId == id);
        }

        public void Update(StudentTimeType timeType)
        {
            _context.StudentsTimeType.Attach(timeType);
            _context.Entry(timeType).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Insert(StudentTimeType timeType)
        {
            _context.StudentsTimeType.Add(timeType);
            _context.SaveChanges();
        }

    }
}