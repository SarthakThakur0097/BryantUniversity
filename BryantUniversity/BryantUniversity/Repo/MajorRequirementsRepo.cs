using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class MajorRequirmentsRepo
    {
        private Context _context;

        public MajorRequirmentsRepo(Context context)
        {
            _context = context;
        }

        public MajorRequirements GetById(int id)
        {
            return _context.MajorRequirements
                .Include(m => m.Course)
                .FirstOrDefault(c => c.Id == id);
        }

        public IList<MajorRequirements> GetAllMajorRequirments()
        {
            return _context.MajorRequirements
                .Include(m => m.Major)
                .Include(m => m.Course)
                .ToList();
        }

        public IList<MajorRequirements> GetAllMajorRequirementsByMajor(int id)
        {
            return _context.MajorRequirements
                .Include(m => m.Major)
                .Include(m => m.Course)
                .Include(m => m.Course.MajorPreRequisitesCourses)
                .Include(m => m.Course.CourseMajorPreRequisites)
                .Where(m => m.MajorId == id)
                .ToList();
        }

        public void Insert(MajorRequirements majorRequirements)
        {
            _context.MajorRequirements.Add(majorRequirements);
            _context.SaveChanges();
        }

        public void Update(MajorRequirements majorRequirements)
        {
            _context.MajorRequirements.Attach(majorRequirements);
            _context.Entry(majorRequirements).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

        }
    }
}