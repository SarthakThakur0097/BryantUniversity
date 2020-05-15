using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace BryantUniversity.Repo
{
    public class StudentLevelRepo
    {
        public Context _context;

        public StudentLevelRepo(Context context)
        {
            _context = context;
        }

        public StudentLevel GetLevelByUserId(int id)
        {
            return _context.StudentLevels
                .Include(u => u.CourseLevel)
                .FirstOrDefault(u => u.UserId == id);                
        }

        public void Update(StudentLevel studentLevel)
        {
            _context.StudentLevels.Attach(studentLevel);
            _context.Entry(studentLevel).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Insert(StudentLevel studentLevel)
        {
            _context.StudentLevels.Add(studentLevel);
            _context.SaveChanges();
        }

    }
}