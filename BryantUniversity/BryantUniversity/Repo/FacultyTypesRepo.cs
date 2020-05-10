using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class FacultyTypesRepo
    {
        private Context _context;

        public FacultyTypesRepo(Context context)
        {
            _context = context;
        }

        public IList<FacultyTypeModel> GetAllFacultyTypes()
        {
            return _context
                        .FacultyTypes
                        .ToList();
        }

        public FacultyTypeModel GetById(int id)
        {
            return _context
                        .FacultyTypes
                        .FirstOrDefault(c => c.Id == id);
        }

        public void Insert(FacultyTypeModel facultyType)
        {
            _context
                .FacultyTypes
                .Add(facultyType);
            _context.SaveChanges();
        }

        public void Update(FacultyTypeModel facultyType)
        {
            _context.FacultyTypes.Attach(facultyType);
            _context.Entry(facultyType).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}