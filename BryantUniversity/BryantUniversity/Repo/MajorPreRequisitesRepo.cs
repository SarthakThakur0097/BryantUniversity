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

        public MajorPreRequisites GetById(int id)
        {
            return _context
                        .MajorPreRequisites
                        .SingleOrDefault(c => c.Id == id);
        }

        public IList<MajorPreRequisites> GetAllMajorPrequisites()
        {
            return _context
                        .MajorPreRequisites
                        .Include(m => m.MajorRequirements)
                        .Include(m => m.Course)
                        .ToList();
        }

        public IList<MajorPreRequisites> GetAllMajorPrequisitesByMajorRequirement(int id)
        {
            return _context
                        .MajorPreRequisites
                        .Include(m => m.MajorRequirements)
                        .Include(m => m.Course)
                        .Where(m => m.MajorRequirementsId == id)
                        .ToList();
        }

        public IList<MajorPreRequisites> GetAllMajorPrequisitesByCourse(int id)
        {
            return _context
                        .MajorPreRequisites
                        .Include(m => m.MajorRequirements).Where(m => m.MajorRequirements.CourseId == id)
                        .Include(m => m.Course)
                        .ToList();
        }



        public void Insert(MajorPreRequisites majorPrequisites)
        {
            _context
                .MajorPreRequisites
                .Add(majorPrequisites);
            _context.SaveChanges();
        }

        public void Update(MajorPreRequisites majorPrequisites)
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