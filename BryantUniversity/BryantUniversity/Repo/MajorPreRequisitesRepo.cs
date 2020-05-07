using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class MajorPreRequisitesRepo
    {
        private Context _context;

        public MajorPreRequisitesRepo(Context context)
        {
            _context = context;
        }

        public MajorPreRequisite GetById(int id)
        {
            return _context
                        .MajorPreRequisites
                        .FirstOrDefault(c => c.Id == id);
        }

        public IList<MajorPreRequisite> GetAllMajorPrequisites()
        {
            return _context
                        .MajorPreRequisites
                        .Include(m => m.PreReq)
                        .Include(m => m.Course)
                        .ToList();
        }

        public IList<MajorPreRequisite> GetAllMajorPrequisitesByMajorRequirement(int id)
        {
            return _context
                        .MajorPreRequisites
                        .Include(m => m.PreReq)
                        .Include(m => m.Course)
                        .Where(m => m.CourseId == id)
                        .ToList();
        }

        public IList<MajorPreRequisite> GetAllMajorPrequisitesByCourse(int id)
        {
            return _context
                        .MajorPreRequisites
                        .Include(m => m.PreReq)
                        .Include(m => m.Course)
                        .ToList();
        }

        public IList<MajorPreRequisite> GetAllMajorPrequisitesByDepartment(int id)
        {
            return _context
                        .MajorPreRequisites
                        .Include(m => m.PreReq)
                        .Include(m => m.Course)
                        .Include(m => m.Course.CourseLevel)
                        .Where(m => m.Course.DepartmentId == id)
                        .ToList();
        }


        public void Insert(MajorPreRequisite majorPrequisites)
        {
            _context
                .MajorPreRequisites
                .Add(majorPrequisites);
            _context.SaveChanges();
        }

        public void Update(MajorPreRequisite majorPrequisites)
        {
            _context
                .MajorPreRequisites
                .Attach(majorPrequisites);
            _context.Entry(majorPrequisites).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

        }
    }
}