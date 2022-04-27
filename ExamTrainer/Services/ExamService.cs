using ExamTrainer.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamTrainer.Services
{

    public interface IExamService
    {
        Exam GetById(int id);

        List<Exam> GetAll();

        Exam GetWithQuestions(int id);

        Exam GetWithQuestionsWithAnwesers(int id);

        Exam Create(Exam exam);

        List<Exam> SearchByText(string searchText);

        Exam Update(Exam exam);

        int Delete(Exam exam);

    }


    public class ExamService : IExamService
    {
        private DatabaseContext _context;

        public ExamService(DatabaseContext context)
        {
            this._context = context;
        }

        public Exam Create(Exam exam)
        {
                _context.Exams.Add(exam);
                _context.SaveChanges();
                return exam; 
        }

        public int Delete(Exam exam)
        {
           _context.Exams.Remove(exam);
           return _context.SaveChanges(); 
        }

        public List<Exam> GetAll() => _context.Exams.ToList();

        public Exam GetById(int id) => _context.Exams.Single(x => x.id == id);

        public Exam GetWithQuestions(int id)
        {
            return _context.Exams.Include(i => i.Questions).Single(x => x.id == id);
        }

        public Exam GetWithQuestionsWithAnwesers(int id)
        {
            return _context.Exams.Where(x => x.id == id).Include(i => i.Questions).ThenInclude(ti => ti.Anwsers).Single();
        }
        public List<Exam> SearchByText(string searchText)
        {
            return _context.Exams.Where(x => x.Name.Contains(searchText)).ToList();
        }

        public Exam Update(Exam exam)
        {
            _context.Exams.Update(exam);
            _context.SaveChanges(true);
            return exam;
        }
    }
}
