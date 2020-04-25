using BryantUniversity.Data;
using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Repo
{
    public class DepartmentRepo
    {
        private Context _context;

        public DepartmentRepo(Context context)
        {
            _context = context;
        }

        public IList<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.SingleOrDefault(d => d.Id == id);
        }

        public void Insert(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            _context.Departments.Attach(department);
            _context.Entry(department).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}