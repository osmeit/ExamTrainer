using ExamTrainer.Models;

namespace ExamTrainer.Services
{

    public interface IAnwserService
    {
        Anwser GetById(int id);

        List<Anwser> GetAll();

        Anwser Create(Anwser anwser);

        List<Anwser> SearchByText(string searchText);
        Anwser Update(Anwser anwser);

        int Delete(Anwser anwser);
    }
    public class AnwserService : IAnwserService
    {
        private DatabaseContext _context;

        public AnwserService(DatabaseContext context)
        {
            this._context = context;
        }

        public Anwser Create(Anwser anwser)
        {
            _context.Anwsers.Add(anwser);
            _context.SaveChanges();
            return anwser;
        }

        public int Delete(Anwser anwser)
        {
            _context.Anwsers.Remove(anwser);
            return _context.SaveChanges();
        }

        public List<Anwser> GetAll()
        {
            return _context.Anwsers.ToList();
        }

        public Anwser GetById(int id)
        {
            return _context.Anwsers.Single(x => x.id == id);
        }
        public List<Anwser> SearchByText(string searchText)
        {
            return _context.Anwsers.Where(x => x.Text.Contains(searchText)).ToList();
        }
        public Anwser Update(Anwser anwser)
        {
            _context.Anwsers.Update(anwser);
            _context.SaveChanges(true);
            return anwser;
        }
    }
}
