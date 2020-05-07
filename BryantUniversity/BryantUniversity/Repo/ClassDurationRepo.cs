using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class ClassDurationRepo
    {
        private Context _context;

        public ClassDurationRepo(Context context)
        {
            _context = context;
        }

        public IList<ClassDuration> GetAllClassDurations()
        {
            return _context.ClassTimes.ToList();

        }

        public IList<ClassDuration> GetById(int timeId)
        {
            return _context.ClassTimes
                .Where(c => c.Id == timeId).ToList();
            //FirstOrDefault(c => c.Id == id);
        }


        public void Update(ClassDuration time)
        {
            _context.ClassTimes.Attach(time);
            _context.Entry(time).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Insert(ClassDuration time)
        {
            _context.ClassTimes.Add(time);
            _context.SaveChanges();
        }

    }
}