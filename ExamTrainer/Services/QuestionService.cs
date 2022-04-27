using ExamTrainer.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamTrainer.Services
{

    public interface IQuestionService
    {
        Question GetById(int id);

        List<Question> GetAll();

        List<Question> SearchByText(string searchText);

        Question GetByIdWithAnwsers(int id);

        Question Create(Question question);

        Question Update(Question question);

        int Delete(Question question);
    }

    public class QuestionService : IQuestionService
    {
        private DatabaseContext _context;
        public QuestionService(DatabaseContext context)
        {
            _context = context;
        }

        public Question Create(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return question;
        }

        public int Delete(Question question)
        {
            _context.Questions.Remove(question);
            return _context.SaveChanges();
        }

        public List<Question> GetAll()
        {
           return _context.Questions.ToList();
        }

        public Question GetById(int id)
        {
            return _context.Questions.Single(x => x.id == id);
        }

        public Question GetByIdWithAnwsers(int id)
        {
            return _context.Questions.Where(x => x.id == id).Include(i => i.Anwsers).Single();
        }

        public List<Question> SearchByText(string searchText)
        {
            return _context.Questions.Where(x => x.Text.Contains(searchText)).ToList();
        }

        public Question Update(Question question)
        {
            _context.Questions.Update(question);
            _context.SaveChanges(true);
            return question;
        }
    }
}
