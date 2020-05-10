using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class StudentTypesRepo
    {
        private Context _context;

        public StudentTypesRepo(Context context)
        {
            _context = context;
        }

        public IList<StudentTypeModel> GetAllStudentTypes()
        {
            return _context
                        .StudentTypes
                        .ToList();
        }

        public StudentTypeModel GetById(int id)
        {
            return _context
                        .StudentTypes
                        .FirstOrDefault(c => c.Id == id);
        }

        public void Insert(StudentTypeModel studentType)
        {
            _context
                .StudentTypes
                .Add(studentType);
            _context.SaveChanges();
        }

        public void Update(StudentTypeModel studentType)
        {
            _context.StudentTypes.Attach(studentType);
            _context.Entry(studentType).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}