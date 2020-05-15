using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class LetterGradesRepo
    {
        private Context _context;

        public LetterGradesRepo(Context context)
        {
            _context = context;
        }

        public IList<LetterGrade> GetAllLetterGrades()
        {
            return _context
                        .LetterGrades
                        .ToList();
        }

        public LetterGrade GetById(int id)
        {
            return _context
                        .LetterGrades
                        .FirstOrDefault(c => c.Id == id);
        }

        public void Insert(LetterGrade letterGrade)
        {
            _context
                .LetterGrades
                .Add(letterGrade);

            _context.SaveChanges();
        }

        public void Update(LetterGrade letterGrade)
        {
            _context.LetterGrades.Attach(letterGrade);
            _context.Entry(letterGrade).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}